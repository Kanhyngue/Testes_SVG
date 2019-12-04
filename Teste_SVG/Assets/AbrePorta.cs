using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrePorta : MonoBehaviour
{
    private BoxCollider2D _collider;
    [SerializeField]
    private GameObject portaFechada;
    [SerializeField]
    private GameObject portaAberta;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(DataSystem.chave)
        {
            _collider.enabled = true;
            portaFechada.SetActive(false);
            portaAberta.SetActive(true);
        }
    }
}
