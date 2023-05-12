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
