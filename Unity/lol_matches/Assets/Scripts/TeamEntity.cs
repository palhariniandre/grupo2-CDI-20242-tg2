using UnityEngine;
using TMPro;
using System;

public class TeamEntity : MonoBehaviour
{
    // referencia a entidade
    public event Action<int> OnTeamSelected;
    public void SelectTeam()
    {
        OnTeamSelected?.Invoke(id);
    }

    // Refer�ncias para os componentes de texto
    [SerializeField] private TextMeshProUGUI nomeText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private int id;

    // M�todo para preencher os dados da equipe
    public void DataTeam(Equipe team)
    {
        id = team.idEquipe;
        nomeText.text = team.nome;
        idText.text = "#" + id.ToString();
    }

    public int GetTeamIdInEntity()
    {
        return id;
    }
}
