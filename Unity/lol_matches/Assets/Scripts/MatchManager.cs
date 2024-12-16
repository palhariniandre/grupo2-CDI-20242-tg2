using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        // Obter a referência do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(LoadMatches());
    }

    public void OnEnable()
    {
        SelectedMatch = 0;
    }

    // Método para carregar as partidas
    IEnumerator LoadMatches()
    {
        // Aguarda até que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conteúdo do painel antes de adicionar novas partidas
        CleanMatches();

        // Para cada partida na lista de partidas
        foreach (var partida in apiManager.listaPartidas)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject partidaObj = Instantiate(matchPrefab, contentPanel);

            // Preenche a partida com as informações
            MatchEntity matchEntity = partidaObj.GetComponent<MatchEntity>();
            if (matchEntity != null)
            {
                matchEntity.MatchData(partida);

                Button matchButton = partidaObj.GetComponent<Button>();
                if (matchButton != null)
                {
                    matchButton.onClick.AddListener(() => GetMatchReference(matchEntity));
                }
            }

            // Adiciona a instância na lista para controle
            matchList.Add(partidaObj);

        }

        // Verifique se o número de partidas foi corretamente carregado
        Debug.Log("Número de partidas carregadas no menu: " + matchList.Count);
    }

    // Método para limpar as instâncias de partidas
    private void CleanMatches()
    {
        // Remove todas as instâncias da lista
        foreach (var matchEntity in matchList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        matchList.Clear();
    }

    public void GetMatchReference(MatchEntity matchEntity)
    {
        SelectedMatch = matchEntity.GetMatchIdInEntity();

        apiManager.GetComponent<ApiManager>().RecebaPartidaId(SelectedMatch);

        // Exibe no log o ID do match selecionado
        Debug.Log("Match selecionado: " + SelectedMatch);
    }

}
