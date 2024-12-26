using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] RenderTexture rendTex;
    // Start is called before the first frame update
    void Start()
    {
        // resolution is natively 1920x1080, but if the player has
        // a HD monitor then we should double it
        if (Screen.currentResolution.width == 3840 &&
            Screen.currentResolution.height == 2160)
        {

            Screen.SetResolution(3840, 2160, true);
            Resize(rendTex, 3840, 2160);
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
            Resize(rendTex, 1920, 1080);
        }

        Application.targetFrameRate = 60; 
    }

    void Resize(RenderTexture renderTexture, int width, int height)
    {
        if (renderTexture)
        {
            renderTexture.Release();
            renderTexture.width = width;
            renderTexture.height = height;
        }
    }
}
