using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public string fruitName;
    
    public void OnCollisionEnter2D (Collision2D collision)
    {
        if ((collision.gameObject.GetComponent("Stats") as Stats) != null)
        {

             if (fruitName == "Jump Fruit")
             {

                if (collision.gameObject.GetComponent<Stats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenFFruit = false;
                } 
                else if (collision.gameObject.GetComponent<Stats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenGFruit = false;
                }

                collision.gameObject.GetComponent<Stats>().hasEatenJFruit = true;
             }
             else if (fruitName == "Fire Fruit")
             {

                if (collision.gameObject.GetComponent<Stats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<Stats>().hasEatenGFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenGFruit = false;
                }

                collision.gameObject.GetComponent<Stats>().hasEatenFFruit = true;
             }
              else if (fruitName == "Ghost Fruit")
             {
                
                if (collision.gameObject.GetComponent<Stats>().hasEatenJFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenJFruit = false;
                }
                else if (collision.gameObject.GetComponent<Stats>().hasEatenFFruit == true)
                {
                    collision.gameObject.GetComponent<Stats>().hasEatenFFruit = false;
                }

                collision.gameObject.GetComponent<Stats>().hasEatenGFruit = true;
             }

          Destroy(gameObject);
        }
    } 
}
