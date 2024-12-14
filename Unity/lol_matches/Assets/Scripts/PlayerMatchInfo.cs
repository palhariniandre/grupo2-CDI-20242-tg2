using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMatchInfo : MonoBehaviour
{
    [SerializeField] private GameObject playerPos;
    [SerializeField] private TextMeshProUGUI playerNick;
    [SerializeField] private TextMeshProUGUI playerKda;
    [SerializeField] private TextMeshProUGUI playerFarm;
    [SerializeField] private int playerId;

    public void UpdateData(string pos, string nick, float k, float d, float a, float farm, int idPlayer)
    {
        // atualiza os dados do jogador
        playerPos.GetComponent<Image>().sprite = MatchObjects.Instance.GetLaneIcon(pos);
        playerNick.text = nick;
        
        string kda = k + "/" + d + "/" + a;

        playerKda.text = kda.ToString();
        playerFarm.text = farm.ToString();

        playerId = idPlayer;
    }

    public int GetPlayerId()
    {
        return playerId;
    }
}