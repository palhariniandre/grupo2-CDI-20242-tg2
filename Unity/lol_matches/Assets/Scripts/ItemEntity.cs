using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntity : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image itemIcon;
    private int id;

    public void ItemData(Item item)
    {
        id = item.idItem;
        itemName.text = name;
        itemIcon.sprite = MatchObjects.Instance.GetItemIcon(id);
    }

    public int GetIdItem()
    {
        return id;
    }
}
