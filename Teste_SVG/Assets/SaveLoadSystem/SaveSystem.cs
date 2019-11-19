using UnityEngine;
using System.IO; // Permite trabalhar com arquivamento Inputs e Outputs do sistema
using System.Runtime.Serialization.Formatters.Binary; // Permite a serialização e a deserialização para formatos binários

// Classe passiva - Resgata e Armazena dados
public static class SaveSystem
{
    // Armazena dados no formato binário
    public static void SaveData (DataSystem dataSystem)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // cria um formatter (um objeto cuja a função é serializar ou deserializar para dados binários)
        string path = Application.persistentDataPath + "/data.cag"; // Definindo o caminho do diretório onde será armazenado o save (normalmente em: %AppData%\LocalLow\CTRL+ALT+GAMES\Kanhyngue\data.cag)
        FileStream stream = new FileStream(path, FileMode.Create); // cria um arquivo definindo o caminho onde será salvo e o que será feito (neste caso, é a criação)
        AllData data = new AllData(dataSystem); // cria um objeto 'data' da classe "AllData" com as informações de 'dataSystem'
        formatter.Serialize(stream, data); // Serializa essas informações no arquivo binário denominado 'data.cag'
        stream.Close(); // Finaliza a execução do Stream [SUPER IMPORTANTE TER ISSO NO FINAL]
    }

    // Resgata dados no formato binário
    public static AllData LoadData()
    {
         // caminho onde está o arquivo salvo
         string path = Application.persistentDataPath + "/data.cag";
         // Verifica se há um arquivo no caminho definido acima
         if(File.Exists(path))
         {
            BinaryFormatter formatter = new BinaryFormatter(); // cria um formatter (um objeto cuja a função é serializar ou deserializar para dados binários)
            FileStream stream = new FileStream(path, FileMode.Open); // abre um arquivo definindo o caminho onde está presente o caminho
            AllData data = formatter.Deserialize(stream) as AllData; // cria um objeto 'data' da classe "AllData" com as informações deserializadas provindas do arquivo stream
            stream.Close(); // Finaliza a execução do Stream [SUPER IMPORTANTE TER ISSO NO FINAL]
            return data; // Retorna as informações salvas
         }
         else
         {
             Debug.LogError("Salvamento não encontrado no " + path); // Mostra que não há arquivo no caminho definido
             return null; // Retorna nada
         }
    }
}
