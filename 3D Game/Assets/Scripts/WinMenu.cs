using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;

    public static bool playerHasWon;

    AudioManager audioManager;
    
    void Start()
    {
        playerHasWon = false;
        winMenuUI.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    void Update()
    {
        if (playerHasWon)
        {
            winMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PlayerWon()
    {
        Time.timeScale = 0f;
        audioManager.StopPlaying("Monster Scream");
        audioManager.StopPlaying("Monster Footsteps");
        playerHasWon = true;
    }

    public void Restart()
    {
        winMenuUI.SetActive(false);
        playerHasWon = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
