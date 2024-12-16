using UnityEngine;
using TMPro;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UI;
using System;

public class ChampEntity : MonoBehaviour
{
    // referencia a entidade
    public event Action<int> OnChampSelected;
    public void SelectChamp()
    {
        OnChampSelected?.Invoke(id);
    }

    [SerializeField] private TextMeshProUGUI champName;
    [SerializeField] private Image champIcon;
    [SerializeField] private int id;

    public void ChampData(Campeao champ)
    {
        id = champ.idCampeao;
       champName.text = MatchObjects.Instance.GetChampName(id);
       champIcon.sprite = MatchObjects.Instance.GetChampIcon(champName.text);
    }

    public int GetChampIdInEntity()
    {
        return id;
    }
}
