using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class ApiManager : MonoBehaviour
{
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
               
            }


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
            
            }

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
                   
                }

                
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
            }

           
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

    IEnumerator GetPartidaDetalhada(int idPartida)
    {
        string url = urlPartidaDetalhada + idPartida; // Monta a URL com o ID da partida
        using UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Partida Detalhada: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;

            // Parse do JSON da API
            var resposta = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            if (resposta != null && resposta["status"].ToString() == "success")
            {
                // Partida detalhada
                var partidaJson = JsonConvert.DeserializeObject<Partida>(
                    resposta["partida"].ToString()
                );
                listaPartidas.Clear(); // Limpa a lista de partidas
                listaPartidas.Add(partidaJson); // Adiciona a partida detalhada à lista

                Debug.Log("GetPartidaDetalhada - Carregada partida ID: " + partidaJson.idPartida);

                // Jogadores da partida
                var jogadoresJson = JsonConvert.DeserializeObject<List<JogadorPartida>>(
                    resposta["jogadores"].ToString()
                );
                listaJogadorePartida.Clear(); 
                listaJogadorePartida.AddRange(jogadoresJson);

                Debug.Log("GetPartidaDetalhada - Jogadores carregados: " + listaJogadorePartida.Count);
            }
            else
            {
                Debug.LogError("Erro na resposta da API: " + json);
            }
        }
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
    
    public string urlPartidaDetalhada = "http://localhost:5000/api/partidaId/"; 
    #endregion

    #region lists
    public List<Campeonato> listaCampeonato = new List<Campeonato>();

    public List<Partida> listaPartidas = new List<Partida>();

    public List<Jogador> listaJogadores = new List<Jogador>();

    public List<Equipe> listaEquipe = new List<Equipe>();

    public List<Item> listaItem = new List<Item>();

    public List<JogadorPartida> listaJogadorePartida = new List<JogadorPartida>();
    #endregion

}
