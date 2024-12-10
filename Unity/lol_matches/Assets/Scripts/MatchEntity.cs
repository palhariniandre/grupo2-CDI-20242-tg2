using UnityEngine;
using TMPro;

public class MatchEntity : MonoBehaviour
{
    // Referências para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI tempoText;

    // Método para preencher os dados da partida
    public void PreencherPartida(Partida partida)
    {
        nomeText.text = partida.equipeVermelha + " vs " + partida.equipeAzul;
        idText.text = "ID: " + partida.idPartida.ToString();
        dataText.text = "Data: " + partida.data; // Exemplo de formato: DD/MM/AA
        tempoText.text = "Tempo: " + partida.hora; // Exemplo de formato: MM:SS
    }
}
