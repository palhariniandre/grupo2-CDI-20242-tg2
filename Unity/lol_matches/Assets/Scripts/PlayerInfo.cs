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

    private void Start()
    {
        // incializa a janela de campeao com os dados do banco de dados de acordo com o id
        UpdateInfo();
    }

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

    public void UpdateInfo()
    {
        // se eh apenas uma tela de analise deve ser setada para true no inspector e so atualizar as informacoes
        if (isAnalyzing)
        {
            // atualiza as informacoes do jogador de acordo com a equipe
            // if(bd.team == "blue")
            // { teamIcon.sprite = blueTeamIcon; }
            // else
            // { teamIcon.sprite = redTeamIcon; }
        }
    }

    public void Save()
    {
        // função generica para salvar as informacoes
        saveButton.interactable = false;
    }
}
