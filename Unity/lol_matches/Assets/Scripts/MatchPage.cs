using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class MatchPage : MonoBehaviour
{
    [Header("Match Info")]
    [SerializeField] private TextMeshProUGUI matchId;
    [SerializeField] private TextMeshProUGUI matchYear;
    [SerializeField] private TextMeshProUGUI matchPhase;
    [SerializeField] private TextMeshProUGUI matchHour;
    [SerializeField] private TextMeshProUGUI matchDuration;
    [SerializeField] private TextMeshProUGUI matchScore;

    [Header("Blue Team Players")]
    [SerializeField] private TextMeshProUGUI blueTeamName;
    [SerializeField] private PlayerMatchInfo topBlue;
    [SerializeField] private PlayerMatchInfo jgBlue;
    [SerializeField] private PlayerMatchInfo midBlue;
    [SerializeField] private PlayerMatchInfo adcBlue;
    [SerializeField] private PlayerMatchInfo supBlue;

    [Header("Red Team Players")]
    [SerializeField] private TextMeshProUGUI redTeamName;
    [SerializeField] private PlayerMatchInfo topRed;
    [SerializeField] private PlayerMatchInfo jgRed;
    [SerializeField] private PlayerMatchInfo midRed;
    [SerializeField] private PlayerMatchInfo adcRed;
    [SerializeField] private PlayerMatchInfo supRed;

    [Header("Player Analysis")]
    [SerializeField] private PlayerMatchInfo selectedPlayer;
    [SerializeField] private bool isPlayerSelected = false;
    [SerializeField] private Button analyse;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;
    [SerializeField] private MatchManager matchManager;
    [SerializeField] private MainMenuManager mainMenu;
    public PlayerMatchInfo SelectedPlayer { get => selectedPlayer; set => selectedPlayer = value; }

    // atualiza todas as referencia de acordo com o id da partida selecionada no feed

    private void OnDisable()
    {
        isPlayerSelected = false;
        analyse.interactable = false;
    }

    void OnEnable()
    {
        SelectedPlayer = null;

        apiManager = FindObjectOfType<ApiManager>();

        UpdateMatchInfo(matchManager.SelectedMatch);
    }

    // atualiza as informacoes da partida conforme a partida selecionada
    public void UpdateMatchInfo(float idMatch)
    {
        // Encontre a partida com o id correspondente
        var partida = apiManager.listaPartidas.Find(p => p.idPartida == idMatch);
        if (partida != null)
        {
            // Exibe as informações da partida
            redTeamName.text = partida.equipeVermelha;
            blueTeamName.text = partida.equipeAzul;

            matchId.text = "ID: " + partida.idPartida.ToString();
            matchYear.text = partida.data;
            matchPhase.text = partida.etapa;
            matchHour.text = partida.hora;
            matchDuration.text = partida.duracao; // Corrigido para a variável correta
            matchScore.text = partida.placar.ToString();

            // Atualiza os jogadores das equipes
            foreach (var player in apiManager.listaJogadores)
            {
                if (player.equipe == partida.equipeAzul)
                {
                    UpdateBlueTeam(player);
                }
                else if (player.equipe == partida.equipeVermelha)
                {
                    UpdateRedTeam(player);
                }
            }
        }
        else
        {
            Debug.LogWarning("Partida não encontrada para o ID: " + idMatch);
        }
    }

    // atualiza o dado de cada player de acordo com a posicao da equipe azul e vermelha PRECISA TIRAR ESSES RANDOM BELEZA?
    private void UpdateBlueTeam(Jogador player)
    {
        Random random = new Random();

        switch (player.posicao)
        {
            case "Top":
                topBlue.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Jungle":
                jgBlue.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Mid":
                midBlue.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "ADC":
                adcBlue.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Support":
                supBlue.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
        }
    }
    private void UpdateRedTeam(Jogador player)
    {
        Random random = new Random();

        switch (player.posicao)
        {
            case "Top":
                topRed.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Jungle":
                jgRed.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Mid":
                midRed.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "ADC":
                adcRed.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
            case "Support":
                supRed.UpdateData(player.posicao, player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300), player.idUsuario);
                break;
        }
    }

    public void SelectPlayer(PlayerMatchInfo player)
    {
        analyse.interactable = true;
        SelectedPlayer = player;
    }

    public void CleanSelection()
    {
        SelectedPlayer = null;
        analyse.interactable = false;
    }
}
