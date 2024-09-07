using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    float startingZ;
    [SerializeField] float endingZ = 1f;
    [SerializeField] float movementTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        startingZ = transform.position.z;

        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSeconds()
    {
        float elapsedTime = 0;

        while (elapsedTime < movementTime)
        {
            float newZ = Mathf.Lerp(startingZ, endingZ, elapsedTime /
            movementTime);

            transform.position = new Vector3(transform.position.x,
                transform.position.y, newZ);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = new Vector3(transform.position.x,
                transform.position.y, endingZ);

        FMOD.Studio.Bus bus = RuntimeManager.GetBus("bus:/Pod");
        bus.setMute(true);
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
