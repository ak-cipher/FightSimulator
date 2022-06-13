using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    public GameObject[] toDeactivate;
    public GameObject[] players;
    public Text winnerText;

    private void Start()
    {
        winnerText.text = "";
    }
    public void Win(string Losser)
    {
        foreach (GameObject g in toDeactivate)
        {
            g.SetActive(false);
        }

        //if(Losser == "Player")
        //{

        //}
        switch (Losser)
        {
            case "Player":
                players[1].GetComponent<AI_MovementController>().enabled = false;
                players[1].SetActive(true);
                players[1].transform.position = new Vector3(0f, 3f, 9f);
                players[1].transform.localScale = new Vector3(4f, 4f, 4f);
                winnerText.text = "Winner is AI_Player";
                break;
            case "AI_Player":
                players[0].GetComponent<PlayerMovement>().enabled = false;
                players[0].SetActive(true);
                players[0].transform.position = new Vector3(0f, 3f, 9f);
                players[0].transform.localScale = new Vector3(4f, 4f, 4f);
                winnerText.text = "Winner is Player";
                break;
        }
    }

}