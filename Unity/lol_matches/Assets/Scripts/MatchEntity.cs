using UnityEngine;
using TMPro;
using System.Diagnostics.CodeAnalysis;

public class MatchEntity : MonoBehaviour
{
    // Referências para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI tempoText;

    private int id;

    // Método para preencher os dados da partida
    public void MatchData(Partida partida)
    {
        nomeText.text = partida.equipeVermelha + " vs " + partida.equipeAzul;
        id = partida.idPartida;
        idText.text = "ID: " + id.ToString();
        dataText.text =  partida.data; // Exemplo de formato: DD/MM/AA
        tempoText.text = partida.hora; // Exemplo de formato: MM:SS
    }

    // retorna o id da partida para acessar o resto das informacoes
    public int GetId()
    {
        return id;
    }
}
