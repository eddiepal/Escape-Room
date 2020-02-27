using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class WordCreator : MonoBehaviourPun
{
    [Header("Word Details")]
    [SerializeField] private String theWord = "Test";
    [SerializeField] private String letterBoxPrefab;
    [SerializeField] private GameObject[] letterSpawnPoint;
    [SerializeField] private List<GameObject> _letterBoxes = new List<GameObject>();

    public string TheWord
    {
        get => theWord;
        set => theWord = value;
    }
    
    public List<GameObject> LetterBoxes
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
            
            if (PhotonNetwork.IsMasterClient)
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
        
        SetUpLetterBox();
    }
    
    [PunRPC]
    public void AddToList(int viewId)
    {
        GameObject tempHold = PhotonView.Find(viewId).gameObject;
        _letterBoxes.Add(tempHold);
        if (_letterBoxes != null)
        {
            SetUpLetterBox();
        }
    }

    public void SetUpLetterBox()
    {
        for (int i = 0; i < _letterBoxes.Count; i++)
        {
            _letterBoxes[i].name = "LetterBox" + theWord[i];
            _letterBoxes[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = theWord[i].ToString();
        }
    }
}
