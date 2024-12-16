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
    private List<int> excludedTeamIds = new List<int>(); // Lista para armazenar os IDs das equipes exclu�das
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
        // Aguarda at� que o ApiManager tenha preenchido a lista de equipes
        yield return new WaitUntil(() => apiManager.listaEquipe.Count > 0);

        // Limpa o conte�do do painel antes de adicionar novas equipes
        CleanTeams();

        // Para cada equipe na lista de equipes do API
        foreach (var team in apiManager.listaEquipe)
        {
            // Verifica se a equipe est� na lista de exclu�das
            if (excludedTeamIds.Contains(team.idEquipe))
            {
                Debug.Log($"Equipe {team.nome} exclu�da, n�o ser� carregada.");
                continue; // Se a equipe estiver exclu�da, pula para a pr�xima
            }

            // Instancia o prefab da equipe e coloca no painel
            GameObject teamObj = Instantiate(teamPrefab, contentPanel);

            // Preenche a equipe com os dados
            TeamEntity teamEntity = teamObj.GetComponent<TeamEntity>();
            if (teamEntity != null)
            {
                teamEntity.DataTeam(team);
                teamList.Add(teamObj);
            }

            // Adiciona a inst�ncia na lista para controle
        }

        // Verifique se o n�mero de equipes foi corretamente carregado
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

    public void DeleteSelectedTeam()
    {
        if (selectedTeam != null)
        {
            // Obt�m o componente TeamEntity associado ao objeto selecionado
            TeamEntity teamEntity = selectedTeam.GetComponent<TeamEntity>();

            if (teamEntity != null)
            {
                int teamId = teamEntity.TeamId; // Obt�m o ID da equipe
                Debug.Log($"Deletando equipe com ID: {teamId}");

                // Verifica se a API Manager est� dispon�vel antes de chamar o m�todo
                if (apiManager != null)
                {
                    StartCoroutine(DeleteAndReloadTeams(teamId));
                }
                else
                    Debug.LogError("ApiManager n�o est� dispon�vel.");
            }
            else
                Debug.LogError("O GameObject selecionado n�o cont�m o componente TeamEntity.");
        }
        else
            Debug.LogError("Nenhuma equipe selecionada para deletar.");
    }

    private IEnumerator DeleteAndReloadTeams(int teamId)
    {
        // Primeiro, chama a API para deletar a equipe no backend
        yield return StartCoroutine(apiManager.DeleteEquipe(teamId));

        // Verifica se a equipe foi selecionada
        if (selectedTeam != null)
        {
            // Log para debug
            Debug.Log($"Equipe {selectedTeam.name} exclu�da.");

            // Adiciona o ID da equipe � lista de exclu�das
            excludedTeamIds.Add(teamId);

            // Remove a equipe da lista e destrua o GameObject
            teamList.Remove(selectedTeam);
            Destroy(selectedTeam);

            // Limpa a refer�ncia do GameObject selecionado
            selectedTeam = null;

            Debug.Log("Equipe removida da interface.");
        }

        // Recarrega as equipes e atualiza a UI
        yield return StartCoroutine(LoadTeams());
    }




    // M�todo para selecionar uma equipe (usado quando um bot�o � clicado)
    public void SelectTeam(GameObject team)
    {
        if (team != null)
        {
            selectedTeam = team;
            Debug.Log($"Equipe selecionada: {selectedTeam.name}");

            // Obt�m o componente TeamEntity associado ao objeto selecionado
            TeamEntity teamEntity = selectedTeam.GetComponent<TeamEntity>();

            if (teamEntity != null)
            {
                // Acessa o ID da equipe atrav�s da propriedade TeamId
                int teamId = teamEntity.TeamId;
                Debug.Log($"Equipe selecionada com ID: {teamId}");
            }
            else
            {
                Debug.LogError("N�o foi poss�vel acessar o componente TeamEntity.");
            }
        }
        else
        {
            Debug.LogError("Equipe n�o pode ser nula para a sele��o.");
        }
    }



}
