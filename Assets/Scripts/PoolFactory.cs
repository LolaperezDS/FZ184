using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolFactory : MonoBehaviour
{
    [SerializeField] private GameMaster gm;

    public List<GameObject> answers;
    public List<GameObject> dotOfSpawns;
    public Text question;
    public int numberOfTicket;

    public GameObject SquarePrefab;
    [SerializeField] private Canvas canv;

    private void Start()
    {
        answers = new List<GameObject>();
    }

    public void MakePool()
    {
        gm.currentTicketNum++;
        ClearPool();
        Ticket correctTicket = Pool.GetRandomTicket();
        question.text = correctTicket.question;

        int r = Random.Range(0, 4);
        for (int i = 0; i < dotOfSpawns.Count; i++)
        {
            GameObject go = Instantiate(SquarePrefab, dotOfSpawns[i].transform.position, Quaternion.identity, canv.gameObject.transform);
            AnswerBehaivour beh = go.GetComponent<AnswerBehaivour>();
            if (i == r)
            {
                beh.isCorrect = true;
                beh.description = correctTicket.correctAnswer;
            }
            else
            {
                beh.isCorrect = false;
                beh.description = Pool.GetRandomTicket().correctAnswer;
            }
            answers.Add(go);
        }
    }

    public void ClearPool()
    {
        foreach (GameObject o in answers)
        {
            Destroy(o.gameObject);
        }
        answers.Clear();
    }
}
