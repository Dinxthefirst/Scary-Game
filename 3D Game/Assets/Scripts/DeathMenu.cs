using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    public static bool playerIsDead;
    
    void Start()
    {
        playerIsDead = false;
        deathMenuUI.SetActive(false);
    }
    
    void Update()
    {
        if (playerIsDead)
        {
            deathMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public static void PlayerDied()
    {
        Time.timeScale = 0f;
        playerIsDead = true;
    }

    public void Restart()
    {
        deathMenuUI.SetActive(false);
        playerIsDead = false;
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
