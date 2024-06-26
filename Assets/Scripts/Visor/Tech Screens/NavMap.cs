using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMap : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] RectTransform playerMarker;
    [SerializeField] GameObject emptyMap;
    [SerializeField] GameObject downloadedMap;
    [SerializeField] ConditionList conditionList;
    [SerializeField] List<MapMarker> gameMapMarkers;
    [SerializeField] List<MapMarker> drawnMapMarkers;
    [SerializeField] GameObject mapImage;
    [SerializeField] GameObject deletedMap;


    [System.Serializable]
    struct MapMarker
    {
        public string zoneName;
        public Transform markers;
        public Transform BottomLeft { get => markers.GetChild(0); }
        public Transform BottomRight { get => markers.GetChild(1); }
        public Transform TopLeft { get => markers.GetChild(2); }
        public Transform TopRight { get => markers.GetChild(3); }

    }

    MapMarker currentGameZone;
    MapMarker currentDrawnZone;


    void OnEnable()
    {
        ConditionData condition = conditionList.
            FindItemFromReferenceName("mapDownloaded");
        if (condition.value == 1)
        {
            emptyMap.SetActive(false);
            downloadedMap.SetActive(true);
            FindPlayerPositionOnMap();
        }
        else
        {
            emptyMap.SetActive(true);
            downloadedMap.SetActive(false);
        }
    }

    public void SetNewMapZone(string _zoneName)
    {
        foreach (MapMarker mapMarker in gameMapMarkers)
        {
            if (mapMarker.zoneName == _zoneName)
            {
                currentGameZone = mapMarker;
                break;
            }
        }

        foreach (MapMarker mapMarker in drawnMapMarkers)
        {
            if (mapMarker.zoneName == _zoneName)
            {
                currentDrawnZone = mapMarker;
                break;
            }
        }
    }

    void FindPlayerPositionOnMap()
    {
        float playerRatioX = Mathf.InverseLerp(currentGameZone.BottomLeft.position.x,
            currentGameZone.BottomRight.position.x, player.position.x);
        float playerRatioY = Mathf.InverseLerp(currentGameZone.BottomLeft.position.y,
            currentGameZone.TopLeft.position.y, player.position.y);

        float mapMarkerX = Mathf.Lerp(currentDrawnZone.BottomLeft.position.x,
            currentDrawnZone.BottomRight.position.x, playerRatioX);
        float mapMarkerY = Mathf.Lerp(currentDrawnZone.BottomLeft.position.y,
            currentDrawnZone.TopLeft.position.y, playerRatioY);

        playerMarker.position = new Vector3(mapMarkerX, mapMarkerY, 0);

        playerMarker.localRotation = player.rotation;
    }

    public void DeleteMap()
    {
        mapImage.SetActive(false);
        deletedMap.SetActive(true);
    }
}
