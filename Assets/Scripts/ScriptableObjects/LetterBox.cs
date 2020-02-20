using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Letter Box", menuName = "LetterBox")]
public class LetterBox : ScriptableObject
{
    public new string name;
    public Material defaultMaterial;
    public Color textColor;
}
