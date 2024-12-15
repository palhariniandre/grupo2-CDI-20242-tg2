using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class SearchManager : MonoBehaviour
{
    [Header("Objects")]
    public Transform contentPanel;
    public GameObject champPrefab;
    public GameObject itemPrefab;
    public GameObject teamPrefab;
    public GameObject playerPrefab;
    public GameObject matchPrefab;

    [Header("Entity")]
    [SerializeField] private int selectedEntityId;

    public GameObject selectedEntity;

    [Header("Control Variables")]
    private List<GameObject> list = new List<GameObject>();
    private ApiManager apiManager;

    [Header("Screens")]
    [SerializeField] private GameObject itemAnalysis;
    [SerializeField] private GameObject matchAnalysis;
    [SerializeField] private GameObject playerAnalysis;
    [SerializeField] private GameObject teamAnalysis;
    [SerializeField] private GameObject champAnalysis;

    public int SelectedEntity { get => selectedEntityId; set => selectedEntityId = value; }

    void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();
    }
    private void CleanEntities()
    {
        foreach (var entity in list)
        {
            Destroy(entity);
        }

        list.Clear();
    }

    // busca partidas
    public void SearchMatches()
    {
        CleanEntities();
        StartCoroutine(LoadMatches());
    }
    IEnumerator LoadMatches()
    {
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        foreach (var partida in apiManager.listaPartidas)
        {
            GameObject obj = Instantiate(matchPrefab, contentPanel);

            MatchEntity matchEntity = obj.GetComponent<MatchEntity>();
            
            if (matchEntity != null)
            {
                matchEntity.MatchData(partida);
            }

            list.Add(obj);
        }

        Debug.Log("Número de partidas carregadas no menu: " + list.Count);
    }
    public void SelectMatch()
    {
        MatchEntity match = EventSystem.current.currentSelectedGameObject.GetComponent<MatchEntity>();

        selectedEntityId = match.GetIdMatch();
        selectedEntity = match.gameObject;

        Debug.Log(selectedEntityId + "" + selectedEntity);

    }

    // manipula itens
    public void SearchItems()
    {
        CleanEntities();
        StartCoroutine(LoadItems());
    }
    IEnumerator LoadItems()
    {
        yield return new WaitUntil(() => apiManager.listaItem.Count > 0);

        foreach (var item in apiManager.listaItem)
        {
            GameObject obj = Instantiate(itemPrefab, contentPanel);

            ItemEntity itemEntity = obj.GetComponent<ItemEntity>();

            if (itemEntity != null)
            {
                itemEntity.ItemData(item);
            }

            list.Add(obj);
        }

        Debug.Log("Número de itens carregados no menu: " + list.Count);
    }
    public void SelectItem()
    {
        ItemEntity item = EventSystem.current.currentSelectedGameObject.GetComponent<ItemEntity>();

        selectedEntityId = item.GetIdItem();
        selectedEntity = item.gameObject;

        Debug.Log(selectedEntityId + "" + selectedEntity);

    }

    // manipula jogadores
    public void SearchPlayers()
    {
        CleanEntities();
        StartCoroutine(LoadPlayers());
    }
    IEnumerator LoadPlayers()
    {
        yield return new WaitUntil(() => apiManager.listaJogadores.Count > 0);

        foreach (var player in apiManager.listaJogadores)
        {
            GameObject obj = Instantiate(playerPrefab, contentPanel);

            PlayerEntity playerEntity = obj.GetComponent<PlayerEntity>();

            if (playerEntity != null)
            {
                playerEntity.PlayerData(player);
            }

            list.Add(obj);
        }

        Debug.Log("Número de jogadores carregados no menu: " + list.Count);
    }
    public void SelectPlayer()
    {
        PlayerEntity player = EventSystem.current.currentSelectedGameObject.GetComponent<PlayerEntity>();

        selectedEntityId = player.GetIdPlayer();
        selectedEntity = player.gameObject;

        Debug.Log(selectedEntityId + "" + selectedEntity);

    }

    // manipula campeoes
    public void SearchChamps()
    {
        CleanEntities();
        StartCoroutine(LoadChamps());
    }
    IEnumerator LoadChamps()
    {
        yield return new WaitUntil(() => apiManager.listaJogadores.Count > 0);

        /* foreach (var champ in apiManager.listaItem)
         {
             GameObject obj = Instantiate(matchPrefab, contentPanel);

             MatchEntity matchEntity = obj.GetComponent<MatchEntity>();

             if (matchEntity != null)
             {
                 matchEntity.MatchData(champ);
             }

             list.Add(obj);
         }*/

        Debug.Log("campeões adicionados");

        Debug.Log("Número de partidas carregadas no menu: " + list.Count);
    }
    public void SelectChamp()
    {
        ChampEntity champ = EventSystem.current.currentSelectedGameObject.GetComponent<ChampEntity>();

        selectedEntityId = champ.GetIdChamp();
        selectedEntity = champ.gameObject;

        Debug.Log(selectedEntityId + "" + selectedEntity);
    }

    // manipula equipes
    public void SearchTeams()
    {
        CleanEntities();
        StartCoroutine(LoadTeams());
    }
    IEnumerator LoadTeams()
    {
        yield return new WaitUntil(() => apiManager.listaEquipe.Count > 0);

        foreach (var team in apiManager.listaEquipe)
         {
             GameObject obj = Instantiate(teamPrefab, contentPanel);

             TeamEntity teamEntity = obj.GetComponent<TeamEntity>();

             if (teamEntity != null)
             {
                 teamEntity.DataTeam(team);
             }

             list.Add(obj);
         }

        Debug.Log("Número de equipes carregadas no menu: " + list.Count);
    }
    public void SelectTeam()
    {
        TeamEntity team = EventSystem.current.currentSelectedGameObject.GetComponent<TeamEntity>();

        selectedEntityId = team.GetIdTeam();
        selectedEntity = team.gameObject;

        Debug.Log(selectedEntityId + "" + selectedEntity);

    }

    // abre a tela conforme a entidade selecionada
    public void AnalyseEntity()
    {
        Debug.LogWarning("oiii");

        GameObject screen;

        switch (selectedEntity.tag)
        {
            case "Team":
                screen = teamAnalysis;
                break;
            case "Player":
                screen = playerAnalysis;
                break;
            case "Partida":
                screen = matchAnalysis;
                break;
            case "Item":
                screen = itemAnalysis;
                break;
            case "Champ":
                screen = champAnalysis;
                break;
            default:
                screen = gameObject;
                break;
        }

        Debug.Log(screen.name);

        //MainMenuManager.Instance.ChangeScreen(screen);

    }


    public void BackMenu(GameObject screen)
    {
        //MainMenuManager.Instance.ChangeScreen(screen);
        Debug.Log("volta");
    }


    private void OnDisable()
    {
        SelectedEntity = -1;
        selectedEntity = null;
    }

}

