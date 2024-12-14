using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoAnalysis : MonoBehaviour
{
    [Header("Informations")]
    [SerializeField] private Image teamIcon;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Image championIcon;
    [SerializeField] private TextMeshProUGUI championName;
    [SerializeField] private Image rankIcon;
    [SerializeField] private TextMeshProUGUI rankName;
    [SerializeField] private Image laneIcon;
    [SerializeField] private TextMeshProUGUI laneName;
    [SerializeField] private Image[] itemSlots;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI kill;
    [SerializeField] private TextMeshProUGUI death;
    [SerializeField] private TextMeshProUGUI assist;

    private int idPlayer = -1;

    [Header("Team Sprites")]
    [SerializeField] private Sprite blueTeamIcon;
    [SerializeField] private Sprite redTeamIcon;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;

    public void UpdateInfo(PlayerMatchInfo player)
    {
        apiManager = FindObjectOfType<ApiManager>();

        foreach(var bluePlayer in apiManager.ListaJogadoresAzul)
        {
            if(player.GetPlayerId() == bluePlayer.idJogador)
            {
                idPlayer = bluePlayer.idJogador;
            }
        }

        foreach(var genericPlayer in apiManager.listaJogadores)
        {
            if(genericPlayer.idUsuario == idPlayer)
            {
                rankName.text = genericPlayer.ranque;
                //rankIcon.sprite = MatchObjects.Instance.GetChampIcon(genericPlayer.rank);
                laneName.text = genericPlayer.posicao;
                //laneIcon.sprite = MatchObjects.Instance.GetLaneIcon(genericPlayer.lane);
            }
        }
    }
}
