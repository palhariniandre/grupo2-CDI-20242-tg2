using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Importar para trabalhar com o Button

public class TeamEntity : MonoBehaviour
{
    // Refer�ncias para os componentes de texto
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI idText;

    // Armazenar o ID da equipe
    public int TeamId { get; private set; }

    // Refer�ncia para o bot�o
    public Button selectButton;

    // Refer�ncia para o TeamManager
    private TeamManager teamManager;

    void Start()
    {
        // Obter refer�ncia do TeamManager
        teamManager = FindObjectOfType<TeamManager>();

        // Verificar se o bot�o foi atribu�do corretamente
        if (selectButton != null)
        {
            // Adicionar o m�todo para ser chamado quando o bot�o for pressionado
            selectButton.onClick.AddListener(OnSelectTeam);
        }
        else
        {
            Debug.LogError("Bot�o de sele��o n�o atribu�do!");
        }
    }

    // M�todo para preencher os dados da equipe
    public void DataTeam(Equipe team)
    {
        nomeText.text = team.nome;
        idText.text = "ID: " + team.idEquipe.ToString();

        // Armazenar o ID da equipe
        TeamId = team.idEquipe;
    }

    // M�todo chamado quando o bot�o � pressionado
    private void OnSelectTeam()
    {
        // Verifica se o TeamManager est� atribu�do
        if (teamManager != null)
        {
            // Chama o m�todo no TeamManager para selecionar a equipe
            teamManager.SelectTeam(gameObject);
        }
        else
        {
            Debug.LogError("TeamManager n�o encontrado!");
        }
    }
}
