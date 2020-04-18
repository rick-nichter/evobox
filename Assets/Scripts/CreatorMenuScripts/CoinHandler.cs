using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    public int initialCoins = 50;
    public Text coinsText;
    public GameObject tooExpensiveText;

    private int coins; 
    
    private void Start()
    {
        coins = initialCoins; 
        InvokeRepeating(nameof(addOneCoin), 15,30);
    }

    private void addOneCoin()
    {
        updateCoins(1);
    }


    public void updateCoins(int delta)
    {
        coins += delta;
        coinsText.text = coins.ToString(); 
    }

    public int getCoins()
    {
        return coins; 
    }

    public void showTooExpensive()
    {
        tooExpensiveText.SetActive(true);
        StartCoroutine(turnOffText());
    }

    IEnumerator turnOffText()
    {
        yield return new WaitForSeconds(2);
        tooExpensiveText.SetActive(false);
    }
}
