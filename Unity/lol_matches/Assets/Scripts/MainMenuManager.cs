using System;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Prefabs na Cena")]
    public GameObject[] prefabs;

    [Header("Menu Inicial")]
    public GameObject mainMenu;
    public GameObject currentScreen;
   
    /*private static MainMenuManager _instance;

    public static MainMenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MainMenuManager>();

                if (_instance == null)
                {
                    Debug.LogError("Não foi encontrado nenhum objeto MainMenuManager na cena!");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
           Destroy(gameObject);
        }
    } */
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
