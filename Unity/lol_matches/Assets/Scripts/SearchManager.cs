using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject selectedEntity;

    [Header("Control Variables")]
    private List<GameObject> list = new List<GameObject>();
    private ApiManager apiManager;

    public GameObject SelectedEntity { get => selectedEntity; set => selectedEntity = value; }

    void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();

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
            }

            list.Add(obj);
        }

        Debug.Log("Número de partidas carregadas no menu: " + list.Count);
    }
    public void SelectMatch()
    {
        MatchEntity match = EventSystem.current.currentSelectedGameObject.GetComponent<MatchEntity>();

        SelectedEntity = match.gameObject;
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
            }

            list.Add(obj);
        }

        Debug.Log("Número de itens carregados no menu: " + list.Count);
    }
    public void SelectItem()
    {
        ItemEntity item = EventSystem.current.currentSelectedGameObject.GetComponent<ItemEntity>();

        SelectedEntity = item.gameObject;
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
        }

        Debug.Log("Número de jogadores carregados no menu: " + list.Count);
    }
    public void SelectPlayer()
    {
        PlayerEntity player = EventSystem.current.currentSelectedGameObject.GetComponent<PlayerEntity>();

        SelectedEntity = player.gameObject;
    }

    public void SearchChamps()
    {
        StartCoroutine(LoadChamps());
    }
    IEnumerator LoadChamps()
    {
        yield return new WaitUntil(() => apiManager.listaJogadores.Count > 0);

        CleanEntities();

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

        SelectedEntity = champ.gameObject;
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
             }

             list.Add(obj);
         }

        Debug.Log("Número de equipes carregadas no menu: " + list.Count);
    }
    public void SelectTeam()
    {
        TeamEntity team = EventSystem.current.currentSelectedGameObject.GetComponent<TeamEntity>();

        SelectedEntity = team.gameObject;
    }

    private void OnDisable()
    {
        SelectedEntity = null;
    }

}

