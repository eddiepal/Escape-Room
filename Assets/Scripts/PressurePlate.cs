﻿using System;
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

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0]; 
        letterBoxesList = GetComponent<WordCreator>().LetterBoxes;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (GameManager.instance.WordMade == false)
        {
            if (other.gameObject.CompareTag("LetterBox"))
            {
                Debug.Log("In OnCollisionEnter if statement");
                rend.sharedMaterial = material[1];
            }
            
            if (gameObject.name == "PPM" && other.gameObject.name == letterBoxesList[0].name)
            {
                GameManager.instance.LetterPlaced[0] = true;
            }

            if (gameObject.name == "PPA" && other.gameObject.name == letterBoxesList[1].name)
            {
                GameManager.instance.LetterPlaced[1] = true;
            }

            if (gameObject.name == "PPT" && other.gameObject.name == letterBoxesList[2].name)
            {
                GameManager.instance.LetterPlaced[2] = true;
            }

            if (gameObject.name == "PPH" && other.gameObject.name == letterBoxesList[3].name)
            {
                GameManager.instance.LetterPlaced[3] = true;
            }

            if (gameObject.name == "PPS" && other.gameObject.name == letterBoxesList[4].name)
            {
                GameManager.instance.LetterPlaced[4] = true;
            }

            if (AllLettersPlaced())
            {
                GameManager.instance.WordMade = true;
                questionText.text = "Well done!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LetterBox"))
        {
            rend.sharedMaterial = material[0];
        }
        
        if (gameObject.name == "PPM" && gameObject.name == "LetterBox M")
            GameManager.instance.LetterPlaced[0] = false;
        if (other.gameObject.name == "LetterBox A")
            GameManager.instance.LetterPlaced[1] = false;
        if (other.gameObject.name == "LetterBox T")
            GameManager.instance.LetterPlaced[2] = false;
        if (other.gameObject.name == "LetterBox H")
            GameManager.instance.LetterPlaced[3] = false;
        if (other.gameObject.name == "LetterBox S")
            GameManager.instance.LetterPlaced[4] = false;
    }

    private bool AllLettersPlaced()
    {
        return GameManager.instance.LetterPlaced.All(x => x);
    }
}