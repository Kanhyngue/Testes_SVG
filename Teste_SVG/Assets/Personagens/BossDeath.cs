using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public GameObject mySelf;

    private void Dead()
    {
        mySelf.SetActive(false);
    }
}
