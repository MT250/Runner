using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;               //TODO: Remake all.
    [SerializeField] private TMP_InputField TMP_InputField;
    [SerializeField] private GameObject topScores;
    [SerializeField] private GameObject gameEndCanvas;
    public void SubmitScore() 
    {
        string playerName = TMP_InputField.text;
        int playerScore = gameManager.GetScore();

        if (playerName == string.Empty || playerName.Length < 5)
        {
            Debug.Log("Player name is empty or less than 5 characters.");
            return;
        }
        else
        {
            ScorePublisher.PublishScoreAsync(playerName, playerScore);
            topScores.SetActive(true);
            gameEndCanvas.SetActive(false);
        }
    }

    public void ExitToMenu()
    {
        //TODO: Exit to menu;
    }

    public void ExitApp()
    {
        Application.Quit(0);
    }
}
