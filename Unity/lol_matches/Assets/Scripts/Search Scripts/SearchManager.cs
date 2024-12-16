using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{
    [Header("Analysis Screens")]
    [SerializeField] private Button analysisButton;
    [SerializeField] private GameObject itemAnalysis;
    [SerializeField] private GameObject champAnalysis;
    [SerializeField] private GameObject playerAnalysis;
    [SerializeField] private GameObject teamAnalysis;
    [SerializeField] private GameObject matchAnalysis;

    [Header("Objects")]
    [SerializeField] private Transform contentPanel;
    [SerializeField] private GameObject champPrefab;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject teamPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject matchPrefab;

    [Header("Entity")]
    [SerializeField] private GameObject selectedEntity;
    [SerializeField] private int entityId;

    [Header("Control Variables")]
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private ApiManager apiManager;
    [SerializeField] private MainMenuManager mainMenu;
    public GameObject SelectedEntity { get => selectedEntity; set => selectedEntity = value; }
    public int EntityId { get => entityId; set => entityId = value; }

    void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();
    }

    private void OnEnable()
    {
        SelectedEntity = null;
        CleanEntities();
    }

    private void CleanEntities()
    {
        foreach (var matchEntity in list)
        {
            Destroy(matchEntity);
        }

        list.Clear();
    }

    // busca partidas
    public void SearchMatches()
    {
        StartCoroutine(LoadMatches());
    }
    IEnumerator LoadMatches()
    {
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        CleanEntities();

        foreach (var partida in apiManager.listaPartidas)
        {
            GameObject obj = Instantiate(matchPrefab, contentPanel);

            MatchEntity matchEntity = obj.GetComponent<MatchEntity>();

            if (matchEntity != null)
            {
                matchEntity.MatchData(partida);

                Button matchButton = obj.GetComponent<Button>();
                if (matchButton != null)
                {
                    matchButton.onClick.AddListener(() => GetReferenceInEntity(matchEntity.gameObject));
                }
            }

            list.Add(obj);
        }

        Debug.Log("Número de partidas carregadas no menu: " + list.Count);
    }

    public void SearchItems()
    {
        StartCoroutine(LoadItems());
    }
    IEnumerator LoadItems()
    {
        yield return new WaitUntil(() => apiManager.listaItem.Count > 0);

        CleanEntities();

        foreach (var item in apiManager.listaItem)
        {
            GameObject obj = Instantiate(itemPrefab, contentPanel);

            ItemEntity itemEntity = obj.GetComponent<ItemEntity>();

            if (itemEntity != null)
            {
                itemEntity.ItemData(item);

                Button itemButton = obj.GetComponent<Button>();
                if (itemButton != null)
                {
                    itemButton.onClick.AddListener(() => GetReferenceInEntity(itemEntity.gameObject));
                }

            }

            list.Add(obj);
        }

        Debug.Log("Número de itens carregados no menu: " + list.Count);
    }

    public void SearchPlayers()
    {
        StartCoroutine(LoadPlayers());
    }
    IEnumerator LoadPlayers()
    {
        yield return new WaitUntil(() => apiManager.listaJogadores.Count > 0);

        CleanEntities();

        foreach (var player in apiManager.listaJogadores)
        {
            GameObject obj = Instantiate(playerPrefab, contentPanel);

            PlayerEntity playerEntity = obj.GetComponent<PlayerEntity>();

            if (playerEntity != null)
            {
                playerEntity.PlayerData(player);
            }

            list.Add(obj);

            Button playerButton = obj.GetComponent<Button>();
            if (playerButton != null)
            {
                playerButton.onClick.AddListener(() => GetReferenceInEntity(playerEntity.gameObject));
            }

        }

        Debug.Log("Número de jogadores carregados no menu: " + list.Count);
    }

    public void SearchChamps()
    {
        StartCoroutine(LoadChamps());
    }
    IEnumerator LoadChamps()
    {
        yield return new WaitUntil(() => apiManager.listaCampeao.Count > 0);

        CleanEntities();

        foreach (var champ in apiManager.listaCampeao)
        {
            GameObject obj = Instantiate(champPrefab, contentPanel);

            ChampEntity champEntity = obj.GetComponent<ChampEntity>();

            if (champEntity != null)
            {
                champEntity.ChampData(champ);

                Button champButton = obj.GetComponent<Button>();
                if (champButton != null)
                {
                    champButton.onClick.AddListener(() => GetReferenceInEntity(champEntity.gameObject));
                }

            }

            list.Add(obj);

        }

        Debug.Log("campeões adicionados");

        Debug.Log("Número de partidas carregadas no menu: " + list.Count);
    }

    public void SearchTeams()
    {
        StartCoroutine(LoadTeams());
    }
    IEnumerator LoadTeams()
    {
        yield return new WaitUntil(() => apiManager.listaEquipe.Count > 0);

        CleanEntities();

        foreach (var team in apiManager.listaEquipe)
        {
            GameObject obj = Instantiate(teamPrefab, contentPanel);

            TeamEntity teamEntity = obj.GetComponent<TeamEntity>();

            if (teamEntity != null)
            {
                teamEntity.DataTeam(team);

                Button teamButton = obj.GetComponent<Button>();
                if (teamButton != null)
                {
                    teamButton.onClick.AddListener(() => GetReferenceInEntity(teamEntity.gameObject));
                }

            }

            list.Add(obj);
        }

        Debug.Log("Número de equipes carregadas no menu: " + list.Count);
    }
    public void GetReferenceInEntity(GameObject entity)
    {
        switch(entity.tag)
        {
            case "Item":
                EntityId = entity.GetComponent<ItemEntity>().GetItemIdInEntity();
                ChangeAnalysisScreen(itemAnalysis);
                break;
            case "Champ":
                EntityId = entity.GetComponent<ChampEntity>().GetChampIdInEntity();
                ChangeAnalysisScreen(champAnalysis);
                break;
            case "Player":
                EntityId = entity.GetComponent<PlayerEntity>().GetPlayerIdInEntity();
                ChangeAnalysisScreen(playerAnalysis);
                break;
            case "Team":
                EntityId = entity.GetComponent<TeamEntity>().GetTeamIdInEntity();
                ChangeAnalysisScreen(teamAnalysis);
                break;
            case "Match":
                EntityId = entity.GetComponent<MatchEntity>().GetMatchIdInEntity();
                ChangeAnalysisScreen(matchAnalysis);
                break;
        }

        SelectedEntity = entity;

    }

    private void ChangeAnalysisScreen(GameObject screen)
    {
        analysisButton.onClick.RemoveAllListeners();
        analysisButton.onClick.AddListener(() => mainMenu.ChangeScreen(screen));
    }

    private void OnDisable()
    {
        SelectedEntity = null;
    }

}