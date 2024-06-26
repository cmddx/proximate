using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DocumentsList : MonoBehaviour
{
    public DocumentList documentList;
    public GameObject listingPrefab;
    public GameObject container;
    public DocumentView documentView;
    public GameObject scrollbar;

    [SerializeField] TimelineManager timeliner;
    [SerializeField] TimelineAsset listToDoc;
    [SerializeField] TimelineAsset listToConsole;


    void Start()
    {
        ShowListings();
    }

    void OnEnable()
    {
        ShowListings();
        scrollbar.GetComponent<Scrollbar>().size = 0;
        StartCoroutine(ShrinkScrollbar());
    }

    void ShowListings()
    {
        ClearListing();

        foreach (DocumentData documentData in documentList.items)
        {
            if (!documentData.unlocked) continue;

            GameObject document = documentData.documentPrefab;

            GameObject newListing = Instantiate(listingPrefab);

            newListing.GetComponent<DocumentListing>().Configure(
                document.name, documentData.read);

            newListing.transform.SetParent(container.transform, false);

            newListing.GetComponent<Button>().onClick.AddListener(delegate
            {
                OpenDoc(document.name);
            });
        }
    }

    void ClearListing()
    {
        List<GameObject> listingsToClear = new List<GameObject>();

        foreach (Transform child in container.transform)
        {
            listingsToClear.Add(child.gameObject);
        }

        foreach (GameObject listing in listingsToClear)
        {
            Destroy(listing);
        }
    }

    public void OpenDoc(string docName)
    {
        DocumentData document = documentList.FindItemFromReferenceName(docName);

        documentView.SetUpDoc(document);

        timeliner.PlayTimeline(listToDoc);
    }

    public void BackToConsole()
    {
        timeliner.PlayTimeline(listToConsole);
    }

    IEnumerator ShrinkScrollbar()
    {
        yield return new WaitForSeconds(0.0001f);
        scrollbar.GetComponent<Scrollbar>().size = 0;
    }
}
