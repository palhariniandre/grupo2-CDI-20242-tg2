using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{    
    // referencia a entidade
    public event Action<int> OnPlayerSelected;
    public void SelectPlayer()
    {
        OnPlayerSelected?.Invoke(id);
    }

    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI idPlayer;
    [SerializeField] private int id;

    public void PlayerData(Jogador player)
    {
        id = player.idUsuario;
        idPlayer.text = "#" + id;
        playerName.text = player.nome;
    }

    public int GetPlayerIdInEntity()
    {
        return id;
    }
}
