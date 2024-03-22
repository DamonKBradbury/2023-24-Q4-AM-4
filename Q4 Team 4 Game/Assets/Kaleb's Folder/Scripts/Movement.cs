using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public float buildup = 1, jumpheight = 1, maxspeed = 1;
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Move the player to the left
        if (Input.GetKey(left))
        {
            rb2D.AddForce(Vector2.left * buildup);
        }

        //Move the player to the right
        if (Input.GetKey(right))
        {
            rb2D.AddForce(Vector2.right * buildup);
        }

        //Make the player jump
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed), rb2D.velocity.y);
    }
}
