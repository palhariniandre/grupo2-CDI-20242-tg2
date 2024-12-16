using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchChampPage : MonoBehaviour
{
    [SerializeField] private int id;

    [Header("Item Info")]
    [SerializeField] private TextMeshProUGUI champId;
    [SerializeField] private Image champIcon;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI champName;
    [SerializeField] private TextMeshProUGUI times;
    [SerializeField] private Image classIcon;
    [SerializeField] private TextMeshProUGUI classText;

    [Header("References")]
    [SerializeField] private SearchManager searchManager;
    [SerializeField] private ApiManager apiManager;

    [SerializeField] private Sprite marksmanIcon;
    [SerializeField] private Sprite mageIcon;
    [SerializeField] private Sprite fighterIcon;
    [SerializeField] private Sprite supportIcon;
    [SerializeField] private Sprite assassinIcon;

    private void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();

        id = searchManager.EntityId;
    }

    private void OnEnable()
    {
        UpdateChampInfo(searchManager.EntityId);
    }

    public void UpdateChampInfo(int id)
    {
        var champ = apiManager.listaCampeao.Find(c => c.idCampeao == id);

        champId.text = champ.idCampeao.ToString();
        champName.text = MatchObjects.Instance.GetChampName(id);
        champIcon.sprite = MatchObjects.Instance.GetChampIcon(champName.text);

        UpdateClass(champ.classeCampeao);

    }

    public void UpdateClass(string className)
    {
        switch (className)
        {
            case "Marksman":
                classIcon.sprite = marksmanIcon;
                classText.text = "Atirador";
                break;
            case "Fighter":
                classIcon.sprite = assassinIcon;
                classText.text = "Lutador";
                break;
            case "Mago":
                classIcon.sprite = mageIcon;
                classText.text = "Mago";
                break;
            case "Tank":
                classIcon.sprite = fighterIcon;
                classText.text = "Lutador";
                break;
            case "Support":
                classIcon.sprite = supportIcon;
                classText.text = "Suporte";
                break;
            default:
                break;
        }
    }
}
