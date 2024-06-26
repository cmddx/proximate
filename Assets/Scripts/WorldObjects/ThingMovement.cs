using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMovement : MonoBehaviour
{
    [SerializeField] MovementGraph movementGraph;
    float time = 0;
    float movementInterval = 4;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= movementInterval)
        {
            time = 0.0f;

            GraphNode nextNode = movementGraph.ChooseNextNode();
            transform.localPosition = nextNode.transform.localPosition;
        }
    }
}
