using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class ApiManager : MonoBehaviour
{
   
    // Prefab que será instanciado
    public GameObject partidaPrefab;

    // Painel onde as instâncias do prefab serão colocadas
    public Transform painelPartidas;

    void Start()
    {
        // Busca dados das respectivas URLs
        StartCoroutine(GetPartidas());
        StartCoroutine(GetCampeonatos());
        StartCoroutine(ManageJogadores(RequestType.GET));
        StartCoroutine(GetEquipes());
        StartCoroutine(GetItens());
    }

    public void EnviarJogador(Jogador jogador)
    {
       StartCoroutine(ManageJogadores(RequestType.POST, jogador));
    }

    IEnumerator GetCampeonatos()
    {
        using UnityWebRequest www = UnityWebRequest.Get(urlCampeonato);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Campeonatos: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Campeonato[] campeonatos = JsonConvert.DeserializeObject<Campeonato[]>(json);

            listaCampeonato.Clear(); // Limpar antes de adicionar novas partidas
            foreach (var campeonato in campeonatos)
            {
                listaCampeonato.Add(campeonato);
                Debug.Log("GetCampeonatos - Adicionada campeonato ID: " + campeonato.idCampeonato); // Verifique as IDs das partidas
            }

            Debug.Log("GetCampeonatos - Quantidade de campeonatos carregados: " + listaCampeonato.Count);
        }
    }

    IEnumerator GetPartidas()
    {
        using UnityWebRequest www = UnityWebRequest.Get(urlPartidas);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Partidas: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Partida[] partidas = JsonConvert.DeserializeObject<Partida[]>(json);

            listaPartidas.Clear(); // Limpar antes de adicionar novas partidas
            foreach (var partida in partidas)
            {
                listaPartidas.Add(partida);
                Debug.Log("GetPartidas - Adicionada partida ID: " + partida.idPartida); // Verifique as IDs das partidas
            }

            Debug.Log("GetPartidas - Quantidade de partidas carregadas: " + listaPartidas.Count);
        }
    }

    IEnumerator ManageJogadores(RequestType request, Jogador newJogador = null)
    {
        if (request == RequestType.GET)
        {
            using UnityWebRequest www = UnityWebRequest.Get(urlJogadores);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Erro ao buscar dados da URL Jogadores: " + www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                Jogador[] jogadores = JsonConvert.DeserializeObject<Jogador[]>(json);

                listaJogadores.Clear(); // Limpar antes de adicionar novas partidas
                foreach (var jogador in jogadores)
                {
                    listaJogadores.Add(jogador);
                    Debug.Log("GetJogadores - Adicionado Jogador ID: " + jogador.idUsuario); // Verifique as IDs das partidas
                }

                Debug.Log("GetJogadores - Quantidade de jogadores carregados: " + listaJogadores.Count);
            }
        }

        if(request == RequestType.POST)
        {
            string jsonData = JsonConvert.SerializeObject(newJogador);

            using (UnityWebRequest www = new UnityWebRequest(urlJogadores, "POST"))
            {
                byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);
                www.uploadHandler = new UploadHandlerRaw(jsonToSend);
                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/json");

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || 
                    www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError("Erro ao enviar jogador para URL Jogadores: " + www.error);
                }
                else
                {
                    Debug.Log("Jogador criado");
                }
            }
        }
    }

    IEnumerator GetEquipes()
    {
        using UnityWebRequest www = UnityWebRequest.Get(urlEquipes);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Equipes: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Equipe[] equipes = JsonConvert.DeserializeObject<Equipe[]>(json);

            listaEquipe.Clear(); // Limpar antes de adicionar novas partidas
            foreach (var equipe in equipes)
            {
                listaEquipe.Add(equipe);
                Debug.Log("GetEquipes - Adicionado Equipe ID: " + equipe.idEquipe); // Verifique as IDs das partidas
            }

            Debug.Log("GetEquipes - Quantidade de Equipes carregadas: " + listaEquipe.Count);
        }
    }

    IEnumerator GetItens()
    {
        using UnityWebRequest www = UnityWebRequest.Get(urlItens);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Itens: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Item[] itens = JsonConvert.DeserializeObject<Item[]>(json);

            listaItem.Clear(); // Limpar antes de adicionar novas partidas
            foreach (var item in itens) 
            {
                listaItem.Add(item);
                Debug.Log("GetItens - Adicionado Item ID: " + item.idItem); // Verifique as IDs das partidas
            }

            Debug.Log("GetItens - Quantidade de item carregados: " + listaItem.Count);
        }
    }
    enum RequestType
    {
       GET = 0,
       POST = 1
    }
    #region urls
    private string urlPartidas = "http://localhost:5000/api/partidas";

    private string urlCampeonato = "http://localhost:5000/api/campeonato";

    private string urlJogadores = "http://localhost:5000/api/jogadores";

    private string urlEquipes = "http://localhost:5000/api/equipe";

    private string urlItens = "http://localhost:5000/api/item";
    #endregion

    #region lists
    public List<Campeonato> listaCampeonato = new List<Campeonato>();

    public List<Partida> listaPartidas = new List<Partida>();

    public List<Jogador> listaJogadores = new List<Jogador>();

    public List<Equipe> listaEquipe = new List<Equipe>();

    public List<Item> listaItem = new List<Item>();
    #endregion
}
