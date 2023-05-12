using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotOfEnter : MonoBehaviour
{
    void Start()
    {
        Pool.Init();
        FindObjectOfType<PoolFactory>().MakePool();
        FindObjectOfType<GameMaster>().Setup();
    }
}
