using System;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public static class ScorePublisher
{
    const string serverUri = "http://localhost:8888/";

    public static async void PublishScoreAsync(string _playerName, int _score) //TODO: Implement score submiting result. ex:Alert if no conn to server.
    {
        WebRequest webRequest = WebRequest.Create(serverUri);
        webRequest.Method = "POST";
        webRequest.ContentType = "application/json";

        Score scr = new Score(_playerName, _score);

        string scrString = SerializeToJSON(scr);

        byte[] byteArray = Encoding.Unicode.GetBytes(scrString);
        webRequest.ContentLength = byteArray.Length;

        using (Stream dataStream = await webRequest.GetRequestStreamAsync())
        {
            await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
        }

        WebResponse response = await webRequest.GetResponseAsync();
        using (Stream responseStream = response.GetResponseStream())
        {
            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                string responseBody = streamReader.ReadToEnd();
                Debug.Log(responseBody);
            }

        }

        response.Close();
    }

    private static string SerializeToJSON(object _data)
    {
        string json = JsonUtility.ToJson(_data, false);
        return json;
    }

    [Serializable]
    public class Score
    {
        // TODO: In server code JsonConvert cannot parse second digit in received json file. (???????!!!!!!)
        // score saved as string instead of integer.
        // Ex.
        // JSON: {"playerScore":87,"playerName":"PlayerName"}
        // Exeception message: After parsing a value an unexpected character was encountered: 7. Path 'playerScore', line 1, position 32.
        
        public string playerScore;
        public string playerName;
        public Score(string _name, int _score)
        {
            this.playerName = _name;
            this.playerScore = _score.ToString();
        }
    }
}
