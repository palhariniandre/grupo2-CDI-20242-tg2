using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChampInfoAnalysis : MonoBehaviour
{
    [Header("Champ Info")]
    [SerializeField] private TextMeshProUGUI champName;
    [SerializeField] private TextMeshProUGUI champClass;
    [SerializeField] private Image champIcon;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;
   // [SerializeField] private 

    private void OnEnable()
    {
        UpdateChampInfoAnalysis(51);
    }

    //tem que receber da view que vai ser criada portanto o parametro irá mudar guys ;-;
    public void UpdateChampInfoAnalysis(int id)
    {
        champName.text = MatchObjects.Instance.GetChampName(id);
        champIcon.sprite = MatchObjects.Instance.GetChampIcon(id);
        Debug.Log("champ:" + champName.text);

    }
}
