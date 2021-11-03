using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class DisplayHighScore : MonoBehaviour
{

    [SerializeField] SavedData savedData;
    public TextMeshProUGUI highScoreName;
    public TextMeshProUGUI highScoreFigure;


    // Start is called before the first frame update
    void Start()
    {
        savedData = GameObject.Find("Saved Data").GetComponent<SavedData>();
        savedData.DisplayHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
