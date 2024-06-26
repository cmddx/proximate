using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Camera cam;
    [SerializeField] FMODUnity.EventReference footstepsSound;
    private EventInstance footstepTrack;
    public EventInstance FootstepTrack
    {
        get { return footstepTrack; }
    }
    bool collided;
    bool walking;

    void Start()
    {
        footstepTrack = AudioManager.instance.CreateInstance(footstepsSound);
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 velocityVert = new Vector2(0, 0);
        Vector2 velocityHoriz = new Vector2(0, 0);

        if (inputX != 0)
        {
            velocityHoriz = transform.right * inputX;
        }
        if (inputY != 0)
        {
            velocityVert = transform.up * inputY;
        }

        rigidBody.velocity = (velocityHoriz + velocityVert) * speed;
        cam.transform.position = new Vector3(transform.position.x,
            transform.position.y, -10);

        if (rigidBody.velocity.magnitude > 0 && !collided)
        {
            PLAYBACK_STATE playbackState;
            footstepTrack.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                footstepTrack.start();
                footstepTrack.setParameterByName("Walking", 1);
                walking = true;
            }
        }
        else
        {
            // footstepTrack.stop(STOP_MODE.ALLOWFADEOUT);
            footstepTrack.setParameterByName("Walking", 0);
            walking = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    void OnDisable()
    {
        footstepTrack.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
