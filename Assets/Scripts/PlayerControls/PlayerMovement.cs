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
    [SerializeField] FMODUnity.EventReference bumpFrontSound;
    [SerializeField] FMODUnity.EventReference bumpLeftSound;
    [SerializeField] FMODUnity.EventReference bumpRightSound;

    [SerializeField] GameEvent bumpFront;
    [SerializeField] GameEvent bumpLeft;
    [SerializeField] GameEvent bumpRight;
    private EventInstance footstepTrack;
    public EventInstance FootstepTrack
    {
        get { return footstepTrack; }
    }
    bool collided;
    bool pushLeft;
    bool pushRight;

    void Start()
    {
        footstepTrack = AudioManager.instance.CreateInstance(footstepsSound);
    }

    void Update()
    {
        float inputX = ProxInput.Move.x;
        float inputY = ProxInput.Move.y;

        Vector2 velocityVert = new Vector2(0, 0);
        Vector2 velocityHoriz = new Vector2(0, 0);
        Vector2 inputVelocityVert = new Vector2(0, 0);
        Vector2 inputVelocityHoriz = new Vector2(0, 0); 
        Vector2 pushVelocityVert = new Vector2(0, 0);
        Vector2 pushVelocityHoriz = new Vector2(0, 0);

        if (inputX != 0)
        {
            inputVelocityHoriz = transform.right * inputX;
        }
        if (inputY != 0)
        {
            inputVelocityVert = transform.up * inputY;
        }

        if (pushLeft)
        {
            pushVelocityHoriz -= (Vector2)transform.right * 0.1f;
        }
        if (pushRight)
        {
            pushVelocityHoriz += (Vector2)transform.right * 0.1f;
        }

        velocityVert = inputVelocityVert + pushVelocityVert;
        velocityHoriz = inputVelocityHoriz + pushVelocityHoriz;

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
            }
        }
        else
        {
            // footstepTrack.stop(STOP_MODE.ALLOWFADEOUT);
            footstepTrack.setParameterByName("Walking", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 playerFront = new Vector2(transform.position.x +
        transform.up.x * 0.1f, transform.position.y + transform.up.y * 0.1f);

        Vector2 pointA = new Vector2(playerFront.x - transform.position.x,
            playerFront.y - transform.position.y);
        Vector2 pointB = new Vector2(collision.contacts[0].point.x - transform.position.x,
            collision.contacts[0].point.y - transform.position.y);

        float angle = Vector2.SignedAngle(pointA, pointB);

        if (angle < 0 && angle > -180)
        {
            pushLeft = true;
            pushRight = false;
        }
        else if (angle > 0 && angle < 180)
        {
            pushRight = true;
            pushLeft = false;
        }

        // i hate this

        // if (angle < 45 && angle > -45)
        // {
        //     bumpFront.Raise();
        //     AudioManager.instance.PlayOneShot(bumpFrontSound, transform.position);
        // }
        // else if (angle <= -45 && angle >= -145)
        // {
        //     bumpRight.Raise();
        //     AudioManager.instance.PlayOneShot(bumpRightSound, transform.position);
        // }
        // else if (angle >= 45 && angle <= 145)
        // {
        //     bumpLeft.Raise();
        //     AudioManager.instance.PlayOneShot(bumpLeftSound, transform.position);
        // }
        // else
        // {
        //     bumpFront.Raise();
        //     AudioManager.instance.PlayOneShot(bumpFrontSound, transform.position);
        // }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
        pushLeft = false;
        pushRight = false;
    }

    void OnDisable()
    {
        footstepTrack.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
