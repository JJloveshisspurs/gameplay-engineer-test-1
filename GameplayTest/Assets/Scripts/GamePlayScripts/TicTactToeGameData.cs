using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TicTactToeGameData 
{
    public int x_Wins;
    public int o_Wins;

    public PlayerTurns.turns currentPlayerTurn;

    public List<PlayerSpaceState.state> currentGameboard;

    public bool gameWasWon;

    public int movesMadeInGame;

    public int maxMovesInGame = 9;


    public void SetFirstPlayerTurns(PlayerTurns.turns pTurn)
    {

        currentPlayerTurn = pTurn;

    }

    public void SwitchPlayerTurns()
    {
        if (currentPlayerTurn == PlayerTurns.turns.O_Turn)
        {
            currentPlayerTurn = PlayerTurns.turns.X_Turn;

        }
        else if (currentPlayerTurn == PlayerTurns.turns.X_Turn)
        {
            currentPlayerTurn = PlayerTurns.turns.O_Turn;
        }

    }


    public void ResetGameBoardState()
    {

        //*** Set Game board with 9 spaces
        currentGameboard = new List<PlayerSpaceState.state>(9);

        if(currentGameboard.Count < 9)
        {
            for( int i = 0; i < 9; i++)
            {
                currentGameboard.Add(PlayerSpaceState.state.Unclaimed_Space);


            }

        }


        for (int i = 0; i < currentGameboard.Count; i++)
        {
            currentGameboard[i] = PlayerSpaceState.state.Unclaimed_Space;


        }


    }


    public void SavePlayerTurns()
    {


    }

    public void UpdateGameBoard(int pIndex, PlayerSpaceState.state pState)
    {
        if (GameController.instance.currentGameState == GameController.GameState.Gameplay)
        {
            currentGameboard[pIndex] = pState;

            CheckForWins();
        }
    }

    public void CheckForWins()
    {
        movesMadeInGame = movesMadeInGame + 1;

        if (maxMovesInGame - movesMadeInGame == 0)
            AnnounceNoOnewins();

        if (currentPlayerTurn == PlayerTurns.turns.O_Turn)
            EvaluateIfOPlayerWon();

        if (currentPlayerTurn == PlayerTurns.turns.X_Turn)
            EvaluateIfXPlayerWon();


        if (gameWasWon == false)
        {
            SwitchPlayerTurns();

        }
        else
        {

            AnnounceWinner();
        }
    }

    public void AnnounceWinner()
    {
        Debug.Log(currentPlayerTurn.ToString() + "Player wins !!!!");
        GameController.instance.RevealWinnerDialog();
        
    }

    public void AnnounceNoOnewins()
    {

        Debug.Log(currentPlayerTurn.ToString() + "DRAW NO ONE WINS !!!!");
    }

    public bool EvaluateIfXPlayerWon()
    {
        //*** Board representation  
        //[0] [1] [2]
        //[3] [4] [5]
        //[6] [7] [8]


        bool oDidPlayerwin = false;

        //*** Horizontal wins
        if(currentGameboard[0] == PlayerSpaceState.state.X_Space && currentGameboard[1] == PlayerSpaceState.state.X_Space && currentGameboard[2] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[3] == PlayerSpaceState.state.X_Space && currentGameboard[4] == PlayerSpaceState.state.X_Space && currentGameboard[5] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[6] == PlayerSpaceState.state.X_Space && currentGameboard[7] == PlayerSpaceState.state.X_Space && currentGameboard[8] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        //*** Vertical wins
        if (currentGameboard[0] == PlayerSpaceState.state.X_Space && currentGameboard[3] == PlayerSpaceState.state.X_Space && currentGameboard[6] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[1] == PlayerSpaceState.state.X_Space && currentGameboard[4] == PlayerSpaceState.state.X_Space && currentGameboard[7] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[2] == PlayerSpaceState.state.X_Space && currentGameboard[5] == PlayerSpaceState.state.X_Space && currentGameboard[8] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }
       
        //*** Diagonal wins

        if (currentGameboard[0] == PlayerSpaceState.state.X_Space && currentGameboard[4] == PlayerSpaceState.state.X_Space && currentGameboard[8] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[2] == PlayerSpaceState.state.X_Space && currentGameboard[4] == PlayerSpaceState.state.X_Space && currentGameboard[6] == PlayerSpaceState.state.X_Space)
        {
            gameWasWon = true;
        }
   
        return oDidPlayerwin;
    }

    public bool EvaluateIfOPlayerWon()
    {
        bool oDidPlayerwin = false;

        //*** Horizontal wins
        if (currentGameboard[0] == PlayerSpaceState.state.O_Space && currentGameboard[1] == PlayerSpaceState.state.O_Space && currentGameboard[2] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[3] == PlayerSpaceState.state.O_Space && currentGameboard[4] == PlayerSpaceState.state.O_Space && currentGameboard[5] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[6] == PlayerSpaceState.state.O_Space && currentGameboard[7] == PlayerSpaceState.state.O_Space && currentGameboard[8] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        //*** Vertical wins
        if (currentGameboard[0] == PlayerSpaceState.state.O_Space && currentGameboard[3] == PlayerSpaceState.state.O_Space && currentGameboard[6] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[1] == PlayerSpaceState.state.O_Space && currentGameboard[4] == PlayerSpaceState.state.O_Space && currentGameboard[7] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[2] == PlayerSpaceState.state.O_Space && currentGameboard[5] == PlayerSpaceState.state.O_Space && currentGameboard[8] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        //*** Diagonal wins

        if (currentGameboard[0] == PlayerSpaceState.state.O_Space && currentGameboard[4] == PlayerSpaceState.state.O_Space && currentGameboard[8] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }

        if (currentGameboard[2] == PlayerSpaceState.state.O_Space && currentGameboard[4] == PlayerSpaceState.state.O_Space && currentGameboard[6] == PlayerSpaceState.state.O_Space)
        {
            gameWasWon = true;
        }



        return oDidPlayerwin;
    }
}
