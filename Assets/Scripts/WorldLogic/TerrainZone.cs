using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class TerrainZone : MonoBehaviour
{
    public PlayerMovement playerMovement;

    // 0 - metal
    // 1 - concrete
    // 2 - gore
    // 3 - tiles
    // 4 - carpet
    // 5 - glass
    // 6 - vents

    public int terrainType;

    void OnTriggerEnter2D()
    {
        playerMovement.FootstepTrack.setParameterByName("Terrain", terrainType);
        playerMovement.FootstepTrack.start();
    }
}
