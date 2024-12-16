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
    private List<int> excludedTeamIds = new List<int>(); // Lista para armazenar os IDs das equipes excluídas
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
        // Aguarda até que o ApiManager tenha preenchido a lista de equipes
        yield return new WaitUntil(() => apiManager.listaEquipe.Count > 0);

        // Limpa o conteúdo do painel antes de adicionar novas equipes
        CleanTeams();

        // Para cada equipe na lista de equipes do API
        foreach (var team in apiManager.listaEquipe)
        {
            // Verifica se a equipe está na lista de excluídas
            if (excludedTeamIds.Contains(team.idEquipe))
            {
                Debug.Log($"Equipe {team.nome} excluída, não será carregada.");
                continue; // Se a equipe estiver excluída, pula para a próxima
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

            // Adiciona a instância na lista para controle
        }

        // Verifique se o número de equipes foi corretamente carregado
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

    public void DeleteSelectedTeam()
    {
        if (selectedTeam != null)
        {
            // Obtém o componente TeamEntity associado ao objeto selecionado
            TeamEntity teamEntity = selectedTeam.GetComponent<TeamEntity>();

            if (teamEntity != null)
            {
                int teamId = teamEntity.TeamId; // Obtém o ID da equipe
                Debug.Log($"Deletando equipe com ID: {teamId}");

                // Verifica se a API Manager está disponível antes de chamar o método
                if (apiManager != null)
                {
                    StartCoroutine(DeleteAndReloadTeams(teamId));
                }
                else
                    Debug.LogError("ApiManager não está disponível.");
            }
            else
                Debug.LogError("O GameObject selecionado não contém o componente TeamEntity.");
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
            Debug.Log($"Equipe {selectedTeam.name} excluída.");

            // Adiciona o ID da equipe à lista de excluídas
            excludedTeamIds.Add(teamId);

            // Remove a equipe da lista e destrua o GameObject
            teamList.Remove(selectedTeam);
            Destroy(selectedTeam);

            // Limpa a referência do GameObject selecionado
            selectedTeam = null;

            Debug.Log("Equipe removida da interface.");
        }

        // Recarrega as equipes e atualiza a UI
        yield return StartCoroutine(LoadTeams());
    }




    // Método para selecionar uma equipe (usado quando um botão é clicado)
    public void SelectTeam(GameObject team)
    {
        if (team != null)
        {
            selectedTeam = team;
            Debug.Log($"Equipe selecionada: {selectedTeam.name}");

            // Obtém o componente TeamEntity associado ao objeto selecionado
            TeamEntity teamEntity = selectedTeam.GetComponent<TeamEntity>();

            if (teamEntity != null)
            {
                // Acessa o ID da equipe através da propriedade TeamId
                int teamId = teamEntity.TeamId;
                Debug.Log($"Equipe selecionada com ID: {teamId}");
            }
            else
            {
                Debug.LogError("Não foi possível acessar o componente TeamEntity.");
            }
        }
        else
        {
            Debug.LogError("Equipe não pode ser nula para a seleção.");
        }
    }



}
