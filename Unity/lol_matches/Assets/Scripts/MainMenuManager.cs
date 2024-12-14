using System;
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
        // No in�cio, desativa todos os prefabs e inicia o menu principal
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

    // m�todo para avan�ar/voltar uma tela
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

    internal void SelectPlayer(PlayerInfo player)
    {
        throw new NotImplementedException();
    }
}
