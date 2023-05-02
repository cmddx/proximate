using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Camera cam;

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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("collision");
    }

}
