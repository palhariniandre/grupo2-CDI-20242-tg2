using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeamPage : MonoBehaviour
{
    [Header("Selected Player")]
    [SerializeField] private GameObject selectedPlayer;
    [SerializeField] private int id;
    private bool isPlayerSelected = false;

    [Header("Buttons")]
    [SerializeField] private Button deleteTeam;
    [SerializeField] private Button deletePlayer;
    [SerializeField] private Button editPlayer;
    [SerializeField] private Button savePlayer;
    [SerializeField] private Button addPlayer;

    [SerializeField] private SearchTeamInfo[] players;
    
    [SerializeField] private TeamManager teamManager;
    [SerializeField] private ApiManager apiManager;
    void Start()
    {
        apiManager = FindAnyObjectByType<ApiManager>();
    }

    private void OnEnable()
    {
        if (teamManager != null && apiManager != null)
        {
            id = teamManager.EntityId;
            UpdateTeamInfo(id);
        }
        else
        {
            Debug.LogError("teamManager ou apiManager não inicializado!");
        }
    }

    private void UpdateTeamInfo(int teamId)
    {
        var playersList = apiManager.listaJogadores.FindAll(p => p.idEquipe == teamId);
        
        Debug.Log(playersList.Count);

        for (int i = 0; i < playersList.Count && i < players.Length; i++)
        {
            Debug.Log(playersList[i].nome);
            players[i].UpdatePlayerInfo(playersList[i]);
            players[i].UpdateLaneInfo(playersList[i]);
        }
    }

    // atualiza a interatividade dos botões
    private void UpdateInteractivity()
    {
        deletePlayer.interactable = isPlayerSelected;
        editPlayer.interactable = isPlayerSelected;
        savePlayer.interactable = isPlayerSelected;
        addPlayer.interactable = isPlayerSelected;
    }

    // seta o player selecionado
    public void SelectPlayer(GameObject player)
    {
        selectedPlayer = player;
        isPlayerSelected = true;
        addPlayer.interactable = true;
    }

    // limpa a selecao do player
    public void CleanSelection()
    {
        selectedPlayer = null;
        isPlayerSelected = false;
    }

    // deleta os dados do player selecionado
    public void DeletePlayer()
    {
        CleanSelection();
    }
}
