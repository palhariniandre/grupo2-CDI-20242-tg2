using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json; // Certifique-se de ter o Newtonsoft.Json importado
// Você pode importar via o Package Manager ou colocar o pacote JSON .NET para Unity.

public class Partida 
{
    public int idPartida;
    public string data;
    public string hora;
    public string etapa;
    public string equipeAzul;
    public string equipeVermelha;
    public int AnoCampeonato;
    public string placar;
}



public class APImanager : MonoBehaviour
{
    // Insira a URL da sua API aqui
    private string url = "http://localhost:5000/api/partidas";
    

    public List<Partida> listaPartidas = new List<Partida>();
    void Start()
    {
        // Iniciar a rotina para buscar os dados
        StartCoroutine(GetPartidas());
    }



    IEnumerator GetPartidas()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // Envia a requisição e aguarda a resposta
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

                foreach (var partida in listaPartidas)
                {
                   
                    Debug.Log("ID: " + partida.idPartida + " | " +
                              "Etapa: " + partida.etapa + " | " + 
                              "Equipes: " + partida.equipeVermelha + " vs " + partida.equipeAzul + " | " +
                              "Placar: " + partida.placar + " | " +
                              "Data: " + partida.data + " Hora: " + partida.hora);
                    listaPartidas.Add(partida);
                }
            }
        }
    }
}
