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

    private PlayerInputActions inputAction;
    private Vector2 movementInput;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.playerInput.controls.PauseMenu.PauseGame.triggered)
        {
            if (gamePaused)
            {
                PlayerInput.playerInput.EnablePlayerControls();
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
               
                
            }
            else
            {
                PlayerInput.playerInput.DisablePlayerControls();
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
    }

    public void Resume()
    {
        PlayerInput.playerInput.EnablePlayerControls();
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
