using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fireworks : MonoBehaviour
{
    public GameObject explosionPrefab; // префаб системы частиц взрыва
    public int numProjectiles = 20; // количество снарядов в фейерверке

    public void StartFireworks()
    {
        StartCoroutine(FireworkCoroutine());
    }

    private IEnumerator FireworkCoroutine()
    {
        List<GameObject> prjtls = new List<GameObject>();
        for (int i = 0; i < numProjectiles; i++)
        {
            prjtls.Add(Instantiate(explosionPrefab, this.transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0), Quaternion.identity));
        }
        foreach (GameObject go in prjtls)
        {
            yield return new WaitForSeconds(0.2f);
            go.GetComponent<ParticleSystem>().Play();
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject go in prjtls)
        {
            go.GetComponent<ParticleSystem>().Stop();
            Destroy(go.gameObject);
        }
    }
}

