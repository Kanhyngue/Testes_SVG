using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static int cachimbos = 0;
    public static bool chave = false;
    public static bool dashPower = false;
    public static bool firePower = false;
    public static bool fogPower = false;

    void Update()
    {
        Debug.Log("Cachimbos: " + cachimbos);
        Debug.Log("Chave? " + chave);
        Debug.Log("Dash? " + dashPower);
        Debug.Log("Fogo? " + firePower);
        Debug.Log("Neblina? " + fogPower);
    }

}
