Shader "Unlit/OverlayFadeInTextured"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Filling("fill (range)", Range(0, 1)) = 0.5
        _Alpha("alpha cut (range)", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Filling;
            float _Alpha;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            float alphaCutOut(float x) {
                if (x < _Alpha) {
                    return 0;
                }
                return 1;
            }

            float fillCurve(float x, float offs) {
                float output = x * (offs + 1);
                if (output > 1){
                    return 1;
                }
                return output;
            }

            fixed4 gausBlur(v2f v){
                float Pi = 6.28318530718; // Pi*2
    
                // GAUSSIAN BLUR SETTINGS {{{
                float Directions = 15.0; // BLUR DIRECTIONS (Default 16.0 - More is better but slower)
                float Quality = 3.0; // BLUR QUALITY (Default 4.0 - More is better but slower)
                float Size = 2; // BLUR SIZE (Radius)
                // GAUSSIAN BLUR SETTINGS }}}
   
                float2 Radius = Size/_ScreenParams.xy;
    
                // Normalized pixel coordinates (from 0 to 1)
                float2 uv = v.uv;
                // Pixel colour
                fixed4 col_out = tex2D(_MainTex, uv);
    
                // Blur calculations
                for( float d=0.0; d<Pi; d+=Pi/Directions)
                {
	                for(float i=1.0/Quality; i<=1.0; i+=1.0/Quality)
                    {
		                col_out += tex2D(_MainTex, uv+float2(cos(d),sin(d))*Radius*i);		
                    }
                }
    
                // Output to screen
                col_out /= Quality * Directions;
                return col_out;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
            
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // fixed4 color_n = tex2D(_MainTex, i.uv);
                fixed4 color_n = gausBlur(i);

                // fill modeling
                float fillColoumn = fillCurve(_Filling, uv.x);

                float4 mask = (color_n * (1 - _Alpha) +  fillColoumn);
                // sample the texture
                fixed4 col = float4(0, 0, 0, alphaCutOut(mask.b));
                // apply fog
                // fixed4 col = fillCurve(_Filling, uv.x);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
