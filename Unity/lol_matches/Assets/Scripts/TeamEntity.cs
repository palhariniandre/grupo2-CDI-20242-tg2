using UnityEngine;
using TMPro;

public class TeamEntity : MonoBehaviour
{
    // Referências para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;

    // Método para preencher os dados da partida
    public void DataTeam(Equipe team)
    {
        nomeText.text = team.nome;
        idText.text = "ID: " + team.idEquipe.ToString();
    }
}
