using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [Header("Informations")]
    [SerializeField] private Image teamIcon;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Image championIcon;
    [SerializeField] private TextMeshProUGUI championName;
    [SerializeField] private Image rankIcon;
    [SerializeField] private TextMeshProUGUI rankName;
    [SerializeField] private Image laneIcon;
    [SerializeField] private TextMeshProUGUI laneName;
    [SerializeField] private Image[] itemSlots;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI kill;
    [SerializeField] private TextMeshProUGUI death;
    [SerializeField] private TextMeshProUGUI assist;

    private int idPlayer = -1;

    [Header("Windows")]
    [SerializeField] private GameObject championWindow;
    [SerializeField] private GameObject laneWindow;
    [SerializeField] private GameObject rankWindow;
    [SerializeField] private GameObject itemWindow;

    [Header("Buttons")]
    [SerializeField] private Button saveButton;

    [Header("Local Control Variables")]
    [SerializeField] private GameObject currentWindow;
    [SerializeField] private GameObject currentItemSlot;
    [SerializeField] private bool isAnalyzing;

    [Header("Team Sprites")]
    [SerializeField] private Sprite blueTeamIcon;
    [SerializeField] private Sprite redTeamIcon;

    [Header("References")]
    [SerializeField] private ApiManager apiManager;

    [SerializeField] private GameObject previousScreen;

    // ativa a janela de selecao de item/campeao
    public void OpenWindow(GameObject window)
    {
        CloseWindows();
        currentWindow = window;
        currentWindow.SetActive(true);
    }
    public void OpenItemSelection(GameObject itemSlot)
    {
        OpenWindow(itemWindow);
        currentItemSlot = itemSlot;
    }
    public void CloseWindows()
    {
        championWindow.SetActive(false);
        laneWindow.SetActive(false);
        rankWindow.SetActive(false);
        itemWindow.SetActive(false);
        currentWindow = null;
        currentItemSlot = null;
    }

    // funcao responsavel por selecionar um campo e atualizar na interface
    public void SelectChampion(SelectableElement selectedChampion)
    {
        championIcon.sprite = selectedChampion.GetElementIcon();
        championName.text = selectedChampion.GetElementName();
        saveButton.interactable = true;
    }

    public void SelectLane(SelectableElement selectedLane)
    {
        laneIcon.sprite = selectedLane.GetElementIcon();
        laneName.text = selectedLane.GetElementName();
        saveButton.interactable = true;
    }
    public void SelectRank(SelectableElement selectedRank)
    {
        rankIcon.sprite = selectedRank.GetElementIcon();
        rankName.text = selectedRank.GetElementName();
        saveButton.interactable = true;
    }

    public void SelectItem(SelectableElement selectedItem)
    {
        currentItemSlot.GetComponent<Image>().sprite = selectedItem.GetElementIcon();
        saveButton.interactable = true;
    }

    public void UpdateInfo(PlayerMatchInfo player)
    {
    }
    public void Save()
    {
        // função generica para salvar as informacoes
        saveButton.interactable = false;
    }

    public void Return()
    {
        MenuManager.Instance.ChangeScreen(previousScreen);
    }
}
