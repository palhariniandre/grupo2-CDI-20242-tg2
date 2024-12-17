using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchItemPage : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] private TextMeshProUGUI itemId;
    [SerializeField] private Image itemIcon;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI cdr;
    [SerializeField] private TextMeshProUGUI heal;
    [SerializeField] private TextMeshProUGUI life;
    [SerializeField] private TextMeshProUGUI armor;
    [SerializeField] private TextMeshProUGUI mr;
    [SerializeField] private TextMeshProUGUI shield;

    [Header("References")]
    [SerializeField] private SearchManager searchManager;
    [SerializeField] private ApiManager apiManager;

    private void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();
    }

    private void OnEnable()
    {
        UpdateItemInfo(searchManager.EntityId);
    }

    public void UpdateItemInfo(int id)
    {
        var item = apiManager.listaItem.Find(i => i.idItem == id);

        attack.text = item.danAtaque.ToString();
        speed.text = item.velocAtaque.ToString();
        cdr.text = item.regMana.ToString();
        heal.text = item.curaConcedida.ToString();
        life.text = item.vida.ToString();
        armor.text = item.armadura.ToString();
        mr.text = item.resistMagica.ToString();
        shield.text = item.escudoConcedido.ToString();
    }
}
