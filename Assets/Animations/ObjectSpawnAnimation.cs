using UnityEngine;
using System.Collections;

public class ObjectSpawnAnimation : MonoBehaviour
{
    public float moveDistance = 2f; // расстояние, на которое опускается объект
    public float animationDuration = 3f; // длительность анимации

    private float initialY; // начальное положение объекта по Y

    private void Start()
    {
        initialY = transform.position.y;
        StartCoroutine(SpawnAnimation());
    }

    private IEnumerator SpawnAnimation()
    {
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            float yOffset = Mathf.Lerp(moveDistance, 0f, Mathf.Pow(t, 0.2f));
            transform.position = new Vector3(transform.position.x, initialY + yOffset, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }
}
