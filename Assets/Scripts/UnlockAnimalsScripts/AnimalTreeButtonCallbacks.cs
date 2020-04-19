using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnlockAnimalsScripts
{
    public class AnimalTreeButtonCallbacks : MonoBehaviour
    {
        public CreatorContentBehavior ccb;
        public AnimalTreeHandler ath;
        public GameObject notEnoughXPText; 

        public Button stagButton; 
        public Sprite stagSprite;
        public int stagCost;
        public GameObject stagModel; 

        public Button wolfButton;
        public Sprite wolfSprite;
        public int wolfCost;
        public GameObject wolfModel;

        public Button rabbitButton;
        public Sprite rabbitSprite;
        public int rabbitCost; 
        public GameObject rabbitModel;

        public Button blackBearButton;
        public Sprite blackBearSprite;
        public int blackBearCost; 
        public GameObject blackBearModel;
        
        // Called on Button Click
        public void onStagClicked()
        {
            if (ath.getXP() >= 15)
            {
                ath.spendXP(15);
                ccb.AddItem(new CreatorItem("Stag", stagSprite, stagCost, stagModel)); // get reference to prefab
                // Once we unlock this animal type don't allow unlocking it again.
                stagButton.interactable = false; 
            }
            else
            {
                showNotEnoughXPText();
            }
            

        }
        
        // Called on Button Click
        public void onWolfClicked()
        {
            if (ath.getXP() >= 25)
            {
                ath.spendXP(25);
                ccb.AddItem(new CreatorItem("Wolf", wolfSprite, wolfCost, wolfModel));
                // Once we unlock this animal type don't allow unlocking it again.
                wolfButton.interactable = false; 
            }
            else
            {
                showNotEnoughXPText();
            }
        }

        public void onRabbitClicked()
        {
            if (ath.getXP() >= 5)
            {
                ath.spendXP(5);
                ccb.AddItem(new CreatorItem("Rabbit", rabbitSprite, rabbitCost, rabbitModel));
                rabbitButton.interactable = false;
            }
            else
            {
                showNotEnoughXPText();
            }
        }

        public void onBlackBearClicked()
        {
            if (ath.getXP() >= 50)
            {
                ath.spendXP(50);
                ccb.AddItem(new CreatorItem("Black Bear", blackBearSprite, blackBearCost, blackBearModel));
                blackBearButton.interactable = false;
            }
            else
            {
                showNotEnoughXPText();
            }
        }
        
        
        private void showNotEnoughXPText()
        {
            notEnoughXPText.SetActive(true);
            StartCoroutine(turnOffText());
        }

        IEnumerator turnOffText()
        {
            yield return new WaitForSeconds(2);
            notEnoughXPText.SetActive(false);
        }
    }
}