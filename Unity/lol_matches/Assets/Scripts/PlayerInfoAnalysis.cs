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
        //apiManager = FindObjectOfType<ApiManager>();
        idPlayer = player.GetPlayerId();

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
        else
        {
            Jogador jogador = apiManager.listaJogadores.Find(info => info.idUsuario == idPlayer);

            playerName.text = jogador.nome;
            rankName.text = jogador.ranque;
            laneName.text = jogador.posicao;
            //championName.text = MatchObjects.Instance.GetChampName(67);
            //championIcon.sprite = MatchObjects.Instance.GetChampIcon(101);
            Debug.LogError("nenhuma referÍncia");
        }

        UpdateInterface(infoPlayer);

    }
    private void UpdateInterface(JogadorPartida player)
    {
        playerName.text = player.nome;

        championIcon.sprite = MatchObjects.Instance.GetChampIcon(player.nomeCampeao);
        championName.text = player.nomeCampeao;

        rankIcon.sprite = MatchObjects.Instance.GetRankIcon(player.ranque);
        rankName.text = player.ranque;

        laneIcon.sprite = MatchObjects.Instance.GetLaneIcon(player.posicao);
        laneName.text = player.posicao;

        //itemSlots;

        gold.text = player.ouroAdquirido.ToString();
        kill.text = player.kills.ToString();
        death.text = player.deaths.ToString();
        assist.text = player.assists.ToString();

        Debug.Log("oiiiii");
    }
}
