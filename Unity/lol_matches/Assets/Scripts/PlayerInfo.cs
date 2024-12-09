using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [Header("Informations")]
    [SerializeField] private Image championIcon;
    [SerializeField] private TextMeshProUGUI championName;
    [SerializeField] private Image rankIcon;
    [SerializeField] private TextMeshProUGUI rankName;
    [SerializeField] private Image laneIcon;
    [SerializeField] private TextMeshProUGUI laneName;

    [SerializeField] private Sprite slot1;
    [SerializeField] private Sprite slot2;
    [SerializeField] private Sprite slot3;
    [SerializeField] private Sprite slot4;
    [SerializeField] private Sprite slot5;
    [SerializeField] private Sprite slot6;

    private GameObject currentWindow;

    // ativa a janela de selecao de item/campeao
    public void OpenWindow(GameObject window)
    {
        currentWindow = window;
        currentWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        currentWindow.SetActive(false);
        currentWindow = null;
    }

    // funcao responsavel por selecionar um campo e atualizar na interface
    public void SelectChampion(SelectableElement selectedChampion)
    {
        championIcon.sprite = selectedChampion.GetElementIcon();
        championName.text = selectedChampion.GetElementName();
        CloseWindow();
    }

    public void SelectLane(SelectableElement selectedLane)
    {
        laneIcon.sprite = selectedLane.GetElementIcon();
        laneName.text = selectedLane.GetElementName();
        CloseWindow();
    }
    public void SelectRank(SelectableElement selectedRank)
    {
        rankIcon.sprite = selectedRank.GetElementIcon();
        rankName.text = selectedRank.GetElementName();
        CloseWindow();
    }

    public void SelectItem(SelectableElement selectedItem)
    {
    }
}
