using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerId;
    int id;

    public void PlayerData(Jogador jogador)
    {
        playerName.text = jogador.nome;
        id = jogador.idUsuario;
        playerId.text = id.ToString();
    }
    public int GetIdPlayer()
    {
        return id;
    }
}
