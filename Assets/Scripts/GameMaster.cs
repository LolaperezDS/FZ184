using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int ticketAmount;
    public int currentTicketNum;

    public Text counter;

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
            // win
        }
    }
}
