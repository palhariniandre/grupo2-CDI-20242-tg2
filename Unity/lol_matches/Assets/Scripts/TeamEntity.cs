using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Importar para trabalhar com o Button

public class TeamEntity : MonoBehaviour
{
    // Referências para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;

    // Armazenar o ID da equipe
    public int TeamId { get; private set; }

    // Referência para o botão
    public Button selectButton;

    // Referência para o TeamManager
    private TeamManager teamManager;

    void Start()
    {
        // Obter referência do TeamManager
        teamManager = FindObjectOfType<TeamManager>();

        // Verificar se o botão foi atribuído corretamente
        if (selectButton != null)
        {
            // Adicionar o método para ser chamado quando o botão for pressionado
            selectButton.onClick.AddListener(OnSelectTeam);
        }
        else
        {
            Debug.LogError("Botão de seleção não atribuído!");
        }
    }

    // Método para preencher os dados da equipe
    public void DataTeam(Equipe team)
    {
        nomeText.text = team.nome;
        idText.text = "ID: " + team.idEquipe.ToString();

        // Armazenar o ID da equipe
        TeamId = team.idEquipe;
    }

    // Método chamado quando o botão é pressionado
    private void OnSelectTeam()
    {
        // Verifica se o TeamManager está atribuído
        if (teamManager != null)
        {
            // Chama o método no TeamManager para selecionar a equipe
            teamManager.SelectTeam(gameObject);
        }
        else
        {
            Debug.LogError("TeamManager não encontrado!");
        }
    }
}
