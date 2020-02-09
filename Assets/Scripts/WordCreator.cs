using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class WordCreator : MonoBehaviourPun
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
        CreateWord();
    }
    
    private void CreateWord()
    {

        for (int i = 0; i < theWord.Length; i++)
        {
            GameManager.instance.LetterPlaced.Add(false);
            
            if (!PhotonNetwork.IsMasterClient)
            {
                GameObject letterBox = PhotonNetwork.Instantiate(letterBoxPrefab, letterSpawnPoint[i].transform.position,
                    letterSpawnPoint[i].transform.rotation);
                photonView.RPC("AddToList", RpcTarget.All, letterBox.GetPhotonView().ViewID);
            }
           
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
        
        testme();
    }
    
    [PunRPC]
    public void AddToList(int viewId)
    {
        Debug.Log(_letterBoxes.Count + ": on" + PhotonNetwork.LocalPlayer.NickName + "s game.");
        GameObject tempHold = PhotonView.Find(viewId).gameObject;
        _letterBoxes.Add(tempHold);
        testme();
    }

    public void testme()
    {
        for (int i = 0; i < _letterBoxes.Count; i++)
        {
            _letterBoxes[i].name = "LetterBox" + theWord[i];
            _letterBoxes[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = theWord[i].ToString();
        }
    }
}
