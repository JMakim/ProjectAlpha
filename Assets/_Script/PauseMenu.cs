using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public Canvas pauseMenuObj;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenuObj.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    public void pause()
    {
        if(Input.GetKeyUp(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            pauseMenuObj.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyUp(KeyCode.P) && isPaused)
        {
            isPaused = false;
            pauseMenuObj.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void restart()
    {
        SceneManager.LoadScene("MainGameplay");
    }
}
