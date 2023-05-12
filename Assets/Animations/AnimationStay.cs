using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStay : MonoBehaviour
{
    private Vector3 origin;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;

    private float randomPhase;
    void Start()
    {
        origin = this.gameObject.transform.position;
        randomPhase = Random.Range(0f, 6.28f);
    }

    void Update()
    {
        this.transform.position = origin + direction * amplitude * Mathf.Sin(Time.time * frequency * 2 * Mathf.PI + randomPhase);
    }
}
