using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGraph : MonoBehaviour
{
    [SerializeField] List<GameObject> nodes;
    GraphNode currentNode;
    GraphNode lastNode;
    GraphNode secondLastNode;

    void Start()
    {
        currentNode = nodes[0].GetComponent<GraphNode>();
    }

    public GraphNode ChooseNextNode()
    {
        GraphNode nextNode;

        List<GraphNode> potentialNextNodes = new List<GraphNode>();

        foreach (GameObject node in currentNode.neighours)
        {
            if (node.GetComponent<GraphNode>() != lastNode && 
                node.GetComponent<GraphNode>() != secondLastNode)
            {
                potentialNextNodes.Add(node.GetComponent<GraphNode>());
            }
        }

        // Debug.Log("Current node: " + currentNode);
        // Debug.Log("Last node: " + lastNode);
        // Debug.Log("Second last node: " + secondLastNode);

        int randomNum = Random.Range(0, potentialNextNodes.Count);

        nextNode = potentialNextNodes[randomNum];

        secondLastNode = lastNode;
        lastNode = currentNode;
        currentNode = nextNode;

        // Debug.Log("--------------");

        return nextNode;
    }

}
