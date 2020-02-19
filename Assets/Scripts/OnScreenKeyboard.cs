using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnScreenKeyboard : MonoBehaviour
{
    public static OnScreenKeyboard instance;
    private static String keyText;

    private void Start()
    {
        instance = this;
    }
    
    public void KeyWasPressed(Transform textTransform)
    {
        keyText = textTransform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        Debug.Log(EventSystem.current.currentSelectedGameObject.name); 
        Debug.Log(Menu.instance.SelectedInputField.text);
        Menu.instance.SelectedInputField.text += keyText;
    }
}
