using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavedData : MonoBehaviour
{
    public static SavedData Instance;
    public string playerName;

    [SerializeField] MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {

        if(Instance = null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
   public class SavedHighScoreData
    {
        public string highScoreName;
        public int highScoreNumber;
    }

    public void SaveHighScore()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        SavedHighScoreData data = new SavedHighScoreData();
        data.highScoreName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(data.highScoreName);



        SavedHighScoreData score = new SavedHighScoreData();
        score.highScoreNumber = mainManager.m_Points;

        string jsonScore = JsonUtility.ToJson(score);

        File.WriteAllText(Application.persistentDataPath + "/scoresavefile.json", jsonScore);
        Debug.Log(score.highScoreNumber);


    }

    public void LoadHighScore()
    {

        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        string path = Application.persistentDataPath + "/savefile.json";
        string scorePath = Application.persistentDataPath + "/scoresavefile.json";
        if (File.Exists(path) && File.Exists(scorePath))
        {

            // pull high score name
            string json = File.ReadAllText(path);
            SavedHighScoreData data = JsonUtility.FromJson<SavedHighScoreData>(json);

            //pull high score number
            string jsonScore = File.ReadAllText(scorePath);
            SavedHighScoreData score = JsonUtility.FromJson<SavedHighScoreData>(jsonScore);

            mainManager.highScoreText.text = data.highScoreName +": "+score.highScoreNumber;



           
        }
       
    }
    public void ReplaceHighScore()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        string scorePath = Application.persistentDataPath + "/scoresavefile.json";

        if (File.Exists(scorePath))
        {
            string jsonScore = File.ReadAllText(scorePath);
            SavedHighScoreData score = JsonUtility.FromJson<SavedHighScoreData>(jsonScore);

            if(mainManager.m_Points > score.highScoreNumber)
            {
                mainManager.saveHighScoreOption = true;
            }
        }
    }
}
