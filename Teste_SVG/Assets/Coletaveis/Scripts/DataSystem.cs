using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSystem : MonoBehaviour
{
    // Variável Inicializadora de Save
    public static bool activated;

    // Variáveis que serão Salvas
    // Coletáveis
    public bool[] cachimboSave = new bool[16];
    public bool chaveSave;
    public bool dashPowerSave;
    public bool firePowerSave;
    public bool fogPowerSave;
    public bool machadinhaSave;
    // Cena
    public int levelSave;
    public bool checkpointSave;
    // Player
    public int healthSave;

    // Variavéis Recipiente dos valores in-game runtime
    // Coletáveis blic string[] myArrayName = new string[4];
    public static bool[] cachimbos = new bool[16];
    public static bool chave;
    public static bool dashPower;
    public static bool firePower;
    public static bool fogPower;
    public static bool machadinha;
    // Cena
    public static int level;
    public static bool checkpoint;
    // Player
    public static int health = 5;

    // Checkpoints position
    public Transform hub;
    public Transform cerradoInitial, cerradoMiddle;
    public Transform forestInitial, forestMiddle;
    public Transform cavernInitial, cavernMiddle;

    // Player Position
    public Transform player;

    // ao inicializar o script na cena
    void Start()
    {
        // Se o jogador clicou em 'CONTINUA' no Menu Principal, então o é carregado todas as informações
        if(MenuToScene.loadGame)
        {
            LoadGame(); // Carregando save
            switch (level)
            {
                case 0:
                    player.transform.position = hub.transform.position;
                break;
                case 1:
                    if(checkpoint)
                        {
                            player.transform.position = cerradoInitial.transform.position;
                        }
                        else
                        {
                            player.transform.position = cerradoMiddle.transform.position;
                        }
                break;
                case 2:
                    if(checkpoint)
                        {
                            player.transform.position = forestInitial.transform.position;
                        }
                        else
                        {
                            player.transform.position = forestMiddle.transform.position;
                        }
                break;
                case 3:
                    if(checkpoint)
                        {
                            player.transform.position = cavernInitial.transform.position;
                        }
                        else
                        {
                            player.transform.position = cavernMiddle.transform.position;
                        }
                break;
                default:
                    player.transform.position = hub.transform.position;
                break;
            }
        }
        else
        {
            SaveGame(); // Caso contrário ele substitui o save atual, pois isso significa que o jogador iniciou um novo Jogo
        }
    }

    // Método Update - Executado a cada frame
    void Update()
    {
        // Teste de Salvamento - Apertar a Tecla 'P' salva o jogo
        if(activated)
        {
            SaveGame(); // Salvando os Dados....
            activated = false;
        }
        
        // Debug para ver se a quantidade de cachimbos coletados foram salvos
        //Debug.Log("Cachimbos:" + cachimbos);
    }

    // Método SaveGame - Realiza um Save
    public void SaveGame()
    {
        // Armazena e atualiza a quantidade de cachimbos logo antes de realizar o Save
        // Coletáveis
        cachimboSave[0] = cachimbos[0];
        cachimboSave[1] = cachimbos[1];
        cachimboSave[2] = cachimbos[2];
        cachimboSave[3] = cachimbos[3];
        cachimboSave[4] = cachimbos[4];
        cachimboSave[5] = cachimbos[5];
        cachimboSave[6] = cachimbos[6];
        cachimboSave[7] = cachimbos[7];
        cachimboSave[8] = cachimbos[8];
        cachimboSave[9] = cachimbos[9];
        cachimboSave[10] = cachimbos[10];
        cachimboSave[11] = cachimbos[11];
        cachimboSave[12] = cachimbos[12];
        cachimboSave[13] = cachimbos[13];
        cachimboSave[14] = cachimbos[14];
        cachimboSave[15] = cachimbos[15];

        chaveSave = chave;
        dashPowerSave = dashPower;
        firePowerSave = firePower;
        fogPowerSave = fogPower;
        machadinhaSave = machadinha;
        // Cena
        levelSave = level;
        checkpointSave = checkpoint;
        // Player
        healthSave = health;

        // Inicializa o arquivo de salvamento indexando os valores definidos acima.
        SaveSystem.SaveData(this);
    }

    // Método LoadGame - Carrega um Save
    public void LoadGame()
    {
        // Inicializa o metódo 'LoadData' da Classe 'Save System' referenciando o script 'AllData' para carregar as informações salvas 
        AllData data = SaveSystem.LoadData();

        //Informações coletadas do objeto 'data' e atribuidas as variaveis locais
        // Coletáveis
        cachimbos[0] = data.cachimbosData[0];
        cachimbos[1] = data.cachimbosData[1];
        cachimbos[2] = data.cachimbosData[2];
        cachimbos[3] = data.cachimbosData[3];
        cachimbos[4] = data.cachimbosData[4];
        cachimbos[5] = data.cachimbosData[5];
        cachimbos[6] = data.cachimbosData[6];
        cachimbos[7] = data.cachimbosData[7];
        cachimbos[8] = data.cachimbosData[8];
        cachimbos[9] = data.cachimbosData[9];
        cachimbos[10] = data.cachimbosData[10];
        cachimbos[11] = data.cachimbosData[11];
        cachimbos[12] = data.cachimbosData[12];
        cachimbos[13] = data.cachimbosData[13];
        cachimbos[14] = data.cachimbosData[14];
        cachimbos[15] = data.cachimbosData[15];

        chave = data.chaveData;
        dashPower = data.dashPowerData;
        firePower = data.firePowerData;
        fogPower = data.fogPowerData;
        machadinha = data.machadinhaData;
        // Cena
        level = data.levelData;
        checkpoint = data.checkpointData;
        // Player
        health = data.healthData;
    }

}
