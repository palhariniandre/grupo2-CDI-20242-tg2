using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeamManager : MonoBehaviour
{
    [Header("Objects")]
    public Transform contentPanel;
    public GameObject teamPrefab;

    [Header("Entity")]
    [SerializeField] private GameObject selectedTeam;

    [Header("Control Variables")]
    private List<GameObject> teamList = new List<GameObject>();
    private ApiManager apiManager;

    void Start()
    {
        // Obter a referência do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(LoadTeams());
    }

    // Método para carregar as partidas
    IEnumerator LoadTeams()
    {
        // Aguarda até que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conteúdo do painel antes de adicionar novas partidas
        CleanTeams();

        // Para cada partida na lista de partidas
        foreach (var team in apiManager.listaEquipe)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject teamObj = Instantiate(teamPrefab, contentPanel);

            // Preenche a partida com as informações
            TeamEntity teamEntity = teamObj.GetComponent<TeamEntity>();
            if (teamEntity != null)
            {
                teamEntity.DataTeam(team);
            }

            // Adiciona a instância na lista para controle
            teamList.Add(teamObj);
        }

        // Verifique se o número de partidas foi corretamente carregado
        Debug.Log("Número de equipes carregadas no menu: " + teamList.Count);
    }

    // Método para limpar as instâncias de partidas
    private void CleanTeams()
    {
        // Remove todas as instâncias da lista
        foreach (var matchEntity in teamList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        teamList.Clear();
    }
}
