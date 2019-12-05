using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Esse script é serializável - permite que os dados possam ser serializados
public class AllData
{
    // Variáveis a serem salvas ou carregadas
    // Coletáveis
    public bool[] cachimbosData;
    public bool chaveData;
    public bool dashPowerData;
    public bool firePowerData;
    public bool fogPowerData;
    public bool machadinhaData;
    // Cena
    public int levelData;
    public bool checkpointData;
    // Player
    public int healthData;

    // Método de resgate de dados - DataSystem é o script de runtime onde os dados são coletados para serem salvos ou carregados
    public AllData (DataSystem dataSystem)
    {
        // Coletando dados da Classe DataSystem
        // Coletáveis
        cachimbosData[0] = dataSystem.cachimboSave[0];
        cachimbosData[1] = dataSystem.cachimboSave[1];
        cachimbosData[2] = dataSystem.cachimboSave[2];
        cachimbosData[3] = dataSystem.cachimboSave[3];
        cachimbosData[4] = dataSystem.cachimboSave[4];
        cachimbosData[5] = dataSystem.cachimboSave[5];
        cachimbosData[6] = dataSystem.cachimboSave[6];
        cachimbosData[7] = dataSystem.cachimboSave[7];
        cachimbosData[8] = dataSystem.cachimboSave[8];
        cachimbosData[9] = dataSystem.cachimboSave[9];
        cachimbosData[10] = dataSystem.cachimboSave[10];
        cachimbosData[11] = dataSystem.cachimboSave[11];
        cachimbosData[12] = dataSystem.cachimboSave[12];
        cachimbosData[13] = dataSystem.cachimboSave[13];
        cachimbosData[14] = dataSystem.cachimboSave[14];
        cachimbosData[15] = dataSystem.cachimboSave[15];



        chaveData = dataSystem.chaveSave;
        dashPowerData = dataSystem.dashPowerSave;
        firePowerData = dataSystem.firePowerSave;
        fogPowerData = dataSystem.fogPowerSave;
        machadinhaData = dataSystem.machadinhaSave;
        // Cena
        levelData = dataSystem.levelSave;
        checkpointData = dataSystem.checkpointSave;
        // Player
        healthData = dataSystem.healthSave;
    }
}
