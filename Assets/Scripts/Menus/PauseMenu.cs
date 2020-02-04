using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gamePaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject instructionsPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hudPanel.SetActive(true);
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        hudPanel.SetActive(false);
        gamePaused = true;
    }

    public void OpenOptions()
    {
        pauseMenuUI.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void GoBack()
    {
        instructionsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
