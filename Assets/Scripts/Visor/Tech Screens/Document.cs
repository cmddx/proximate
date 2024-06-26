using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Document : MonoBehaviour
{
    [SerializeField] GameObject content;

    public void FixContentPosition()
    {
        RectTransform rect = content.GetComponent<RectTransform>();

        int yAsOdd = Mathf.RoundToInt((rect.localPosition.y / 2)) * 2 + 1;

        rect.localPosition = new Vector3(rect.localPosition.x, yAsOdd,
            rect.localPosition.z);
    }

    void OnEnable()
    {
        StartCoroutine(UpdateLayouts(
            this.transform.Find("ScrollRect/Content").GetComponent<RectTransform>()
        ));
    }

    IEnumerator UpdateLayouts(RectTransform layouts)
    {
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(layouts);
    }
}




