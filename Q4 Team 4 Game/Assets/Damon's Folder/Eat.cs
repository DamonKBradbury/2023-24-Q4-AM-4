using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public string fruitName;
    public float respawn;
    
    public void OnCollisionEnter2D (Collision2D collision)
    {

        if ((collision.gameObject.GetComponent("PlayerStats") as PlayerStats) != null)
        {

             if (fruitName == "Jump Fruit")
             {

                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                } 
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = true;
             }
             else if (fruitName == "Fire Fruit")
             {

                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = true;
             }
             else if (fruitName == "Ghost Fruit")
             {
                
                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
                collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = true;
             }
             else if (fruitName == "Anti-Gravity Fruit")
             {
                if (collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenFFruit = false;
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<PlayerStats>().hasEatenGFruit = false;
                }

                collision.gameObject.GetComponent<PlayerStats>().hasEatenAGFruit = true;
                collision.gameObject.GetComponent<PlayerStats>().fruitTimer = 30f;
             }

            gameObject.SetActive(false);
        }

    }
    void Update()
    {
        respawn += Time.deltaTime;
        if (respawn >= 60 && gameObject.activeInHierarchy == false)
        {
            respawn = 0f;
            gameObject.SetActive(true);
        }
    }
}
