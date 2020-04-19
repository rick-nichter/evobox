using UnityEngine;
using UnityEngine.UI;

namespace UnlockAnimalsScripts
{
    public class AnimalTreeHandler : MonoBehaviour
    {

        public GameObject animalUnlockCanvas;
        public GameObject creatorMenu;
        public Text xpText; 

        private int xp; 

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

        public void addXP()
        {
            xp++;
            xpText.text = "Available XP = " + xp; 
        }

        public int getXP()
        {
            return xp; 
        }

        public void spendXP(int cost)
        {
            xp -= cost; 
            xpText.text = "Available XP = " + xp; 
        }
    }
}
