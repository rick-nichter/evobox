using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The current state the game is in (View, Place, Remove, etc.)
// View is default state (player is viewing environment), Place is when the player is placing a species, etc.
public enum GameState
{
    View,
    Place,
    Delete
    // Add other states here
}

public class GameManagerScript : MonoBehaviour
{
    public Camera mainCamera;

    private GameState state = GameState.View;
    // a prefab of an object to be placed, if in Place GameState
    private GameObject placingObject;
    // a preview instance of the object to be placed
    private GameObject placingObjectPreview;
    void Start()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (state == GameState.Place)
        {
            Placing();
        }
    }

    public void SetState(GameState newState, GameObject objectToPlace = null)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Place:
                // Set the object to be placed to the desired prefab
                placingObject = objectToPlace;
                // Create a preview version of the desired prefab
                CreateObjectPreview(objectToPlace);

                break;
        }
    }

    // To be run when GameState is in Place state
    private void Placing()
    {
        // Have a preview of the species to be placed follow the mouse, showing the player where it would be placed
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // place the object on top of the collider, not halfway through it
            float adjustmentHeight = placingObjectPreview.GetComponent<Renderer>().bounds.size.y / 2;
            Vector3 placePoint = hit.point + new Vector3(0, adjustmentHeight, 0);
            placingObjectPreview.transform.position = placePoint;

            // The object should be spawned when the mouse is clicked, reverting to view mode
            if (Input.GetMouseButton(0))
            {
                Destroy(placingObjectPreview);
                Instantiate<GameObject>(placingObject, placePoint, Quaternion.Euler(0, 0, 0));
                SetState(GameState.View);
            }
        }

        // if user presses escape, revert to view mode
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(placingObjectPreview);
            SetState(GameState.View);
        }
    }

    private void CreateObjectPreview(GameObject objectToPreview)
    {
        // Destroy any existing placement preview
        if (placingObjectPreview)
        {
            Destroy(placingObjectPreview);
        }

        // New instance of the object, placed in the center of the screen 
        placingObjectPreview = Instantiate<GameObject>(objectToPreview,
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 5)), Quaternion.Euler(0, 0, 0));

        // remove behavior from this species so it is essentially just a model
        Destroy(placingObjectPreview.GetComponent<MonoBehaviour>());
        Destroy(placingObjectPreview.GetComponent<Collider>());

        // now make a new material that is slightly transparent and apply it to the species object
        Renderer r = placingObjectPreview.GetComponent<Renderer>();
        Color newColor = r.material.color;
        newColor.a = .5f;
        r.material.color = newColor;
        // remove shadows from preview
        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
}
