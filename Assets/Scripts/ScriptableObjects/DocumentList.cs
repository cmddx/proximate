using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Document List")]
public class DocumentList : ItemList<DocumentData>
{
    public new DocumentData FindItemFromReferenceName(string referenceName)
    {
        foreach (DocumentData documentData in items)
        {
            GameObject document = documentData.documentPrefab;

            if (referenceName.ToLower() == document.name.ToLower())
                return documentData;
        }

        Debug.Log("Failed to find item: " + referenceName);
        return default;
    }

    public void ReadDocument(DocumentData document)
    {
        document.read = true;
    }

    public List<DocumentData> DocumentsToUpload()
    {
        List<DocumentData> returnedDocs = new List<DocumentData>();
		
        foreach (DocumentData documentData in items)
        {
            if (Random.Range(0,100) <= 10 || documentData.unlocked && !documentData.uploaded)
                returnedDocs.Add(documentData);
        }

        return returnedDocs;
    }

    public int GetDocumentIndex(string referenceName)
    {
        int index = 0;

        foreach (DocumentData documentData in items)
        {
            GameObject document = documentData.documentPrefab;

            if (referenceName.ToLower() == document.name.ToLower())
                return index;
            
            index++;
        }

        return index;
    }
}

[System.Serializable]
public class DocumentData
{
    public GameObject documentPrefab;
    public bool unlocked;
    public bool uploaded;
    public bool read;
}