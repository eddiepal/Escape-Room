using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class LetterBoxDisplay : MonoBehaviour
{
    public LetterBox letterBox;

    public Color letterTextColor;
    public Color defaultLetterBoxColor;
    public Color defaultLetterTextColor;

    private void Start()
    {
        letterTextColor = letterBox.letterTextColor;
        defaultLetterBoxColor = letterBox.defaultLetterBoxColor;
        defaultLetterTextColor = letterBox.defaultLetterTextColor;
    }
}
