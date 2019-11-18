using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int cachimbos;
    public bool chave;
    public bool dashPower;
    public bool firePower;
    public bool fogPower;

    public static int cachimboColetados;
    public static bool chaveColetada;
    public static bool dashPowerColetado;
    public static bool firePowerColetado;
    public static bool fogPowerColetado;

    void Start()
    {
        if(MenuToScene.loadGame)
        {
            LoadInventory();
        }
        else
        {
            SaveInventory();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SaveInventory();
        }
        
        Debug.Log("Cachimbos:" + cachimbos);
    }

    public void SaveInventory()
    {
        cachimbos = cachimboColetados;
        chave = chaveColetada;
        dashPower = dashPowerColetado;
        firePower = firePowerColetado;
        fogPower = fogPowerColetado;
        SaveSystem.SaveData(this);
    }

    public void LoadInventory()
    {
        AllData data = SaveSystem.LoadData();

        cachimbos = data.cachimbosSave;
        chave = data.chaveSave;
        dashPower = data.dashPower;
        firePower = data.firePower;
        fogPower = data.fogPower;
    }

}
