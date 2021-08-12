using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score;
    [Header("Components")]
    [SerializeField] TMP_Text tmpText_Score;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] GameObject scoreSubmitCanvas;
    void Update()
    {
        score += Time.deltaTime;

        tmpText_Score.text = score.ToString("0");
    }

    public int GetScore()
    {
        return (int)score;
    }

    public void EndGame()
    {
        Time.timeScale = 0f;

        scoreSubmitCanvas.SetActive(true);
    }

}
