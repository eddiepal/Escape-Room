using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Letter Box", menuName = "LetterBox")]
public class LetterBox : ScriptableObject
{
    public new string name;
    public Material defaultLetterBoxMaterial;
    public Color letterTextColor;
    public Color defaultLetterBoxColor;
    public Color defaultLetterTextColor;
    
    
}
