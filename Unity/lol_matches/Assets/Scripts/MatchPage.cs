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
    [SerializeField] private IndividualInfo topBlue;
    [SerializeField] private IndividualInfo jgBlue;
    [SerializeField] private IndividualInfo midBlue;
    [SerializeField] private IndividualInfo adcBlue;
    [SerializeField] private IndividualInfo supBlue;

    [Header("Red Team Players")]
    [SerializeField] private TextMeshProUGUI redTeamName;
    [SerializeField] private IndividualInfo topRed;
    [SerializeField] private IndividualInfo jgRed;
    [SerializeField] private IndividualInfo midRed;
    [SerializeField] private IndividualInfo adcRed;
    [SerializeField] private IndividualInfo supRed;

    [Header("Player Analysis")]
    [SerializeField] private GameObject selectedPlayer;
    [SerializeField] private bool isPlayerSelected = false;
    [SerializeField] private Button analyse;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;
    [SerializeField] private MatchManager matchManager;

    // atualiza todas as referencia de acordo com o id da partida selecionada no feed

    private void OnDisable()
    {
        selectedPlayer = null;
        isPlayerSelected = false;
        analyse.interactable = false;
    }

    void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();

        UpdateMatchInfo(matchManager.SelectedMatch);
    }

    // atualiza as informacoes da partida conforme a partida selecionada
    private void UpdateMatchInfo(float idMatch)
    {
        foreach (var partida in apiManager.listaPartidas)
        {
            redTeamName.text = partida.equipeVermelha;
            blueTeamName.text = partida.equipeAzul;

            if (partida.idPartida == idMatch)
            {
                matchId.text = "ID: " + partida.idPartida.ToString();
                matchYear.text = partida.data;
                matchPhase.text = partida.etapa;
                matchHour.text = partida.hora;
                matchDuration.text = partida.hora;
                matchScore.text = partida.placar.ToString();
            }

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

        Debug.Log("atualiza informações");
    }

    // atualiza o dado de cada player de acordo com a posicao da equipe azul e vermelha PRECISA TIRAR ESSES RANDOM BELEZA?
    private void UpdateBlueTeam(Jogador player)
    {
        Random random = new Random();

        switch (player.posicao)
        {
            case "Top":
                topBlue.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Jungle":
                jgBlue.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Mid":
                midBlue.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "ADC":
                adcBlue.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Support":
                supBlue.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
        }
    }
    private void UpdateRedTeam(Jogador player)
    {
        Random random = new Random();

        switch (player.posicao)
        {
            case "Top":
                topRed.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Jungle":
                jgRed.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Mid":
                midRed.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "ADC":
                adcRed.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
            case "Support":
                supRed.UpdateData(player.nome, random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(0, 300));
                break;
        }
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

[Serializable]
public class IndividualInfo
{
    [SerializeField] TextMeshProUGUI playerNick;
    [SerializeField] TextMeshProUGUI playerKda;
    [SerializeField] TextMeshProUGUI playerFarm;
    public void UpdateData(string nick, float k, float d, float a, float farm)
    {
        // atualiza os dados do jogador
        playerNick.text = nick;
        string kda = k + "/" + d + "/" + a;
        playerKda.text = kda.ToString();
        playerFarm.text = farm.ToString();
    }
}
