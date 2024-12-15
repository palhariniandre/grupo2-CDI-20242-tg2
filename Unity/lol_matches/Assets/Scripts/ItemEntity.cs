using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntity : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image itemIcon;
    private int id;

    public void ItemData(string name, Sprite icon)
    {
        itemName.text = name;
        itemIcon.sprite = icon;
    }

    public int GetIdItem()
    {
        return id;
    }
}
