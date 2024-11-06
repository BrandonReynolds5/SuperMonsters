using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterModels;   // Array of character models (3D) or images (2D)
    public Image characterImage;           // Reference for 2D Image component
    public Text characterNameText;         // Text component for the character's name
    public Text characterDetailsText;      // Text component for additional details

    private int currentIndex = 0;

    void Start()
    {
        UpdateCharacterDisplay();
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characterModels.Length;
        UpdateCharacterDisplay();
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + characterModels.Length) % characterModels.Length;
        UpdateCharacterDisplay();
    }

    void UpdateCharacterDisplay()
    {
        // Show or hide character models if using 3D models
        for (int i = 0; i < characterModels.Length; i++)
        {
            characterModels[i].SetActive(i == currentIndex);
        }

        // Update 2D Image display if using character icons
        if (characterImage != null)
        {
            characterImage.sprite = characterModels[currentIndex].GetComponent<Image>().sprite;
        }

        // Update text with character details
        characterNameText.text = "Character " + (currentIndex + 1);
        characterDetailsText.text = "Details for character " + (currentIndex + 1);
    }
}

