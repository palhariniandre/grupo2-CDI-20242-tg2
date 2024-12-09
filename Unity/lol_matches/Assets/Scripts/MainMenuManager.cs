using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Prefabs na Cena")]
    public GameObject[] prefabs;

    [Header("Menu Inicial")]
    public GameObject mainMenu;
    public GameObject currentScreen;

    private void Start()
    {
        // No início, desativa todos os prefabs e inicia o menu principal
        DeactiveAll();
        mainMenu.SetActive(true);
        currentScreen = mainMenu;
    }
    private void DeactiveAll()
    {
        foreach (GameObject prefab in prefabs)
        {
            prefab.SetActive(false);
        }
    }

    // método para avançar/voltar uma tela
    public void ChangeScreen(GameObject screen)
    {
        currentScreen.SetActive(false);
        screen.SetActive(true);
        currentScreen = screen;
    }

    public void ExitGame()
    {
        Debug.Log("Saindo do jogo..."); // Apenas para testes no Editor
        Application.Quit();
    }
}
