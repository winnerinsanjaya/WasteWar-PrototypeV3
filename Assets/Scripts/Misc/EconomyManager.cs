using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text goldText;
    private int currentGold = 0;

    const string COIN_AMOUNT_TEXT = "Gold Amount Text";

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        InitializeGoldText();
    }

    private void InitializeGoldText()
    {
        if (goldText == null)
        {
            goldText = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
            if (goldText != null)
            {
                goldText.text = currentGold.ToString("D3");
            }
        }
    }

    public void UpdateCurrentGold()
    {
        currentGold += 1;
        InitializeGoldText();
        goldText.text = currentGold.ToString("D3");

        if (shopManager != null)
        {
            shopManager.SetCurrentGold(currentGold);
        }
    }

    public int GetCurrentGold()
    {
        return currentGold;
    }

    public void SetCurrentGold(int newGoldAmount)
    {
        currentGold = newGoldAmount;
        InitializeGoldText();
        goldText.text = currentGold.ToString("D3");
    }
}
