using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviourPun
{
    // Start is called before the first frame update
    public static bool gamePaused = false;

    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject leaveConfirmationPanel;
    
    private Vector2 movementInput;
    private Button firstButton;
    
    void Update()
    {
        if (PlayerInput.playerInput.controls.PauseMenu.PauseGame.triggered)
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInput.playerInput.EnablePlayerControls();
        pauseMenuPanel.SetActive(false);
        hudPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        gamePaused = false;
    }

    void Pause()
    {
        PlayerInput.playerInput.DisablePlayerControls();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;;
        hudPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        SelectButton(pauseMenuPanel);
        gamePaused = true;
    }

    public void OpenOptions()
    {
        pauseMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        SelectButton(instructionsPanel);
    }

    public void GoBack()
    {
        instructionsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        SelectButton(pauseMenuPanel);
    }

    public void QuitGame()
    {
        pauseMenuPanel.SetActive(false);
        leaveConfirmationPanel.SetActive(true);
        SelectButton(leaveConfirmationPanel);
    }

    public void SelectButton(GameObject screen)
    {
        firstButton = screen.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        firstButton.Select();
    }

    public void LeaveConfirmed(bool confirmed)
    {
        if (confirmed)
        {
            //gamePaused = true;
            StartCoroutine(NetworkManager.instance.DisconnectPhoton("MainMenu"));
        }
        else
        {
            leaveConfirmationPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
            SelectButton(pauseMenuPanel);
        }
    }
}
