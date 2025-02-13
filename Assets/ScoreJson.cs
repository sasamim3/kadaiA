using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreJson : MonoBehaviour
{
    private string filepath;
    private score scoreData;

    private void Awake()
    {
        filepath = Path.Combine(Application.dataPath, "score");
        LoadData();
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filepath, json);
    }
    private void LoadData()
    {
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            scoreData = JsonUtility.FromJson<score>(json);
        }
        else
        {
            scoreData = new score();
        }
    }
    // Update is called once per frame

    [System.Serializable]
    public class score
    {
        public int score1 = 0;
    }

    public void scoreSaved()
    {
        if (PlayerController.Players == 0)
        {
            scoreData.score1 = ScoreController.Score;
            SaveData();
            Debug.Log("data saved");
        }
    }
}
