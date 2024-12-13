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
        // Obter a refer�ncia do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(LoadTeams());
    }

    // M�todo para carregar as partidas
    IEnumerator LoadTeams()
    {
        // Aguarda at� que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conte�do do painel antes de adicionar novas partidas
        CleanTeams();

        // Para cada partida na lista de partidas
        foreach (var team in apiManager.listaEquipe)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject teamObj = Instantiate(teamPrefab, contentPanel);

            // Preenche a partida com as informa��es
            TeamEntity teamEntity = teamObj.GetComponent<TeamEntity>();
            if (teamEntity != null)
            {
                teamEntity.DataTeam(team);
            }

            // Adiciona a inst�ncia na lista para controle
            teamList.Add(teamObj);
        }

        // Verifique se o n�mero de partidas foi corretamente carregado
        Debug.Log("N�mero de equipes carregadas no menu: " + teamList.Count);
    }

    // M�todo para limpar as inst�ncias de partidas
    private void CleanTeams()
    {
        // Remove todas as inst�ncias da lista
        foreach (var matchEntity in teamList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        teamList.Clear();
    }
}
