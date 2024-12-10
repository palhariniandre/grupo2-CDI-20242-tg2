using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    // Refer�ncia ao painel de conte�do dentro do ScrollView onde as partidas ser�o listadas
    public Transform contentPanel;

    // Refer�ncia ao prefab de partida (PartidaUI)
    public GameObject partidaUIPrefab;

    // Lista que armazenar� as inst�ncias das partidas
    private List<GameObject> partidaUIList = new List<GameObject>();

    // Inst�ncia do ApiManager (se necess�rio)
    private ApiManager apiManager;

    void Start()
    {
        // Obter a refer�ncia do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(CarregarPartidas());
    }

    // M�todo para carregar as partidas
    IEnumerator CarregarPartidas()
    {
        // Aguarda at� que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conte�do do painel antes de adicionar novas partidas
        LimparPartidas();

        // Para cada partida na lista de partidas
        foreach (var partida in apiManager.listaPartidas)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject partidaObj = Instantiate(partidaUIPrefab, contentPanel);

            // Preenche a partida com as informa��es
            MatchEntity matchEntity = partidaObj.GetComponent<MatchEntity>();
            if (matchEntity != null)
            {
                matchEntity.PreencherPartida(partida);
            }

            // Adiciona a inst�ncia na lista para controle
            partidaUIList.Add(partidaObj);
        }

        // Verifique se o n�mero de partidas foi corretamente carregado
        Debug.Log("N�mero de partidas carregadas no menu: " + partidaUIList.Count);
    }

// M�todo para limpar as inst�ncias de partidas
private void LimparPartidas()
    {
        // Remove todas as inst�ncias da lista
        foreach (var matchEntity in partidaUIList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        partidaUIList.Clear();
    }
}
