using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DocumentView : MonoBehaviour
{
    [SerializeField] TimelineManager timeliner;
    [SerializeField] TimelineAsset timelineToPlay;
    [SerializeField] DocumentList documentList;
    [SerializeField] Button prevButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button backButton;
    [SerializeField] TextMeshProUGUI docNameText;

    GameObject scrollbar;
    string currentDocName;

    void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        RefreshView();
    }

    void RefreshView()
    {
        StartCoroutine(ShrinkScrollbar());

        nextButton.interactable = CanGetNextDocument();
        prevButton.interactable = CanGetPrevDocument();
    }

    public void SetUpDoc(DocumentData document)
    {
        if (transform.childCount != 4)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        if (!document.read)
            documentList.ReadDocument(document);

        GameObject newDoc = Instantiate(document.documentPrefab);
        newDoc.transform.SetParent(this.transform, false);
        newDoc.transform.SetAsFirstSibling();

        scrollbar = newDoc.transform.Find("Scrollbar").gameObject;

        currentDocName = document.documentPrefab.name;
        docNameText.text = currentDocName.Substring(3);

        backButton.onClick.AddListener(delegate
        {
            CloseDoc();
        });
    }

    public bool CanGetPrevDocument()
    {
        int currentDocIndex = documentList.GetDocumentIndex(currentDocName);

        // first two docs are map files, inaccessible
        if (currentDocIndex > 2)
        {
            int prevDocIndex = currentDocIndex - 1;
            DocumentData prevDoc = documentList.items[prevDocIndex];
            if (prevDoc.unlocked)
                return true;
        }

        return false;
    }

    public bool CanGetNextDocument()
    {
        int currentDocIndex = documentList.GetDocumentIndex(currentDocName);

        if (currentDocIndex < documentList.items.Count - 1)
        {
            int nextDocIndex = currentDocIndex + 1;
            DocumentData nextDoc = documentList.items[nextDocIndex];
            if (nextDoc.unlocked)
                return true;
        }

        return false;
    }

    public void PrevDocument()
    {
        EventSystem.current.SetSelectedGameObject(null);
        int currentDocIndex = documentList.GetDocumentIndex(currentDocName);

        if (!CanGetPrevDocument()) return;

        int prevDocIndex = currentDocIndex - 1;
        DocumentData prevDoc = documentList.items[prevDocIndex];

        SetUpDoc(prevDoc);
        RefreshView();
    }

    public void NextDocument()
    {
        EventSystem.current.SetSelectedGameObject(null);
        int currentDocIndex = documentList.GetDocumentIndex(currentDocName);

        if (!CanGetNextDocument()) return;

        int nextDocIndex = currentDocIndex + 1;
        DocumentData nextDoc = documentList.items[nextDocIndex];

        SetUpDoc(nextDoc);
        RefreshView();
    }

    public void CloseDoc()
    {
        timeliner.PlayTimeline(timelineToPlay);
    }

    IEnumerator ShrinkScrollbar()
    {
        yield return new WaitForSeconds(0.00001f);
        scrollbar.GetComponent<Scrollbar>().size = 0;
    }
}
