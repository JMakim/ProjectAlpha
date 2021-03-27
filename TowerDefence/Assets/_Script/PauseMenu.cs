using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public Canvas pauseMenuObj;
    public string PauseBind;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenuObj.gameObject.SetActive(false);
        Time.timeScale = 1;
        PauseBind = PlayerPrefs.GetString("PauseBind");
    }

    // Update is called once per frame
    void Update()
    {
        dpause();
       // PauseBind = PlayerPrefs.GetString("PauseBind");
    }

    public void pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenuObj.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isPaused)
        {
            isPaused = false;
            pauseMenuObj.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // keyboard debug
    public void dpause()
    {
        /*
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
        */
        if (Input.GetKeyDown("" + PauseBind) && !isPaused)
        {
            isPaused = true;
            pauseMenuObj.gameObject.SetActive(true);
            Time.timeScale = 0;
        } else if((Input.GetKeyDown("" + PauseBind) && isPaused)){
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
