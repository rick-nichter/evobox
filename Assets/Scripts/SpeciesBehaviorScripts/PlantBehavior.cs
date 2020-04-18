using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantSize
{
    Sprout,
    Seedling,
    Adult
}
public class PlantBehavior : MonoBehaviour
{
    public float growthTime;
    public PlantSize size;
    private float timeSinceGrowth;

    private int maxTimesToBeEaten; 
    
    void Start()
    {
        size = PlantSize.Sprout;
        timeSinceGrowth = 0f;
        maxTimesToBeEaten = Random.Range(5, 25);
    }

    void Update()
    {
        if (maxTimesToBeEaten == 0)
        {
            Destroy(gameObject);
        }
        
        if (size != PlantSize.Adult)
        {
            Grow();
        }
    }

    private void Grow()
    {
        // Keep track of time since the last growth
        timeSinceGrowth += Time.deltaTime;

        // Once the proper time has resolved, this plant with grow
        if (timeSinceGrowth >= growthTime)
        {
            size += 1;
            gameObject.transform.localScale *= 2;

            // reset timer
            timeSinceGrowth = 0f;
        }
    }

    // When an animal eats from this plant, it will have to grow again
    public void GetEaten()
    {
        size = PlantSize.Sprout;
        gameObject.transform.localScale /= 4;
        maxTimesToBeEaten--;
    }
}