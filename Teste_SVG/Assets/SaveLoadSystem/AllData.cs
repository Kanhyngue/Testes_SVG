using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllData
{
    public int cachimbosSave;
    public bool chaveSave;
    public bool dashPower;
    public bool firePower;
    public bool fogPower;
    public int health;
    public int level;
    public bool checkpoint;

    public AllData (InventorySystem inventory)
    {
        cachimbosSave = inventory.cachimbos;
        chaveSave = inventory.chave;
        dashPower = inventory.dashPower;
        firePower = inventory.firePower;
        fogPower = inventory.fogPower;
    }
}
