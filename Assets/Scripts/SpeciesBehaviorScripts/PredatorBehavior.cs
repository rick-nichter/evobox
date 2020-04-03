using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehavior : AnimalBehavior
{
    // When this predator collides with a prey, it should eat it (destroy the instance of prey)
    private void OnCollisionEnter(Collision collision)
    {
        if (hunger.isHungry() && foodList.Contains(collision.gameObject.tag))
        {
            hunger.Eat(); // Increments hunger points by 1 
            Destroy(collision.gameObject);
            currentFood = null;
        }
    }
}