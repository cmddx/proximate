using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{
    [SerializeField] NavMap navMap;
    [SerializeField] string zoneName;

    public void ChangeZone()
    {
        navMap.SetNewMapZone(zoneName);
    }
}
