using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMatchInfo : MonoBehaviour
{
    public event Action<int> OnPlayerSelected;
    public void SelectPlayerInMatch()
    {
        OnPlayerSelected?.Invoke(playerId);
        Debug.Log(playerId);
    }

    [SerializeField] private GameObject playerPos;
    [SerializeField] private TextMeshProUGUI playerNick;
    [SerializeField] private TextMeshProUGUI playerKda;
    [SerializeField] private TextMeshProUGUI playerFarm;
    [SerializeField] private int playerId;
    [SerializeField] private int[] itemId;
    public void UpdateMatchData(JogadorPartida player)
    {
        // atualiza os dados do jogador
        playerPos.GetComponent<Image>().sprite = MatchObjects.Instance.GetLaneIcon(player.posicao);
        playerNick.text = player.nome;
        
        string kda = player.kills + "/" + player.deaths + "/" + player.assists;

        playerKda.text = kda.ToString();
        playerFarm.text = player.farm.ToString();

        playerId = player.idUsuario;

        Debug.LogWarning("começando a carregar os itens");

        itemId = new int[]
        {
            player.item1id,
            player.item2id,
            player.item3id,
            player.item4id,
            player.item5id,
            player.item6id
        };

        Debug.Log("carregou os itens");
    }
    public int GetPlayerItemInMatchId(int slot)
    {
        return itemId[slot];
    }
    public int GetPlayerIdInMatch()
    {
        return playerId;
    }
}