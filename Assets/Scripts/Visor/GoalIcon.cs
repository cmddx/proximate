using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIcon : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GoalObjects> goalObjects;
    [SerializeField] List<RectTransform> icons;
    [SerializeField] List<RectTransform> iconPivots;
    [SerializeField] int maxIconDistance;
    [SerializeField] int minIconDistance;
    List<GameObject> currentGoals;

	void Start()
	{
		currentGoals = new List<GameObject>();
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < currentGoals.Count; i++)
        {
            if (!iconPivots[i].gameObject.activeInHierarchy)
                iconPivots[i].gameObject.SetActive(true);

            Vector3 distanceVector = player.position -
                currentGoals[i].transform.position;

            float dx = distanceVector.x;
            float dy = distanceVector.y;

            float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg - 90;

            angle += -player.eulerAngles.z;

            float maxCompassDistance = 1.3f;
            float minCompassDistance = 0.03f;

            if (distanceVector.magnitude >= maxCompassDistance)
            {
                icons[i].localPosition = new Vector3(icons[i].localPosition.x,
                maxIconDistance, icons[i].localPosition.z);
            }
            else if (distanceVector.magnitude <= minCompassDistance)
            {
                icons[i].localPosition = new Vector3(icons[i].localPosition.x,
                maxIconDistance, icons[i].localPosition.z);
            }
            else
            {
                float distanceRatio = Mathf.InverseLerp(maxCompassDistance,
                    minCompassDistance, distanceVector.magnitude);
                float iconPositionY = Mathf.Lerp(maxIconDistance, minIconDistance,
                    distanceRatio);

                icons[i].localPosition = new Vector3(icons[i].localPosition.x,
                iconPositionY, icons[i].localPosition.z);
            }

            iconPivots[i].transform.eulerAngles = new Vector3(0, 0, angle);
            icons[i].localEulerAngles = new Vector3(0, 0, -angle);
        }
    }

    public void SetCurrentGoals(int progressIndex)
    {
		if (goalObjects.Count <= progressIndex) 
		{
			Debug.LogWarning("Index was out of range.");
			return;
		}
		
        currentGoals = goalObjects[progressIndex].list;

        for (int i = 0; i < currentGoals.Count; i++)
        {
            icons[i].gameObject.SetActive(true);
        }
    }

    public void RemoveGoal(GameObject goalToRemove)
    {
        for (int i = 0; i < currentGoals.Count; i++)
        {
            if (currentGoals[i] == goalToRemove)
            {
                icons[i].gameObject.SetActive(false);
            }
        }
    }
}



[System.Serializable]
public class GoalObjects
{
    public List<GameObject> list;
}
