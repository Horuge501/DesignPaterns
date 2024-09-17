using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fighter", menuName = "Character")]
public class CharacterSO : ScriptableObject
{
    public Sprite sprite;
    public new string name;
    public string race;
}
