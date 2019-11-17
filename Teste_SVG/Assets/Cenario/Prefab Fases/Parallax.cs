using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    [SerializeField] private Transform[] parallaxLayers;

    public float parallaxSpeed;
    public float betweenFactor;

    private float lastCameraX;
    private float lastCameraY;

    // Start is called before the first frame update
    void Start()
    {
        lastCameraX = cameraTransform.transform.position.x; // Pega a posição inicial da camera no eixo X
        lastCameraY = cameraTransform.transform.position.y; // Pega a posição inicial da camera no eixo Y
    }

    void FixedUpdate()
    {
        if(betweenFactor == 0) // Esse fator não pode ser igual a 0
        {
            betweenFactor = 1f; // Fator de Sensação de Distanciamento
        }
        float deltaX = cameraTransform.position.x - lastCameraX; // Cálculo da diferença entre a camera e sua ultima posição no eixo X
        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            if (i == 0)
            {
                parallaxLayers[i].transform.position += Vector3.right * deltaX * -parallaxSpeed;
            }
            else
            {
                parallaxLayers[i].transform.position += Vector3.right * deltaX * (-parallaxSpeed * ((i * 2) / betweenFactor)); // Segunda camada do Parallax no eixo X
            }
        }

        lastCameraX = cameraTransform.transform.position.x; // Pega a posição da camera no eixo X
        float deltaY = cameraTransform.position.y - lastCameraY; // Cálculo da diferença entre a camera e sua ultima posição no eixo Y
        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            if (i == parallaxLayers.Length)
            {
                parallaxLayers[i].transform.position += Vector3.up * (deltaX * -parallaxSpeed); 
            }
            else 
            {
                parallaxLayers[i].transform.position += Vector3.up * (deltaY * -parallaxSpeed / (((parallaxLayers.Length-i)*3)*betweenFactor)); 
            }
        }
        lastCameraY = cameraTransform.transform.position.y; // Pega a posição da camera no eixo X

       
    }
}
