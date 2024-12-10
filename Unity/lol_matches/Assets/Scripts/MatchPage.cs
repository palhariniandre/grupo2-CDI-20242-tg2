using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchPage : MonoBehaviour
{
    [Header("Match Info")]
    [SerializeField] private TextMeshProUGUI matchId;
    [SerializeField] private TextMeshProUGUI matchYear;
    [SerializeField] private TextMeshProUGUI matchPhase;
    [SerializeField] private TextMeshProUGUI matchHour;
    [SerializeField] private TextMeshProUGUI matchDuration;
    [SerializeField] private TextMeshProUGUI matchRedScore;
    [SerializeField] private TextMeshProUGUI matchBlueScore;

    [Header("Player Analysis")]
    [SerializeField] private GameObject selectedPlayer;
    private bool isPlayerSelected = false;
    [SerializeField] private Button analyse;

    // atualiza todas as referencia de acordo com o id da partida selecionada no feed
    void Start()
    {
        UpdateMatchInfo();
    }

    private void UpdateMatchInfo()
    {
        // atualiza as informacoes da partida conforme a partida selecionada
        Debug.Log("atualiza informações");
    }

    public void SelectPlayer(GameObject player)
    {
        analyse.interactable = true;
        selectedPlayer = player;
    }

    public void CleanSelection()
    {
        selectedPlayer = null;
        analyse.interactable = false;
    }
}
