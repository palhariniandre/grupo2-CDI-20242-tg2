using UnityEngine;
using TMPro;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UI;

public class ChampEntity : MonoBehaviour
{
    public TextMeshProUGUI champName;
    public Image champIcon;
    private int id;

    public void ChampData(Partida partida)
    {
       // champName.text = MatchObjects.Instance.GetChampName(00);
        //champIcon.sprite = MatchObjects.Instance.GetChampIcon(00);
    }

    public int GetIdChamp()
    {
        return id;
    }
}
