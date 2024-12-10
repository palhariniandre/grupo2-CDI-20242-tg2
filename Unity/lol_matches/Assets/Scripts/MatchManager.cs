using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    // Referência ao painel de conteúdo dentro do ScrollView onde as partidas serão listadas
    public Transform contentPanel;

    // Referência ao prefab de partida (PartidaUI)
    public GameObject partidaUIPrefab;

    // Lista que armazenará as instâncias das partidas
    private List<GameObject> partidaUIList = new List<GameObject>();

    // Instância do ApiManager (se necessário)
    private ApiManager apiManager;

    void Start()
    {
        // Obter a referência do ApiManager
        apiManager = FindObjectOfType<ApiManager>();

        // Iniciar a rotina para carregar as partidas
        StartCoroutine(CarregarPartidas());
    }

    // Método para carregar as partidas
    IEnumerator CarregarPartidas()
    {
        // Aguarda até que o ApiManager tenha preenchido a lista de partidas
        yield return new WaitUntil(() => apiManager.listaPartidas.Count > 0);

        // Limpa o conteúdo do painel antes de adicionar novas partidas
        LimparPartidas();

        // Para cada partida na lista de partidas
        foreach (var partida in apiManager.listaPartidas)
        {
            // Instancia o prefab de partida e o coloca no painel
            GameObject partidaObj = Instantiate(partidaUIPrefab, contentPanel);

            // Preenche a partida com as informações
            MatchEntity matchEntity = partidaObj.GetComponent<MatchEntity>();
            if (matchEntity != null)
            {
                matchEntity.PreencherPartida(partida);
            }

            // Adiciona a instância na lista para controle
            partidaUIList.Add(partidaObj);
        }

        // Verifique se o número de partidas foi corretamente carregado
        Debug.Log("Número de partidas carregadas no menu: " + partidaUIList.Count);
    }

// Método para limpar as instâncias de partidas
private void LimparPartidas()
    {
        // Remove todas as instâncias da lista
        foreach (var matchEntity in partidaUIList)
        {
            Destroy(matchEntity);
        }

        // Limpa a lista
        partidaUIList.Clear();
    }
}
