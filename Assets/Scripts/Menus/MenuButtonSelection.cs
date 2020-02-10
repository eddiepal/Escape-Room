using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonSelection : MonoBehaviour
{
    public GameObject firstSelection;

    void Start()
    {
        if(firstSelection.GetComponent<Button>())
            firstSelection.GetComponent<Button>().Select();
        else if (firstSelection.GetComponent<TMP_InputField>())
        {
            Debug.Log("True, input field is tesh mesh pro too");
            firstSelection.GetComponent<TMP_InputField>().Select();
        }

        
    }
}
