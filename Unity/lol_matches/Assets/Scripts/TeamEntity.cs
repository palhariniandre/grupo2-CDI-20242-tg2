using UnityEngine;
using TMPro;

public class TeamEntity : MonoBehaviour
{
    // Refer�ncias para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;

    // M�todo para preencher os dados da partida
    public void DataTeam(Equipe team)
    {
        nomeText.text = team.nome;
        idText.text = "ID: " + team.idEquipe.ToString();
    }
}
