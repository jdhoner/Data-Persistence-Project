using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject nameMenu;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button beginGameButton;

    [SerializeField] SavedData savedData;

    // Start is called before the first frame update
    void Start()
    {
        nameMenu.SetActive(false);
        startMenu.SetActive(true);
        savedData = GameObject.Find("Saved Data").GetComponent<SavedData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchMenu()
    {
        if (startMenu.activeInHierarchy)
        {
            startMenu.SetActive(false);
            nameMenu.SetActive(true);
        }
        else
        {
            startMenu.SetActive(true);
            nameMenu.SetActive(false);
        }
    }

    public void SaveName()
    {
        savedData.playerName = nameInput.text;
        Debug.Log(nameInput.text);
        beginGameButton.gameObject.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);

    }
}
