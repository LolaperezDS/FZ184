using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public float startTime;
    private float currentTime;

    [SerializeField] private Image hb;
    void Start()
    {
        startTime = 180f;
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        hb.fillAmount = currentTime / startTime;
        if (currentTime < 0)
        {

        }
    }
}
