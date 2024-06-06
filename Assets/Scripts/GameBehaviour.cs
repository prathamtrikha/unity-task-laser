using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{

    public static GameBehaviour Instance { get; private set; }

   //reference for win and lose screen
   public GameObject WinScreenObject;
   public GameObject LoseScreenObject;
   public GameObject LoadingScreenObject;

   [SerializeField] private GameObject crownObject;
   

    //UIPpop Up animation 
    public float animationDuration = 2f; // Duration of the popup animation
    public float initialScale = 0.0f; // The initial scale of the UI element (e.g., completely shrunk)
    public float targetScale = 1.0f; // The final scale of the UI element (e.g., normal size)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        LoadingScreenObject.SetActive(true);
        WinScreenObject.SetActive(false);
        LoseScreenObject.SetActive(false);
        StartCoroutine(HideLoadingScreen());
    }

    //Coroutine for hiding the loading screen
    private IEnumerator HideLoadingScreen(){
        yield return new WaitForSeconds(2f);
        LoadingScreenObject.SetActive(false);
    }

    //Show WinScreen
    public void ShowWinScreen() {
        StartCoroutine(StopAll());
        WinScreenObject.SetActive(true);
        AudioManager.instance.StopBGMusic();
        AudioManager.instance.ResultPlayWinSound();
    }

    //Show LoseScreen
    public void ShowLoseScreen() {
        StartCoroutine(StopAll());
        LoseScreenObject.SetActive(true);
        AudioManager.instance.StopBGMusic();
        AudioManager.instance.ResultPlayLoseSound();
    }

    //Showing Crown after all the waves
    public void ShowCrownObject() {
        crownObject.SetActive(true);
    }

    private IEnumerator StopAll(){
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
    }

    public void OnRestartButtonPressed()
    {
       // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene by its name
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1.0f;
    }

    public void OnMenuButtonPressed()
    {
        // Switch the current scene to StartMenu
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1.0f;
    }
    
}
