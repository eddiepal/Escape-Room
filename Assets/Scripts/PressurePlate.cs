using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PressurePlate : MonoBehaviourPun
{
    

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(GameManager.instance.LetterPlaced[0]);

        if (gameObject.name == "PPM" && other.gameObject.name == "LetterBox M")
            GameManager.instance.LetterPlaced[0] = true;
        if (gameObject.name == "PPA" && other.gameObject.name == "LetterBox A")
            GameManager.instance.LetterPlaced[1] = true;
        if (gameObject.name == "PPT" && other.gameObject.name == "LetterBox T")
            GameManager.instance.LetterPlaced[2] = true;
        if (gameObject.name == "PPH" && other.gameObject.name == "LetterBox H")
            GameManager.instance.LetterPlaced[3] = true;
        if (gameObject.name == "PPS" && other.gameObject.name == "LetterBox S")
            GameManager.instance.LetterPlaced[4] = true;
        
        Debug.Log(GameManager.instance.LettersPlacedCorrectly);
        if (AllLettersPlaced())
        {
            gameObject.SetActive(false);
        }
    }
    
    private bool AllLettersPlaced() {
        return GameManager.instance.LetterPlaced.All(x => x);
    }

}
