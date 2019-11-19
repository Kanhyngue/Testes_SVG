using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Esse script é serializável - permite que os dados possam ser serializados
public class AllData
{
    // Variáveis a serem salvas ou carregadas
    // Coletáveis
    public int cachimbosData;
    public bool chaveData;
    public bool dashPowerData;
    public bool firePowerData;
    public bool fogPowerData;
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
        cachimbosData = dataSystem.cachimboSave;
        chaveData = dataSystem.chaveSave;
        dashPowerData = dataSystem.dashPowerSave;
        firePowerData = dataSystem.firePowerSave;
        fogPowerData = dataSystem.fogPowerSave;
        // Cena
        levelData = dataSystem.levelSave;
        checkpointData = dataSystem.checkpointSave;
        // Player
        healthData = dataSystem.healthSave;
    }
}
