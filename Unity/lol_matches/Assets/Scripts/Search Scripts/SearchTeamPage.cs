using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SearchTeamPage : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] private TextMeshProUGUI teamName;

    [Header("Attributes")]
    [SerializeField] private SearchTeamInfo[] teamInfo;

    [Header("References")]
    [SerializeField] private SearchManager searchManager;
    [SerializeField] private ApiManager apiManager;

    private void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();
    }

    private void OnEnable()
    {
        UpdateTeamInfo(searchManager.EntityId);
    }

    public void UpdateTeamInfo(int id)
    {
        var players = apiManager.listaJogadores.FindAll(p => p.idEquipe == id);

        for (int i = 0; i < players.Count; i++)
        {
            teamInfo[i].UpdatePlayerInfo(players[i]);
            Debug.Log(players[i].nome);
        }
    }
}

[Serializable] 
public class SearchTeamInfo
{
    [SerializeField] private TextMeshProUGUI nickPlayer;
    [SerializeField] private TextMeshProUGUI killMedia;
    [SerializeField] private TextMeshProUGUI deathMedia;
    [SerializeField] private TextMeshProUGUI assistMedia;
    [SerializeField] private TextMeshProUGUI goldMedia;

    [SerializeField] private Image rankIcon;
    [SerializeField] private TextMeshProUGUI rankText;

    [SerializeField] private Image laneIcon;
    [SerializeField] private TextMeshProUGUI laneText;
    
    public void UpdatePlayerInfo(Jogador player)
    {
        Debug.Log(player.nome);

        nickPlayer.text = player.nome;
        killMedia.text = player.mediaKills.ToString();
        deathMedia.text = player.mediaDeaths.ToString();
        assistMedia.text = player.mediaAssists.ToString();
        goldMedia.text = player.mediaOuroAdquirido.ToString();

        rankIcon.sprite = MatchObjects.Instance.GetRankIcon(player.ranque);
        rankText.text = player.ranque;
    }

    public void UpdateLaneInfo(Jogador player)
    {
       if(laneIcon != null || laneText != null)
        {
            laneIcon.sprite = MatchObjects.Instance.GetLaneIcon(player.posicao);
            laneText.text = player.posicao;
        }
    }

}
