using UnityEngine;
using TMPro;

public class TeamEntity : MonoBehaviour
{
    // Referências para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;
    private int id;
    // Método para preencher os dados da partida
    public void DataTeam(Equipe team)
    {
        nomeText.text = team.nome;
        id = team.idEquipe;
        idText.text = "ID: " + id.ToString();
    }
    
    public int GetIdTeam()
    {
        return id;
    }
}
