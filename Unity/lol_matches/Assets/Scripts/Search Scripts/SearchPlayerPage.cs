using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchPlayerPage : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI playerName;

    [Header("Medias")]
    [SerializeField] private TextMeshProUGUI kill;
    [SerializeField] private TextMeshProUGUI death;
    [SerializeField] private TextMeshProUGUI assist;
    [SerializeField] private TextMeshProUGUI gold;

    [Header("Lane")]
    [SerializeField] private Image laneIcon;
    [SerializeField] private TextMeshProUGUI laneText;

    [Header("References")]
    [SerializeField] private SearchManager searchManager;
    [SerializeField] private ApiManager apiManager;

    private void Start()
    {
        apiManager = FindObjectOfType<ApiManager>();
    }

    private void OnEnable()
    {
        if(searchManager.EntityId != 0)
        {
            UpdatePlayerInfo(searchManager.EntityId);
        }
        else
        {
            Debug.Log("nada selecionado");
        }
    }

    public void UpdatePlayerInfo(int id)
    {
        var player = apiManager.listaJogadores.Find(p => p.idUsuario == id);

        playerName.text = player.nome;

        kill.text = player.mediaKills.ToString();
        death.text = player.mediaDeaths.ToString();
        assist.text = player.mediaAssists.ToString();
        gold.text = player.mediaOuroAdquirido.ToString();

        laneIcon.sprite = MatchObjects.Instance.GetLaneIcon(player.posicao);
        laneText.text = player.posicao;
    }
}
