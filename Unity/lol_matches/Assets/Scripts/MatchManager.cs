using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MatchManager : MonoBehaviour
{
    [Header("Objects")]
    public Transform contentPanel;
    public GameObject matchPrefab;

    [Header("Entity")]
    [SerializeField] private int selectedMatch;
     
    [Header("Control Variables")]
    private List<GameObject> matchList = new List<GameObject>();
    private ApiManager apiManager;

    public int SelectedMatch { get => selectedMatch; set => selectedMatch = value; }

    void Start()
    {
        // Obter a refer�ncia do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(LoadMatches());
    }

    // M�todo para carregar as partidas
    IEnumerator LoadMatches()
    {
        // Aguarda at� que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conte�do do painel antes de adicionar novas partidas
        CleanMatches();

        // Para cada partida na lista de partidas
        foreach (var partida in apiManager.listaPartidas)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject partidaObj = Instantiate(matchPrefab, contentPanel);

            // Preenche a partida com as informa��es
            MatchEntity matchEntity = partidaObj.GetComponent<MatchEntity>();
            if (matchEntity != null)
            {
                matchEntity.MatchData(partida);
            }

            // Adiciona a inst�ncia na lista para controle
            matchList.Add(partidaObj);
        }

        // Verifique se o n�mero de partidas foi corretamente carregado
        Debug.Log("N�mero de partidas carregadas no menu: " + matchList.Count);
    }

    // M�todo para limpar as inst�ncias de partidas
    private void CleanMatches()
    {
        // Remove todas as inst�ncias da lista
        foreach (var matchEntity in matchList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        matchList.Clear();
    }

    public void SelectMatch()
    {
        MatchEntity matchEntity = EventSystem.current.currentSelectedGameObject.GetComponent<MatchEntity>();
       
        SelectedMatch = matchEntity.GetIdMatch();
    }

    private void OnDisable()
    {
        SelectedMatch = 0;
    }

}
