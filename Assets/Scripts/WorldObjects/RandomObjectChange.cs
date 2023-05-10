using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldObject))]
public class RandomObjectChange : MonoBehaviour
{
    [SerializeField] string newName;
    [SerializeField] float newMinConfidence;
    [SerializeField] float newMaxConfidence;
    [SerializeField] float probability;
    [SerializeField] float duration;
    [SerializeField] bool disableAfter;
    [SerializeField] List<RandomObjectChange> sisters;



    WorldObject worldObject;
    string defaultName;
    float defaultMinConfidence;
    float defaultMaxConfidence;
    float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        worldObject = GetComponent<WorldObject>();
        defaultName = worldObject.visorName;
        defaultMinConfidence = worldObject.minConfidence;
        defaultMaxConfidence = worldObject.maxConfidence;
    }

    // Update is called once per frame
    void Update()
    {
        if (worldObject.BeingSeen)
        {
            timePassed += Time.deltaTime;

            Debug.Log("Time: " + timePassed);

            if (timePassed > 0.2f)
            {
                timePassed = 0;

                if (worldObject.visorName != defaultName)
                {
                    worldObject.visorName = defaultName;
                    worldObject.minConfidence = defaultMinConfidence;
                    worldObject.maxConfidence = defaultMaxConfidence;
                    if(disableAfter) this.enabled = false;
                    foreach (RandomObjectChange sister in sisters)
                    {
                        sister.enabled = false;
                    }
                }
                
                float randomNum = Random.Range(0, 100);
                if (probability >= randomNum)
                {
                    worldObject.visorName = newName;
                    worldObject.minConfidence = newMinConfidence;
                    worldObject.maxConfidence = newMaxConfidence;

                    timePassed -= duration;
                }
            }
        }
    }
}
