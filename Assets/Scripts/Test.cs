using UnityEngine;

public class Test : MonoBehaviour
{
    public int value = 1;
    public bool useRandomValue;
    public int min, max;
    void Start()
    {
        //ScorePublisher.PublishScoreAsync(value);
        if (useRandomValue)
        {
            ScorePublisher.PublishScoreAsync("PlayerName", Random.Range(min, max));
        }
        else
            ScorePublisher.PublishScoreAsync("PlayerName", value);
    }
}
