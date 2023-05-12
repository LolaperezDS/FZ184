using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dotOfExit : MonoBehaviour
{
    [SerializeField] Image goimage;
    private Material material;

    public bool isRunning = false;
    public float duration = 1f; // врем€, за которое нужно изменить значение материала
    private float timer = 0f; // таймер, используемый дл€ изменени€ значени€ материала

    [SerializeField] GameObject health_cell;
    [SerializeField] GameObject health_breaked;

    [SerializeField] Button endGameButton;
    private float fadeDuration = 0.5f;

    [SerializeField] AudioSource heartbreak, endmusic;

    public TMP_Text text; // ссылка на компонент текста
    public float delay = 0.01f; // задержка между по€влением символов


    private void Start()
    {
        goimage.material.SetFloat("_Alpha", 1f);
        material = goimage.material;
    }

    public void GameOver()
    {
        if (!isRunning) StartCoroutine(nameof(courutine));
    }
    IEnumerator courutine()
    {
        isRunning = true;

        // запоминаем начальное значение материала
        float startValue = material.GetFloat("_Alpha");

        // в цикле измен€ем значение материала от 0 до 1 за врем€ duration
        while (timer < duration)
        {
            float t = timer / duration;
            float value = 1 - Mathf.Lerp(0f, startValue, t);
            material.SetFloat("_Alpha", value);
            timer += Time.deltaTime;
            yield return null;
        }

        // устанавливаем значение материала в 1
        material.SetFloat("alpha cut", 0f);

        heartbreak.Play();
        yield return new WaitForSeconds(1f);
        health_cell.SetActive(false);
        health_breaked.SetActive(true);

        yield return new WaitForSeconds(1f);
        health_breaked.SetActive(false);
        yield return new WaitForSeconds(0.35f);
        StartCoroutine(nameof(AnimateText));
        yield return new WaitForSeconds(1.5f);

        // плавно показываем кнопку " онец игры"
        endmusic.Play();
        float alphaTimer = 0f;
        endGameButton.gameObject.SetActive(true);
        Color buttonColor = endGameButton.image.color;
        while (alphaTimer < fadeDuration)
        {
            float t = alphaTimer / fadeDuration;
            buttonColor.a = Mathf.Lerp(0f, 1f, t);
            endGameButton.image.color = buttonColor;
            alphaTimer += Time.deltaTime;
            yield return null;
        }

        // устанавливаем прозрачность кнопки в 1
        buttonColor.a = 1f;
        endGameButton.image.color = buttonColor;

        isRunning = false;
    }

    private IEnumerator AnimateText()
    {
        text.gameObject.SetActive(true);
        text.maxVisibleCharacters = 0;

        // выводим символы по одному с задержкой
        for (int i = 0; i <= text.text.Length; i++)
        {
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delay);
        }
    }
}
