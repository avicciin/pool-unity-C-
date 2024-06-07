using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] BotControll botStartGame;
    [SerializeField] Speed checkMove;
    public bool IsplayerTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");

        /* if (checkMove.speed == 0)
         {
             CheckWhoPlaying();
             IsplayerTurn = true;
             Debug.Log("spped = 0");
        }
         */
    }
    
    public void CheckWhoPlaying()
    {
        IsplayerTurn = !IsplayerTurn;
        if(!IsplayerTurn)
        {
            botStartGame.StartAction();

        }

    }


}
