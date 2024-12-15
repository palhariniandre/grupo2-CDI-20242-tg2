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

        StartCoroutine(LoadEntities());
    }

    IEnumerator LoadEntities()
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

        Debug.Log("Número de entidades carregadas no menu: " + list.Count);
    }

    private void CleanEntities()
    {
        foreach (var matchEntity in list)
        {
            Destroy(matchEntity);
        }

        list.Clear();
    }

    public void SelectItem()
    {
        ItemEntity item = EventSystem.current.currentSelectedGameObject.GetComponent<ItemEntity>();

        SelectedEntity = item.gameObject;
    }
    public void SelectMatch()
    {
        MatchEntity match = EventSystem.current.currentSelectedGameObject.GetComponent<MatchEntity>();

        SelectedEntity = match.gameObject;
    }
    public void SelectPlayer()
    {
        PlayerEntity player = EventSystem.current.currentSelectedGameObject.GetComponent<PlayerEntity>();

        SelectedEntity = player.gameObject;
    }
    public void SelectChamp()
    {
        ChampEntity champ = EventSystem.current.currentSelectedGameObject.GetComponent<ChampEntity>();

        SelectedEntity = champ.gameObject;
    }
    private void OnDisable()
    {
        SelectedEntity = null;
    }

}

