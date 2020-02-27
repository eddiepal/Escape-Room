using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;

// unity engine.Experimental.PlayerLoop;

public class PressurePlate : MonoBehaviourPun
{
    [SerializeField] private TextMeshPro questionText;
    
    public Material[] material;
    private Renderer rend;
    private List<GameObject> letterBoxesList;
    [SerializeField] private List<GameObject> pressurePlates;

    [SerializeField] private WordCreator wordCreatorScript;
    private bool wordMade = false;
    
    
    [Header("Object References")]
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;
    private GameManager _gameManager;


    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        letterBoxesList = wordCreatorScript.LetterBoxes;
    }

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wordMade == false)
        {
            if (other.gameObject.CompareTag("LetterBox"))
            {
                rend.sharedMaterial = material[1];
            }

            for (int i = 0; i < letterBoxesList.Count; i++)
            {
                if (gameObject.name == pressurePlates[i].name && other.gameObject.name == letterBoxesList[i].name)
                {
                    GameManager.instance.LetterPlaced[i] = true;
                }
            }

            if (AllLettersPlaced())
            {
                Debug.Log("In all letters placed method.");
                wordMade = true;
                door.GetComponent<DoorOperation>().OpenDoor();
                player.GetComponent<SelectionManager>().ChangeTag();
                questionText.text = "Well done!";
                if (PhotonNetwork.IsMasterClient)
                {
                    StartCoroutine(NetworkManager.instance.DisconnectPhoton("MainMenu"));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LetterBox"))
        {
            rend.sharedMaterial = material[0];
        }
        
        for (int i = 0; i < letterBoxesList.Count; i++)
        {
            if (gameObject.name == pressurePlates[i].name && other.gameObject.name == letterBoxesList[i].name)
            {
                GameManager.instance.LetterPlaced[i] = false;
            }
        }
    }

    private bool AllLettersPlaced()
    {
        return GameManager.instance.LetterPlaced.All(x => x);
    }
}