using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DocumentListing : MonoBehaviour, IPointerEnterHandler, 
    IPointerExitHandler
{
    public TextMeshProUGUI nameText;
    public GameObject readDot;
    public GameObject selectionArrow;
    [SerializeField] FMODUnity.EventReference clackSound;

    public void Configure(string docName, bool read)
    {
        string nameWithoutID = docName.Substring(3);
        string[] splitFileType = nameWithoutID.Split('.');

        nameText.text = splitFileType[0] + "<color=#AAB516>." +
            splitFileType[1] + "</color>";

        readDot.SetActive(!read);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectionArrow.SetActive(true);
        PlayClack();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectionArrow.SetActive(false);
    }

    public void PlayClack()
    {
        AudioManager.instance.PlayOneShot(clackSound);
    }
}
