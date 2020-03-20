using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A general class for animal behavior, to be derived by every specific animal script (DeerBehavior, WolfBehavior, etc.)
public class AnimalBehavior : MonoBehaviour
{
    public Transform animalBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animalBody.position += Vector3.forward * Time.deltaTime; // test
    }
}
