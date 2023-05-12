using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Ticket {
    public string question;
    public string correctAnswer;
}

public static class Pool
{
    public static int ticketsAmount = 15;

    public static List<Ticket> tickets;

    private static string filepath = Application.streamingAssetsPath + "/saves/";

    public static void Init()
    {
        if (tickets == null)
        {
            tickets = new List<Ticket>();
            string loadedData = "";
            using (var reader = new StreamReader(filepath + "termins.txt"))
            {
                loadedData = reader.ReadToEnd();
            }
            string[] strings = loadedData.Split("\n");
            foreach (string o in strings)
            {
                Ticket new_ticket = new Ticket();
                new_ticket.question = o.Split(":")[0];
                new_ticket.correctAnswer = o.Split(":")[1];
                tickets.Add(new_ticket);
            }
        }
    }

    public static Ticket GetRandomTicket()
    {
        return tickets[Random.Range(0, tickets.Count - 1)];
    }
}
