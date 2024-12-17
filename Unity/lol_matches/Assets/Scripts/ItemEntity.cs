using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntity : MonoBehaviour
{
    // referencia a entidade
    public event Action<int> OnItemSelected;
    public void SelectItem()
    {
        OnItemSelected?.Invoke(id);
    }

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private int id;

    public void ItemData(Item item)
    {
        id = item.idItem;
        itemName.text = item.nome;
        itemIcon.sprite = MatchObjects.Instance.GetItemIcon(id);
    }

    public int GetItemIdInEntity()
    {
        return id;
    }
}
