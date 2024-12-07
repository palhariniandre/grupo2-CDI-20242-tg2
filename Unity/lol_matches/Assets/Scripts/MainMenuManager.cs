using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Prefabs na Cena")]
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    [Header("Menu Inicial")]
    public GameObject menuInicial;

    private void Start()
    {
        // No início, desativa todos os prefabs
        DesativarTodosPrefabs();
    }

    public void AtivarPrefab1()
    {
        DesativarTodosPrefabs();
        prefab1.SetActive(true);
        menuInicial.SetActive(false);
    }

    public void AtivarPrefab2()
    {
        DesativarTodosPrefabs();
        prefab2.SetActive(true);
        menuInicial.SetActive(false);
    }

    public void AtivarPrefab3()
    {
        DesativarTodosPrefabs();
        prefab3.SetActive(true);
        menuInicial.SetActive(false);
    }

    private void DesativarTodosPrefabs()
    {
        prefab1.SetActive(false);
        prefab2.SetActive(false);
        prefab3.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Saindo do jogo..."); // Apenas para testes no Editor
        Application.Quit();
    }
}
