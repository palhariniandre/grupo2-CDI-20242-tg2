using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    private int id;

    public void PlayerData(string name)
    {
        playerName.text = name;
    }

    public int GetIdPlayer()
    {
        return id;
    }
}
