using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Text;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 10000f;
    private string filepath = Application.streamingAssetsPath + "/saves/";

    public Text textMeshPro;
    private void Start()
    {
        string loadedData = "";
        using (var reader = new StreamReader(filepath + "termins.txt", Encoding.UTF8))
        {
            loadedData = reader.ReadToEnd();
        }
        string[] strings = loadedData.Split("\n");
        textMeshPro.text = string.Join("\n\n", strings);
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += new Vector3(0, scroll * scrollSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}