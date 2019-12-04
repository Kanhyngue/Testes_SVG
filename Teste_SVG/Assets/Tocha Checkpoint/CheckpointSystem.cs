using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public static int checkpoint;
    public Transform player;
    public GameObject[] cenarios; // 0 -> HUB | 1 -> Cerrado | 2 -> Floresta | 3 -> Caverna
    public Transform[] checkpointLocal;

    // checkpoints Locais
    // 0 -> HUB | 1 -> Cerrado Inicio | 2 -> Cerrado Meio | 3 -> Cerrado Final | 4 -> Floresta Inicio | 5 -> Floresta Meio | 6 -> Floresta Final | 7 -> Caverna Inicio | 8 -> Caverna Final
    private void Start()
    {
        if (checkpoint == 0)
        {
            player.position = checkpointLocal[0].position;
        }
        else if (checkpoint == 1)
        {
            cenarios[0].SetActive(false);
            cenarios[1].SetActive(true);
            player.position = checkpointLocal[1].position;
        }
        else if (checkpoint == 2)
        {
            cenarios[0].SetActive(false);
            cenarios[1].SetActive(true);
            player.position = checkpointLocal[2].position;
        }
        else if (checkpoint == 3)
        {
            cenarios[0].SetActive(false);
            cenarios[1].SetActive(true);
            player.position = checkpointLocal[3].position;
        }
        else if (checkpoint == 4)
        {
            cenarios[0].SetActive(false);
            cenarios[2].SetActive(true);
            player.position = checkpointLocal[4].position;
        }
        else if (checkpoint == 5)
        {
            cenarios[0].SetActive(false);
            cenarios[2].SetActive(true);
            player.position = checkpointLocal[5].position;
        }
        else if (checkpoint == 6)
        {
            cenarios[0].SetActive(false);
            cenarios[2].SetActive(true);
            player.position = checkpointLocal[6].position;
        }
        else if (checkpoint == 7)
        {
            cenarios[0].SetActive(false);
            cenarios[3].SetActive(true);
            player.position = checkpointLocal[7].position;
        }
        else if (checkpoint == 8)
        {
            cenarios[0].SetActive(false);
            cenarios[3].SetActive(true);
            player.position = checkpointLocal[8].position;
        }
    }

}
