using System.Collections.Generic;
using UnityEngine;

// A general class for animal behavior, to be derived by every specific animal script (DeerBehavior, WolfBehavior, etc.)
public class AnimalBehavior : MonoBehaviour
{
    public Transform animalBody;
    public float maxSpeed;
    // a list of all species this animal can eat (these are the tags of the animals)
    public List<string> foodList;
    // the distance this animal must be to get food
    public float searchRadius;
    public float searchSpeed;
    public GameObject currentFood;
    public int hungerPoints;
    public Hunger hunger;

    private Vector3 spawnPosition;
    private float timeSinceDirectionChange;
    private float timeBetweenDirectionChange;
    private Quaternion roamDirection;
    private float currentSpeed;
    // the maximum distance this animal can roam from its spawn point
    private float roamDistance;
    // the food this animal is currently moving toward, if any

    void Start()
    {
        maxSpeed = 1f;
        spawnPosition = animalBody.position;
        timeSinceDirectionChange = 0f;
        timeBetweenDirectionChange = 0f;
        roamDistance = 2f;
        GetComponent<Rigidbody>().freezeRotation = true;
        gameObject.AddComponent<Hunger>();
        hunger = gameObject.GetComponent<Hunger>();
        hunger.hungerPoints = hungerPoints;
        SpecificStart();
    }

    private void FixedUpdate()
    {
        Roam();
        GetFood();
    }

    // Just a function that makes the animal somewhat randomly roam around its spawn position
    public void Roam()
    {
        timeSinceDirectionChange += Time.fixedDeltaTime;

        // if the animal has roamed in the same direction long enough, time to change it
        if (timeSinceDirectionChange >= timeBetweenDirectionChange)
        {
            // reset time since last change
            timeSinceDirectionChange = 0f;

            // have chance for the animal to sit still for a bit
            if (Random.value < .3 && currentSpeed != 0f)
            {
                currentSpeed = 0f;
                // dont want them still for too long
                timeBetweenDirectionChange = Random.Range(1f, 3f);
            }
            else
            {
                // The new time between when the animal should choose a new direction to roam
                timeBetweenDirectionChange = Random.Range(2f, 5f);

                // Get a new roam direction
                roamDirection = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                currentSpeed = Random.Range(.5f, maxSpeed);
            }
        }

        // move the animal
        animalBody.rotation = roamDirection;
        animalBody.position += animalBody.forward * currentSpeed * Time.fixedDeltaTime;

        // check if the animal has roamed too far
        if (Vector3.Distance(animalBody.position, spawnPosition) > roamDistance)
        {
            // if so, turn the animal toward its spawn point
            // roamDirection = Quaternion.Euler(0f, roamDirection.eulerAngles.y - 180, 0f);
            animalBody.LookAt(spawnPosition);
            roamDirection = animalBody.rotation;
        }

    }

    // when food is within a certain distance from an animal, it will eat it (if hungry)
    public virtual void GetFood()
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
                    currentFood = c.gameObject;
                    break;
                }
            }
        }

        if (currentFood != null)
        {
            // move toward the food
            animalBody.LookAt(currentFood.transform);
            animalBody.position = Vector3.MoveTowards(animalBody.position, currentFood.transform.position, searchSpeed * Time.fixedDeltaTime);
        }

    }

    // Implement this method in a child class where something must be called in Start()
    public virtual void SpecificStart()
    {
        // Overwrite this definition in child classes
    }
}
