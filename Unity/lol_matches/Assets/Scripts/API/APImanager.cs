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
        StartCoroutine(GetEquipes());
        StartCoroutine(GetItens());
        StartCoroutine(GetCampeao()); 
        StartCoroutine(GetJogadores());
        Busca("Shyvana", 4); // Busca em Campeões
        Busca("Infinity", 2); // Busca em Itens
    }
    public void RecebaPartidaId(int partidaId)
    {
        StartCoroutine(GetPartidaId(partidaId));
    }

    #region Select()
    
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
    IEnumerator GetCampeao()
    {
        using UnityWebRequest www = UnityWebRequest.Get(urlCampeao);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao buscar dados da URL Partidas: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            Campeao[] campeoes = JsonConvert.DeserializeObject<Campeao[]>(json);

            listaCampeao.Clear(); // Limpar antes de adicionar novas partidas
            foreach (var campeao in campeoes)
            {
                listaCampeao.Add(campeao);
                //Debug.Log("GetCampeao - Adicionado Campeao ID: " + campeao.idCampeao); // Verifique as IDs das partidas	
            }
            Debug.Log("GetCampeao - Quantidade de campeoes carregados: " + listaCampeao.Count); 
        }
    }
    IEnumerator GetJogadores()
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

            listaJogadores.Clear(); // Limpar antes de adicionar novos jogadores
            foreach (var jogador in jogadores)
            {
                listaJogadores.Add(jogador);
                
            }
        }
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

            //Debug.Log("GetItens - Quantidade de item carregados: " + listaItem.Count);
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

        IEnumerator PostJogador(Jogador newJogador)
    {
        if (newJogador == null)
        {
            Debug.LogError("O objeto Jogador é nulo.");
            yield break;
        }

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
                Debug.Log("Jogador criado com sucesso.");
            }
        }
    }
        IEnumerator PostEquipe(Equipe newEquipe)    
    {
        if (newEquipe == null)
        {
            Debug.LogError("O objeto Equipe é nulo.");
            yield break;
        }

        string jsonData = JsonConvert.SerializeObject(newEquipe);

        using (UnityWebRequest www = new UnityWebRequest(urlEquipes, "POST"))
        {
            byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || 
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Erro ao enviar equipe para URL Equipes: " + www.error);
            }
            else
            {
                Debug.Log("Equipe criada com sucesso.");
            }
        }
    }

    #endregion
    #region delete()


    IEnumerator DeleteEquipe(int idEquipe)
    {
        string urlDeleteEquipe = $"{urlEquipes}/{idEquipe}";
        using UnityWebRequest www = UnityWebRequest.Delete(urlDeleteEquipe);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || 
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao deletar equipe: " + www.error);
        }
        else
        {
            Debug.Log("Equipe deletada com sucesso.");
        }
    }

    #endregion    
    #region search()

    public void Busca(string busca, int categoria)
{
    switch (categoria)
    {
        case 1:
            StartCoroutine(SearchUsuario("usuarios/search", busca, listaSearchUsuario));
            break;
        case 2:
            StartCoroutine(SearchItem("item/search", busca, listaSearchItem));
            break;
        case 3:
            StartCoroutine(SearchEquipe("equipe/search", busca, listaSearchEquipe));
            break;
        case 4:
            StartCoroutine(SearchCampeao("campeao/search", busca, listaSearchCampeao));
            break;
        default:
            Debug.LogError("Categoria inválida. Use 1 (Usuário), 2 (Item), 3 (Equipe) ou 4 (Campeão).");
            break;
    }
}

private IEnumerator SearchUsuario(string endpoint, string busca, List<Jogador> lista)
{
    string url = $"{baseUrl}/{endpoint}?nome={UnityWebRequest.EscapeURL(busca)}";

    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro na busca: {request.error}");
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;

            // Deserializa diretamente para List<Jogador>
            List<Jogador> resultados = JsonConvert.DeserializeObject<List<Jogador>>(jsonResponse);
            lista.Clear();
            lista.AddRange(resultados);

            Debug.Log($"Resultados encontrados para '{busca}' em {endpoint}: {lista.Count}");
        }
    }
}

private IEnumerator SearchItem(string endpoint, string busca, List<Item> lista)
{
    string url = $"{baseUrl}/{endpoint}?nome={UnityWebRequest.EscapeURL(busca)}";

    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro na busca: {request.error}");
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;

            // Deserializa diretamente para List<Item>
            List<Item> resultados = JsonConvert.DeserializeObject<List<Item>>(jsonResponse);
            lista.Clear();
            lista.AddRange(resultados);

            Debug.Log($"Resultados encontrados para '{busca}' em {endpoint}: {lista.Count}");
        }
    }
}

private IEnumerator SearchEquipe(string endpoint, string busca, List<Equipe> lista)
{
    string url = $"{baseUrl}/{endpoint}?nome={UnityWebRequest.EscapeURL(busca)}";

    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro na busca: {request.error}");
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;

            // Deserializa diretamente para List<Equipe>
            List<Equipe> resultados = JsonConvert.DeserializeObject<List<Equipe>>(jsonResponse);
            lista.Clear();
            lista.AddRange(resultados);

            Debug.Log($"Resultados encontrados para '{busca}' em {endpoint}: {lista.Count}");
        }
    }
}

private IEnumerator SearchCampeao(string endpoint, string busca, List<Campeao> lista)
{
    string url = $"{baseUrl}/{endpoint}?nome={UnityWebRequest.EscapeURL(busca)}";

    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Erro na busca: {request.error}");
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;

            // Deserializa diretamente para List<Campeao>
            List<Campeao> resultados = JsonConvert.DeserializeObject<List<Campeao>>(jsonResponse);
            lista.Clear();
            lista.AddRange(resultados);

            Debug.Log($"Resultados encontrados para '{busca}' em {endpoint}: {lista.Count}");
        }
    }
}


    #endregion
    #region urls
    private string baseUrl = "http://localhost:5000/api";

    private string urlPartidas = "http://localhost:5000/api/partidas";

    private string urlCampeonato = "http://localhost:5000/api/campeonato";

    private string urlJogadores = "http://localhost:5000/api/jogadores";

    private string urlEquipes = "http://localhost:5000/api/equipe";

    private string urlItens = "http://localhost:5000/api/item";
    
    private string urlPartidaId = "http://localhost:5000/api/partidaId/"; 

    private string urlViewEquipePartida = "http://localhost:5000/api/vw_partida";
    private string urlCampeao = "http://localhost:5000/api/campeao";
    
    #endregion

    #region lists
    public List<Campeonato> listaCampeonato = new List<Campeonato>();

    public List<Partida> listaPartidas = new List<Partida>();

    public List<Jogador> listaJogadores = new List<Jogador>();

    public List<Equipe> listaEquipe = new List<Equipe>();

    public List<Item> listaItem = new List<Item>();
    public List<Campeao> listaCampeao = new List<Campeao>();
    public List<JogadorPartida> ListaJogadoresAzul = new List<JogadorPartida>();
    public List<JogadorPartida> ListaJogadoresVermelhos = new List<JogadorPartida>();
     public List<Jogador> listaSearchUsuario = new List<Jogador>();
    public List<Item> listaSearchItem = new List<Item>();
    public List<Equipe> listaSearchEquipe = new List<Equipe>();
    public List<Campeao> listaSearchCampeao = new List<Campeao>();
    #endregion
    
    #region objects 
    public Partida partidaID;
    public Equipe equipeVermelha;
    public Equipe equipeAzul;

    #endregion
}