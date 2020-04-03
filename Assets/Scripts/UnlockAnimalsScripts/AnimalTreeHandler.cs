using UnityEngine;

namespace UnlockAnimalsScripts
{
    public class AnimalTreeHandler : MonoBehaviour
    {

        public GameObject animalUnlockCanvas;
        public GameObject creatorMenu;
       

        void Update()
        {
            if (Input.GetKey(KeyCode.T))
            {
                animalUnlockCanvas.SetActive(true);
                creatorMenu.SetActive(false);
            }
            else
            {
                animalUnlockCanvas.SetActive(false);
                creatorMenu.SetActive(true);
            }
        }
    }
}
