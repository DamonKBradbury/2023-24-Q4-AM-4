using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int baseDamage;
    public int damage;

    public bool hasEatenJFruit;
    public bool hasEatenGFruit;
    public bool hasEatenFFruit;
    public int fruitTimer;


    // Damage player
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent("Stats") as Stats) != null)
            gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (collision.gameObject.GetComponent<Stats>().damage >= 1)
        {
            health -= collision.gameObject.GetComponent<Stats>().damage;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            // Death
            if (health <= 0)
            {
                
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent("Stats") as Stats) != null)
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}