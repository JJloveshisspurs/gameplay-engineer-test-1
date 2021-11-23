using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerDialog : MonoBehaviour
{
    public TextMeshProUGUI winnerLabel;

    public void OnEnable()
    {
        GameController.instance.currentGameState = GameController.GameState.Gameover;
        DisplayWinner();
    }


    public void DisplayWinner()
    {
        if(GameController.instance.currentGameData.currentPlayerTurn == PlayerTurns.turns.O_Turn)
        {

            winnerLabel.text = "O player wins!!!!";
        }
        else
        {
            winnerLabel.text = "X player wins!!!!";

        }


    }
}
