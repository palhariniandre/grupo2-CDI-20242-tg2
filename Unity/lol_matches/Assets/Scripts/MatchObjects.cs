using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObjects : MonoBehaviour
{
    private static MatchObjects _instance;

    [Header("Champions")]
    [SerializeField] private Sprite[] champIcons;

    [Header("Itens")]
    [SerializeField] private Sprite[] itemIcons;

    [Header("Lane")]
    [SerializeField] private Sprite[] laneIcons;

    public static MatchObjects Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MatchObjects>();

                if (_instance == null)
                {
                    Debug.LogError("Não foi encontrado nenhum objeto MatchObjects na cena!");
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
    }

    public Sprite GetChampIcon(int index)
    {
        return champIcons[index];
    }

    public Sprite GetItemIcon(int index)
    {
        return itemIcons[index];
    }

    public Sprite GetLaneIcon(string pos)
    {
        switch (pos)
        {
            case "Top":
                return laneIcons[0];
            case "Jungle":
                return laneIcons[1];
            case "Mid":
                return laneIcons[2];
            case "ADC":
                return laneIcons[3];
            case "Support":
                return laneIcons[4];
            default:
                return null;
        }
    }
}
