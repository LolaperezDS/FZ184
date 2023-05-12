using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnswerBehaivour : MonoBehaviour, IPointerClickHandler
{
    public bool isCorrect;
    public string description;

    [SerializeField] PoolFactory game_master;

    [SerializeField] private Text text;

    void Start()
    {
        text.text = description;
        game_master = FindObjectOfType<PoolFactory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI element clicked");

        if (isCorrect)
        {
            game_master.MakePool();
        }
        else
        {
            FindObjectOfType<dotOfExit>().GameOver();
        }
    }
}
