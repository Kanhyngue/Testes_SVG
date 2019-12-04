using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionNPCs : MonoBehaviour
{
    public GameObject objectRender;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            objectRender.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            objectRender.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            objectRender.SetActive(false);
        }
    }
}
