using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class WordCreator : MonoBehaviour
{
    [SerializeField] private String theWord = "Test";
    [SerializeField] private String letterBoxPrefab;
    [SerializeField] private GameObject[] letterSpawnPoint;

    [SerializeField] private static List<GameObject> _letterBoxes = new List<GameObject>();

    public string TheWord
    {
        get => theWord;
        set => theWord = value;
    }
    
    public static List<GameObject> LetterBoxes
    {
        get => _letterBoxes;
        set => _letterBoxes = value;
    }

    private void Start()
    {
        for (int i = 0; i < theWord.Length; i++)
        {
            GameManager.instance.LetterPlaced.Add(false);
            GameObject letterBox = PhotonNetwork.Instantiate(letterBoxPrefab, letterSpawnPoint[i].transform.position, letterSpawnPoint[i].transform.rotation);
            _letterBoxes.Add(letterBox);
        }

        for (int i = 0; i < letterSpawnPoint.Length; i++)
        {
            letterSpawnPoint[i].SetActive(false);
        }

        for (int i = 0; i < _letterBoxes.Count; i++)
        {
            _letterBoxes[i].name = "LetterBox" + theWord[i];
            _letterBoxes[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = theWord[i].ToString();
        }

        
    }
}
