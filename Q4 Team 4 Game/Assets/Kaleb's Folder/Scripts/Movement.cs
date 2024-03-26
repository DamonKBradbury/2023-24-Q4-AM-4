using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public float buildup = 1, jumpheight = 1, maxspeed = 1;
    private Rigidbody2D rb2D;
    public bool WASD = false;
    public GameObject player;
    public LayerMask groundLayer;
    private bool grounded => Physics2D.BoxCast(transform.position - new Vector3(0f, 0.51f), new Vector2(0.02f, 0.02f), 0, Vector2.zero, 1, groundLayer);

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (WASD == false)
        {
            if (Input.GetKey(left))
            {
                rb2D.AddForce(Vector2.left * buildup);
            }

            if (Input.GetKey(right))
            {
                rb2D.AddForce(Vector2.right * buildup);
            }
        }
        else if (WASD == true) 
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb2D.AddForce(Vector2.left * buildup);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb2D.AddForce(Vector2.right * buildup);
            }
        }

        if (grounded)
        {
            //Make the player jump
            if (Input.GetKeyDown(jump))  //jump
            {
                rb2D.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
            }
        }

        

        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed), rb2D.velocity.y);
    }
}
