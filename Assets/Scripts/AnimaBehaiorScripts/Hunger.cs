using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{

    public int hungerPoints = 10; 
    
    void Start()
    {
        
    }

    void Update()
    {
        if (hungerPoints > 0)
        {
            Invoke(nameof(loseHungerPoint), 10);
        }
        else
        {
            Die();
        }
    }

    // 1 in 10 chance to lose a hunger point.  This function should be called on delay
    void loseHungerPoint()
    {
        if (Random.Range(0, 10) == 5)
        {
            hungerPoints--;
        }
    }

    public void Eat()
    {
        hungerPoints++;
    }

    void Die()
    {
        //TODO Notify user of death in some way
        Destroy(gameObject);
    }
}
