using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicTacToeSelectionButton : MonoBehaviour
{
    public PlayerSpaceState.state spaceState;

    public TextMeshProUGUI markerStateText;


    public int arrayIndex;

    public void SelectMarkerSpot()
    {
        //***  Check that current space hasn't been claimed
        if(spaceState == PlayerSpaceState.state.Unclaimed_Space)
        {
            switch (GameController.instance.currentGameData.currentPlayerTurn)
            {

                case PlayerTurns.turns.O_Turn:
                    spaceState = PlayerSpaceState.state.O_Space;
                    break;


                case PlayerTurns.turns.X_Turn:
                    spaceState = PlayerSpaceState.state.X_Space;
                    break;


                default:

                    break;

            }

            //*** Render Space State
            RenderSpaceState();
        }


    }


    public void ClearMarkerSpot()
    {
        spaceState = PlayerSpaceState.state.Unclaimed_Space;

        RenderSpaceState();
    }


    public void RenderSpaceState()
    {
        switch (spaceState)
        {
            case PlayerSpaceState.state.Unclaimed_Space:
                markerStateText.text = "";

                break;

            case PlayerSpaceState.state.X_Space:
                markerStateText.text = "X";

                break;

            case PlayerSpaceState.state.O_Space:
                markerStateText.text = "O";

                break;

            default:


                break;

        }


        GameController.instance.currentGameData.UpdateGameBoard(arrayIndex,spaceState);
    }

}
