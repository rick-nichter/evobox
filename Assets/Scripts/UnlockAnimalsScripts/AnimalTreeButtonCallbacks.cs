using UnityEngine;
using UnityEngine.UI;

namespace UnlockAnimalsScripts
{
    public class AnimalTreeButtonCallbacks : MonoBehaviour
    {
        public CreatorContentBehavior ccb;

        public Button stagButton; 
        public Sprite stagSprite;
        public GameObject stagModel; 

        public Button wolfButton;
        public Sprite wolfSprite;
        public GameObject wolfModel; 
        
        // Called on Button Click
        public void onStagClicked()
        {
            //TODO: Put all of this in an check for if player has enough XP to unlock. 
            ccb.AddItem(new CreatorItem("Stag", stagSprite, stagModel)); // get reference to prefab
            
            // Once we unlock this animal type don't allow unlocking it again.
            stagButton.interactable = false; 
        }
        
        // Called on Button Click
        public void onWolfClicked()
        {
            //TODO: Put all of this in an check for if player has enough XP to unlock. 
            ccb.AddItem(new CreatorItem("Wolf", wolfSprite, wolfModel));
            
            // Once we unlock this animal type don't allow unlocking it again.
            wolfButton.interactable = false; 
        }
    }
}