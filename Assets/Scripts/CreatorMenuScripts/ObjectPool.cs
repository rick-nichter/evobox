using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple object pooling class (activates and deactivates objects as needed, storing them here)
public class ObjectPool : MonoBehaviour
{
    // The prefab this pool returns instances of
    public GameObject prefab;
    // Currently inactive instances of the prefab
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    // returns an instance of the prefab
    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        // if there is an inactive instance, return that
        if (inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        // otherwise create a new instance
        else
        {
            spawnedGameObject = Instantiate(prefab);

            // add the pooledobject component to the prefab so we know it came from this pool
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        // put the instance in the root of the scene and enable it
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        return spawnedGameObject;
    }

    // return an instance of the prefab to the pool (if it came from this pool)
    public void ReturnToInactivePool(GameObject returning)
    {
        PooledObject pooledObject = returning.GetComponent<PooledObject>();

        // if the instance came from this pool, return it
        if (pooledObject != null && pooledObject.pool == this)
        {
            // make the instance a child of this and deactivate it
            returning.transform.SetParent(transform);
            returning.SetActive(false);

            // add the instance to the stack
            inactiveInstances.Push(returning);
        }
        // otherwise destroy it
        else
        {
            Destroy(returning);
        }
    }
}

// a component that identifies the pool that a GameObject came from
public class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
}
