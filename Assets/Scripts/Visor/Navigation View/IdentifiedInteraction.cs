using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class IdentifiedInteraction : MonoBehaviour
{
    public DynamicString interaction;
    public TextMeshProUGUI interactionText;
    public Color disabledColor;
    public Color interactableColor;


    public void UpdateInteractionText()
    {
        if (interaction.Value == "")
        {
            interactionText.text = "";
            return;
        }

        string interactionString;
        string[] interactionArray = interaction.Value.Split(":");

        if (interactionArray[0] == "error")
        {
            interactionString = interactionArray[1];
            interactionText.color = disabledColor;
        }
        else
        {
            interactionString = interactionArray[0];
            interactionText.color = interactableColor;
        }

        interactionString = "[ " + interactionString + " ]";
        
        interactionText.text = interactionString;
    }
}
