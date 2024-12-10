using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public enum RequestType
    {
        GET = 0,
        POST = 1,
    }

    private void Start()
    {
        StartCoroutine(Requester());
    }

    private IEnumerator Requester()
    {
        // GET
        var getRequest = CreateRequest("http://localhost:5000/api/partidas");
        yield return getRequest.SendWebRequest();
        Debug.Log(getRequest.downloadHandler.text);
        var partidasList = ArrayJSON.FromJson<PartidaList>(getRequest.downloadHandler.text);
        // Desserializar diretamente em uma lista de PartidaJSON
        PartidaJSON[][] partidas = ArrayJSON.FromJson<PartidaJSON[]>(getRequest.downloadHandler.text);

        // Iterar sobre as partidas
        foreach (var listaDePartidas in partidas)
        {
            foreach (var partida in listaDePartidas)
            {
                Debug.Log($"ID: {partida.idPartida}, Equipe Azul: {partida.equipeAzul}, " +
                          $"Equipe Vermelha: {partida.equipeVermelha}, Placar: {partida.placar}");
            }
        }
        // POST
  

    }


    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
    {
        var request = new UnityWebRequest(path, type.ToString());

        if (data != null)
        {
            var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }

    private void AttachHeader(UnityWebRequest request, string key, string value)
    {
        request.SetRequestHeader(key, value);
    }
}


public class PartidaJSON
{
    // Ensure no getters / setters
    // Typecase has to match exactly
    public int idPartida;
    public int data;
    public string hora;
    public string etapa;
    public string equipeAzul;
    public string equipeVermelha;
    public int anoCampeonato;
    public string placar;
   
}

public class PartidaList
{
    public List<PartidaJSON> partidas;
}

public class PostResult
{
    public string success { get; set; }
}
