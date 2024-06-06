using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject playBtn;
    public GameObject QuitBtn;

    private void Start() {
        StartCoroutine(EnableButtons());
    }

    private IEnumerator EnableButtons(){
        yield return new WaitForSeconds(0.4f);
        playBtn.SetActive(true);
        QuitBtn.SetActive(true);
    }

    //functions to handle different button press
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("GameLevel");
    }

    
    public void OnQuitButtonPressed()
    {
        //Debug.Log("GameQuit");
        Application.Quit();
    }
}
