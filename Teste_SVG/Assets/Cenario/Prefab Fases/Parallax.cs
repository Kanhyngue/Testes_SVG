using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform parallaxLayer1;
    public Transform parallaxLayer2;
    public Transform parallaxLayer3;
    public Transform parallaxLayer4;

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
        parallaxLayer1.transform.position += Vector3.right * deltaX * -parallaxSpeed; // Primeira camada do Parallax no eixo X
        parallaxLayer2.transform.position += Vector3.right * deltaX * (-parallaxSpeed * (2f/betweenFactor)); // Segunda camada do Parallax no eixo X
        parallaxLayer3.transform.position += Vector3.right * deltaX * (-parallaxSpeed * (4f/betweenFactor)); // Terceira camada do Parallax no eixo X
        parallaxLayer4.transform.position += Vector3.right * deltaX * (-parallaxSpeed * (6f/betweenFactor)); // Quarta camada do Parallax no eixo X
        lastCameraX = cameraTransform.transform.position.x; // Pega a posição da camera no eixo X
        float deltaY = cameraTransform.position.y - lastCameraY; // Cálculo da diferença entre a camera e sua ultima posição no eixo Y
        parallaxLayer1.transform.position += Vector3.up * (deltaY * -parallaxSpeed/(10f * betweenFactor)); // Primeira camada do Parallax no eixo Y
        parallaxLayer2.transform.position += Vector3.up * (deltaY * -parallaxSpeed/(3f * betweenFactor)); // Segunda camada do Parallax no eixo Y
        parallaxLayer3.transform.position += Vector3.up * (deltaY * -parallaxSpeed/betweenFactor); // Terceira camada do Parallax no eixo Y
        parallaxLayer4.transform.position += Vector3.up * (deltaY * -parallaxSpeed); // Quarta camada do Parallax no eixo Y
        lastCameraY = cameraTransform.transform.position.y; // Pega a posição da camera no eixo X
    }
}
