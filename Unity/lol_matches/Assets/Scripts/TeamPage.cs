using UnityEngine;
using UnityEngine.UI;

public class TeamPage : MonoBehaviour
{
    [Header("Selected Player")]
    [SerializeField] private GameObject selectedPlayer;
    private bool isPlayerSelected = false;

    [Header("Buttons")]
    [SerializeField] private Button deleteTeam;
    [SerializeField] private Button deletePlayer;
    [SerializeField] private Button editPlayer;
    [SerializeField] private Button savePlayer;
    [SerializeField] private Button addPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInteractivity();
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
