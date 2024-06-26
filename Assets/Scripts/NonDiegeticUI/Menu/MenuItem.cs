using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerEnterHandler,
    IPointerExitHandler
{
    public GameObject selectionArrow;
    [SerializeField] FMODUnity.EventReference clackSound;

    // Start is called before the first frame update
    void OnDisable()
    {
        selectionArrow.SetActive(false);
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
