using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreBehavior : AnimalBehavior
{
    public override void GetFood()
    {
        // Only get food if the animal is hungry
        if (currentFood == null && hunger.isHungry())
        {
            // check for food in a certain radius
            Collider[] colliders = Physics.OverlapSphere(animalBody.position, searchRadius);
            foreach (Collider c in colliders)
            {
                // if there is viable food in the radius, go for it
                if (foodList.Contains(c.gameObject.tag))
                {
                    // make sure the plant is an adult
                    PlantBehavior plant = c.gameObject.GetComponent<PlantBehavior>();
                    if (plant && plant.size == PlantSize.Adult)
                    {
                        currentFood = c.gameObject;
                        break;
                    }
                }
            }
        }

        if (currentFood != null)
        {
            // check that this plant is still suitable size
            PlantBehavior plant = currentFood.GetComponent<PlantBehavior>();
            if (plant && plant.size != PlantSize.Adult)
            {
                currentFood = null;
            }
            else
            {
                // move toward the food
                animalBody.LookAt(currentFood.transform);
                animalBody.position = Vector3.MoveTowards(animalBody.position, currentFood.transform.position, searchSpeed * Time.fixedDeltaTime);
            }
        }

    }

    // When this herbivore collides with its food, the food should get eaten
    private void OnCollisionEnter(Collision collision)
    {
        PlantBehavior plant = collision.gameObject.GetComponent<PlantBehavior>();

        if (hunger.isHungry() && foodList.Contains(collision.gameObject.tag) && plant != null)
        {
            // can only eat if the plant is an adult
            if (plant.size == PlantSize.Adult)
            {
                hunger.Eat(); // Increments hunger points by 1 
                plant.GetEaten();
                currentFood = null;
            }
        }
    }
}
