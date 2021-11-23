using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstTurnSelection : MonoBehaviour
{
    public TextMeshProUGUI turnSelectionLabel;

    public float rapidFireSwitchingRate = .07f;

    public bool Render_X_Marker;

    public PlayerTurns.turns firstPlayerturn;


    // Start is called before the first frame update
    void OnEnable()
    {
        CancelInvoke();

        InvokeRepeating("UpdateTurnSelect", rapidFireSwitchingRate, rapidFireSwitchingRate);

        RollForFirstPlayer();

        //*** After 3 seconds reveal who goes first;

        Invoke("RevealFirstPlayer", 3f);
    }

    public void UpdateTurnSelect()
    {
        if (Render_X_Marker)
        {


            turnSelectionLabel.text = "X";

            Render_X_Marker = false;
        }
        else
        {

            turnSelectionLabel.text = "O";

            Render_X_Marker = true;
        }
    }

    public void RollForFirstPlayer()
    {
        int oRandom = Random.Range(0, 100);

        //*** If  Random number is less than 50 , O goes first
        if (oRandom < 50)
        {
            firstPlayerturn = PlayerTurns.turns.O_Turn;


        }
        else//*** If X greater than or equal to 50 , X goes first
        {
            firstPlayerturn = PlayerTurns.turns.X_Turn;

        }

    }

    public void RevealFirstPlayer()
    {
        CancelInvoke();

        if (firstPlayerturn == PlayerTurns.turns.X_Turn)
        {
            turnSelectionLabel.text = "X";

        }
        else
        {
            turnSelectionLabel.text = "O";

        }

        GameController.instance.SetFirstPlayerTurn(firstPlayerturn);

    }

    public void ClosePanel()
    {
        GameController.instance.currentGameState = GameController.GameState.Gameplay;
        this.gameObject.SetActive(false);
    }
}
