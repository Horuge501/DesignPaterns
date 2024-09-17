using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public CharacterSO characterSOData;

    private Image characterSprite;
    private Text characterName;
    private Text characterRace;

    private void Awake() 
    {
        characterSprite = transform.Find("Sprite").GetComponent<Image>();
        characterName = transform.Find("Name").GetComponent<Text>();
        characterRace = transform.Find("Race").GetComponent<Text>();

        characterSprite.sprite = characterSOData.sprite;
        characterName.text = characterSOData.name;
        characterRace.text = characterSOData.race;
    }
}
