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
                // INFO: this fixes minor bug where animal moves into the ground when approaching plant (kind of hacky)
                float adjustmentHeight = (animalCollider.size.y * animalBody.localScale.y) / 2;
                Vector3 foodLocation = new Vector3(currentFood.transform.position.x, currentFood.transform.position.y + adjustmentHeight, 
                    currentFood.transform.position.z);
                animalBody.LookAt(foodLocation);
                animalBody.position = Vector3.MoveTowards(animalBody.position, foodLocation, searchSpeed * Time.fixedDeltaTime);
                // animalBody.position += animalBody.forward * searchSpeed * Time.fixedDeltaTime;
            }
        }

    }

    // When this herbivore collides with its food, the food should get eaten
    private void OnCollisionStay(Collision collision)
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
