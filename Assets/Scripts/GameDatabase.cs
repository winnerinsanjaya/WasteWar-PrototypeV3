using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;
using Inventory.UI;

public class GameDatabase : MonoBehaviour
{
    public static GameDatabase instance;

    public bool isLoadGame;

    public InventorySO InventorySOSave;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveInventory(InventorySO inventory)
    {
        for(int i = 0; i < inventory.inventoryItems.Count; i++)
        {
            InventorySOSave.inventoryItems[i] = inventory.inventoryItems[i];
        }
    }

    public void SavePlayerPos(Vector2 position)
    {
        InventorySOSave.lastPlayerPos = position;
    }
}
