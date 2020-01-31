using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PressurePlate : MonoBehaviourPun
{
    

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.name);
        Debug.Log(other.gameObject.name);

        if (gameObject.name == "PPM" && other.gameObject.name == "LetterBox M")
            GameManager.instance.LettersPlacedCorrectly += 1;
        if (gameObject.name == "PPA" && other.gameObject.name == "LetterBox A")
            GameManager.instance.LettersPlacedCorrectly += 1;
        if (gameObject.name == "PPT" && other.gameObject.name == "LetterBox T")
            GameManager.instance.LettersPlacedCorrectly += 1;
        if (gameObject.name == "PPH" && other.gameObject.name == "LetterBox H")
            GameManager.instance.LettersPlacedCorrectly += 1;
        if (gameObject.name == "PPS" && other.gameObject.name == "LetterBox S")
            GameManager.instance.LettersPlacedCorrectly += 1;
        
        Debug.Log(GameManager.instance.LettersPlacedCorrectly);
        if (GameManager.instance.LettersPlacedCorrectly >= 5)
        {
            Debug.Log("In if statement");
            gameObject.SetActive(false);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (gameObject.name == "PPM" && other.gameObject.name == "LetterBox M")
        {
            Debug.Log("in ppm if statment");
            GameManager.instance.LettersPlacedCorrectly -= 1;
        }
        if (gameObject.name == "PPA" && other.gameObject.name == "LetterBox A")
            GameManager.instance.LettersPlacedCorrectly -= 1;
        if (gameObject.name == "PPT" && other.gameObject.name == "LetterBox T")
            GameManager.instance.LettersPlacedCorrectly -= 1;
        if (gameObject.name == "PPH" && other.gameObject.name == "LetterBox H")
            GameManager.instance.LettersPlacedCorrectly -= 1;
        if (gameObject.name == "PPS" && other.gameObject.name == "LetterBox S")
            GameManager.instance.LettersPlacedCorrectly -= 1;
    }
}
