using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using System.Threading;

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


    #region Select()
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

            listaItem.Clear(); // Limpar antes de adicionar novos itens
            foreach (var item in itens) 
            {
                listaItem.Add(item);
                //Debug.Log("GetItens - Adicionado Item ID: " + item.idItem); // Verifique as IDs das partidas
            }

            Debug.Log("GetItens - Quantidade de item carregados: " + listaItem.Count);
        }
    }
    #endregion

    #region Select(Something)
    
    IEnumerator GetPartidaId(int idPartida)
    /* esse metodo busca os detalhes da partida e os jogadores de cada equipe 
       ele preenche o objeto partidaID com os dados da partida e as 
       listas de jogadores de cada equipe ListaJogadoresAzul e ListaJogadoresVermelhos
    */
    {
        string urlPartida = $"{urlPartidaId}{idPartida}";
        using UnityWebRequest wwwPartida = UnityWebRequest.Get(urlPartida);
        yield return wwwPartida.SendWebRequest();

        if (wwwPartida.result == UnityWebRequest.Result.ConnectionError || wwwPartida.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro ao buscar os detalhes da partida: {wwwPartida.error}");
            yield break;
        }

        try
        {
            var respostaPartida = JsonConvert.DeserializeObject<Dictionary<string, object>>(wwwPartida.downloadHandler.text);
            if (respostaPartida["status"].ToString() == "success")
            {
                partidaID = JsonConvert.DeserializeObject<Partida>(respostaPartida["partida"].ToString());
            }
            else
            {
                Debug.LogError("Erro na resposta da API de detalhes da partida.");
                yield break;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Erro ao desserializar JSON da partida: {e.Message}");
            yield break;
        }

        string urlJogadoresAzul = $"{urlViewEquipePartida}?idPartida={idPartida}&idEquipe={partidaID.idEquipeAzul}";
        using UnityWebRequest wwwAzul = UnityWebRequest.Get(urlJogadoresAzul);
        yield return wwwAzul.SendWebRequest();

        if (wwwAzul.result == UnityWebRequest.Result.ConnectionError || wwwAzul.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro ao buscar os jogadores da equipe azul: {wwwAzul.error}");
        }
        else
        {
            try
            {
                var jogadoresAzul = JsonConvert.DeserializeObject<List<JogadorPartida>>(wwwAzul.downloadHandler.text);
                ListaJogadoresAzul.Clear();
                ListaJogadoresAzul = jogadoresAzul; // Popula a lista de jogadores da equipe azul
                Debug.Log($"Jogadores da equipe azul carregados: {ListaJogadoresAzul.Count}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Erro ao desserializar JSON dos jogadores da equipe azul: {e.Message}");
            }
        }

        string urlJogadoresVermelho = $"{urlViewEquipePartida}?idPartida={idPartida}&idEquipe={partidaID.idEquipeVermelha}";
        using UnityWebRequest wwwVermelho = UnityWebRequest.Get(urlJogadoresVermelho);
        yield return wwwVermelho.SendWebRequest();

        if (wwwVermelho.result == UnityWebRequest.Result.ConnectionError || wwwVermelho.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro ao buscar os jogadores da equipe vermelha: {wwwVermelho.error}");
        }
        else
        {
            try
            {
                var jogadoresVermelhos = JsonConvert.DeserializeObject<List<JogadorPartida>>(wwwVermelho.downloadHandler.text);
                ListaJogadoresVermelhos.Clear();
                ListaJogadoresVermelhos = jogadoresVermelhos; 
                Debug.Log($"Jogadores da equipe vermelha carregados: {ListaJogadoresVermelhos.Count}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Erro ao desserializar JSON dos jogadores da equipe vermelha: {e.Message}");
            }
        }
    }


    #endregion

    #region Inserts()
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
    #endregion
    
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
    
    private string urlPartidaId = "http://localhost:5000/api/partidaId/"; 

    private string urlViewEquipePartida = "http://localhost:5000/api/vw_partida";
    #endregion

    #region lists
    public List<Campeonato> listaCampeonato = new List<Campeonato>();

    public List<Partida> listaPartidas = new List<Partida>();

    public List<Jogador> listaJogadores = new List<Jogador>();

    public List<Equipe> listaEquipe = new List<Equipe>();

    public List<Item> listaItem = new List<Item>();
    public List<JogadorPartida> ListaJogadoresAzul = new List<JogadorPartida>();
    public List<JogadorPartida> ListaJogadoresVermelhos = new List<JogadorPartida>();

    #endregion
    
    #region objects 
    public Partida partidaID;
    public Equipe equipeVermelha;
    public Equipe equipeAzul;

    #endregion
}