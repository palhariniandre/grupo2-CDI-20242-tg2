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
        itemName.text = item.nome;
        //itemIcon.sprite = MatchObjects.Instance.GetItemIcon(id); png dos itens precisa ser atualizado
    }

    public int GetIdItem()
    {
        return id;
    }
}
