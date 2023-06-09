using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int ticketAmount;
    public int currentTicketNum;

    public Text counter;
    [SerializeField] AudioSource maintheme;

    public void Setup()
    {
        currentTicketNum = 1;
        ticketAmount = Pool.ticketsAmount;
    }

    private void Update()
    {
        counter.text = currentTicketNum.ToString() + "/" + ticketAmount.ToString();
        if (ticketAmount < currentTicketNum)
        {
            FindObjectOfType<Fireworks>().StartFireworks();
            maintheme.Pause();
            maintheme.Stop();
            maintheme.mute = true;
            Invoke(nameof(EndOfGame), 3f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void EndOfGame()
    {
        SceneManager.LoadScene(1);
    }
}
