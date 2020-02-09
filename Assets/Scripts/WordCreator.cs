using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class WordCreator : MonoBehaviour
{
    [SerializeField] private String theWord = "Test";

    public string TheWord
    {
        get => theWord;
        set => theWord = value;
    }
    
    public List<GameObject> LetterBoxes
    {
        get => letterBoxes;
        set => letterBoxes = value;
    }

    [SerializeField] private GameObject letterBoxPrefab;
    [SerializeField] private Transform[] letterSpawnPoint;

    [SerializeField] private List<GameObject> letterBoxes;



    private void Start()
    {
        for (int i = 0; i < theWord.Length; i++)
        {
            GameObject letterBox = Instantiate(letterBoxPrefab, letterSpawnPoint[i].position, letterSpawnPoint[i].rotation);
            letterBoxes.Add(letterBox);
        }
        
        for (int i = 0; i < letterBoxes.Count; i++)
        {
            letterBoxes[i].name = "LetterBox" + theWord[i];
            letterBoxes[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = theWord[i].ToString();
        }
    }
}
