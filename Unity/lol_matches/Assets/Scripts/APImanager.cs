using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ApiManager : MonoBehaviour
{
    private string url = "http://localhost:5000/api/partidas";

    public List<Partida> listaPartidas = new List<Partida>();

    // Prefab que será instanciado
    public GameObject partidaPrefab;

    // Painel onde as instâncias do prefab serão colocadas
    public Transform painelPartidas;

    void Start()
    {
        // Iniciar a rotina para buscar os dados
        StartCoroutine(GetPartidas());
    }

    IEnumerator GetPartidas()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Erro ao tentar obter dados: " + www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                Partida[] partidas = JsonConvert.DeserializeObject<Partida[]>(json);

                listaPartidas.Clear(); // Limpar antes de adicionar novas partidas
                foreach (var partida in partidas)
                {
                    listaPartidas.Add(partida);
                    Debug.Log("Adicionada partida ID: " + partida.idPartida); // Verifique as IDs das partidas
                }

                Debug.Log("Quantidade de partidas carregadas: " + listaPartidas.Count);
            }
        }
    }

}
