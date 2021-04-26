using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject avoiderText;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject quitMidButton;
    public GameObject key;
    public Text keyText;

    // Start is called before the first frame update
    void Start()
    {
        quitMidButton.gameObject.SetActive(false);
        keyText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame() // on click
    {
        HideMainMenu();
    }

    public void QuitGame() // on click
    {
        ShowMainMenu();
    }

    public void ShowMainMenu() // but hide quit midway button
    {
        mainPanel.gameObject.SetActive(true);
        avoiderText.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        quitMidButton.gameObject.SetActive(false);
        keyText.gameObject.SetActive(false);

    }

    public void HideMainMenu() // but show quit midway button
    {
        mainPanel.gameObject.SetActive(false);
        avoiderText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        quitMidButton.gameObject.SetActive(true);
        keyText.gameObject.SetActive(true);
    }

    public void CompletelyGetOffGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
