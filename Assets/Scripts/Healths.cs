using UnityEngine;
using System.Collections;

public class Healths : MonoBehaviour
{
    [SerializeField] GameObject health3;
    [SerializeField] GameObject health2;

    public int healths = 3;
    
    public float pulseDuration = 1f; // длительность пульсации
    public Color startColor; // начальный цвет фона
    public Color startColorRed; // начальный цвет фона
    public Color endColor; // конечный цвет фона

    private Color originalColor;

    private void Start()
    {
        originalColor = Camera.main.backgroundColor;
    }

    private IEnumerator PulseBackground()
    {
        float elapsedTime = 0f;
        while (elapsedTime < pulseDuration)
        {
            // вычисляем промежуточный цвет с помощью Color.Lerp()
            float t = elapsedTime / pulseDuration;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            Camera.main.backgroundColor = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // после окончания анимации возвращаем оригинальный цвет фона
        Camera.main.backgroundColor = originalColor;
    }


    private IEnumerator PulseBackgroundRed()
    {
        float elapsedTime = 0f;
        while (elapsedTime < pulseDuration)
        {
            // вычисляем промежуточный цвет с помощью Color.Lerp()
            float t = elapsedTime / pulseDuration;
            Color currentColor = Color.Lerp(startColorRed, endColor, t);
            Camera.main.backgroundColor = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // после окончания анимации возвращаем оригинальный цвет фона
        Camera.main.backgroundColor = originalColor;
    }

    public void GreenPulse() => StartCoroutine(PulseBackground());

    public void TakeDamage()
    {
        healths--;
        if (healths == 2)
        {
            StartCoroutine(PulseBackgroundRed());
            health3.gameObject.SetActive(false);
        }
        if (healths == 1)
        {
            StartCoroutine(PulseBackgroundRed());
            health2.gameObject.SetActive(false);
        }
        if (healths == 0)
        {
            FindObjectOfType<dotOfExit>().GameOver();
        }
    }
}
