using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    [SerializeField] private int idPlayer = -1;
    [SerializeField] private JogadorPartida infoPlayer;

    [Header("Team Sprites")]
    [SerializeField] private Sprite blueTeamIcon;
    [SerializeField] private Sprite redTeamIcon;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;
    [SerializeField] private MatchPage matchPage;

    private void OnEnable()
    {
        UpdatePlayerAnalysisInfo(matchPage.SelectedPlayer);
    }

    public void UpdatePlayerAnalysisInfo(PlayerMatchInfo player)
    {
        idPlayer = player.GetPlayerIdInMatch();

        bool isRed = apiManager.ListaJogadoresVermelhos.Any(info => info.idUsuario == idPlayer);
        bool isBlue = apiManager.ListaJogadoresAzul.Any(info => info.idUsuario == idPlayer);

        if (isRed)
        {
            teamIcon.sprite = redTeamIcon;
            infoPlayer = apiManager.ListaJogadoresVermelhos.Single(info => info.idUsuario == idPlayer);
        }
        else if (isBlue)
        {
            teamIcon.sprite = blueTeamIcon;
            infoPlayer = apiManager.ListaJogadoresAzul.Find(info => info.idUsuario == idPlayer);
        }

        playerName.text = infoPlayer.nome;

        championIcon.sprite = MatchObjects.Instance.GetChampIcon(infoPlayer.nomeCampeao);
        championName.text = infoPlayer.nomeCampeao;

        //rankIcon.sprite = MatchObjects.Instance.GetRankIcon(player.ranque);
        rankName.text = infoPlayer.ranque;

        laneIcon.sprite = MatchObjects.Instance.GetLaneIcon(infoPlayer.posicao);
        laneName.text = infoPlayer.posicao;

        // items
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(i);
            itemSlots[i].sprite = MatchObjects.Instance.GetItemIcon(player.GetPlayerItemInMatchId(i));
        }

        gold.text = infoPlayer.ouroAdquirido.ToString();
        kill.text = infoPlayer.kills.ToString();
        death.text = infoPlayer.deaths.ToString();
        assist.text = infoPlayer.assists.ToString();

    }
}
