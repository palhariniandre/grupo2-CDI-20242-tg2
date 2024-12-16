using UnityEngine;
using TMPro;
using System.Diagnostics.CodeAnalysis;
using System;

public class MatchEntity : MonoBehaviour
{
    // referencia a entidade
    public event Action<int> OnMatchSelected;
    public void SelectMatch()
    {
        OnMatchSelected?.Invoke(id);     
    }

    // Referências para os componentes de texto
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private TextMeshProUGUI dataText;
    [SerializeField] private TextMeshProUGUI timeText;

    private int id;

    // Método para preencher os dados da partida
    public void MatchData(Partida match)
    {
        nameText.text = match.equipeVermelha + " vs " + match.equipeAzul;
        id = match.idPartida;
        idText.text = "#" + id.ToString();
        dataText.text = match.data; // Exemplo de formato: DD/MM/AA
        timeText.text = match.hora; // Exemplo de formato: MM:SS
    }

    // retorna o id da partida para acessar o resto das informacoes
    public int GetMatchIdInEntity()
    {
        return id;
    }
}
