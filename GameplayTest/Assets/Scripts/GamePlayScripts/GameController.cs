using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;


    public enum GameState
    {
        AssigningFirstPlayer,
        Gameplay,
        Gameover
    }

    public GameState currentGameState;

    public TicTactToeGameData currentGameData;

    public GameObject firstPlayerTurnSelection;

    public List<TicTacToeSelectionButton> ticTacToeButtons;

    public GameObject winnerDialog;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void ResetGame()
    {
        //*** Reset that game was won 
        GameController.instance.currentGameData.gameWasWon = false;


        //*** Hide winner dialog in case of reset
        winnerDialog.SetActive(false);


        firstPlayerTurnSelection.SetActive(true);

        //*** Reset Game Board states
        currentGameData.ResetGameBoardState();

        //*** Reset Marker spots
        for (int i = 0; i < ticTacToeButtons.Count; i++)
        {
            ticTacToeButtons[i].ClearMarkerSpot();


        }

        currentGameState = GameState.Gameplay;

    }


    public void SetFirstPlayerTurn(PlayerTurns.turns pTurn)
    {

        currentGameData.SetFirstPlayerTurns(pTurn);

    }

    public void RevealWinnerDialog()
    {
        winnerDialog.SetActive(true);


    }

   
}
