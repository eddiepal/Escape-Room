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
    

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
         letterBoxesList = WordCreator.LetterBoxes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.WordMade == false)
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
                GameManager.instance.WordMade = true;
                questionText.text = "Well done!";
                if (PhotonNetwork.IsMasterClient)
                {
                    NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "MainMenu");
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