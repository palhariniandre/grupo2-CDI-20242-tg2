using System;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Prefabs na Cena")]
    public GameObject[] prefabs;

    [Header("Menu Inicial")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject currentScreen;

    private static MenuManager _instance;

    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MenuManager>();

                if (_instance == null)
                {
                    Debug.LogError("Não foi encontrado nenhum objeto MainMenuManager na cena!");
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        // No inicio, desativa todos os prefabs e inicia o menu principal
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

    // metodo para avancar/voltar uma tela
    public void ChangeScreen(GameObject screen)
    {
        currentScreen.SetActive(false);
        screen.SetActive(true);
        currentScreen = screen;
    }

    public void MainMenuScreen()
    {
        currentScreen.SetActive(false);
        mainMenu.SetActive(true);
        currentScreen = mainMenu;
    }

    public void ExitGame()
    {
        Debug.Log("Saindo do jogo..."); // Apenas para testes no Editor
        Application.Quit();
    }

}
