using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    [Header("Rank")]
    [SerializeField] private Sprite[] rankIcons;

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
    public string GetChampName(int champId)
    {
        Champions champ = (Champions)champId;
        string champName = champ.ToString();

        return champName;
    }
    public string GetItemName(int itemId)
    {
        Items item = (Items)itemId;
        string itemName = item.ToString();

        return itemName;
    }

    public Sprite GetChampIcon(string champNome)
    {
        Champions champ;

        if (Enum.TryParse(champNome, true, out champ))
        { 
            string champName = champ.ToString();

            Sprite champSprite = champIcons.First(s => s.name == champName);

        return champSprite;
        }
        else
        {
            Debug.LogError("MatchObjects.cs - não retorna sprite");
            return null;
        }
    }

    public Sprite GetItemIcon(int itemId)
    {
        Items item = (Items)itemId;
        string itemName = item.ToString();

        Sprite itemSprite = itemIcons.First(s => s.name == itemName);

        return itemSprite; 
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

    public Sprite GetRankIcon(string rank)
    {
        switch(rank)
        {
            case "Bronze":
                return rankIcons[0];
            case "Prata":
                return rankIcons[1];
            case "Ouro":
                return rankIcons[2];
            case "Platina":
                return rankIcons[3];
            case "Esmeralda":
                return rankIcons[4];
            case "Diamante":
                return rankIcons[5];
            case "Mestre":
                return rankIcons[6];
            case "GrandMaster":
                return rankIcons[7];
            case "Challenger":
                return rankIcons[8];
            default:
                return null;
        }
    }

    #region enums
    public enum Champions
    {
        Azir = 101,
        Vayne = 67,
        Aatrox = 266,
        Thresh = 412,
        Nidalee = 76,
        Irelia = 39,
        Tristana = 18,
        Yasuo = 157,
        Yuumi = 350,
        Gragas = 64,
        Kassadin = 55,
        Aphelios = 523,
        Hecarim = 120,
        Kayle = 10,
        Yone = 777,
        Pantheon = 80,
        Amumu = 432,
        Ryze = 30,
        Camille = 164,
        Kindred = 203,
        Corki = 105,
        Nautilus = 111,
        KaiSa = 145,
        Jax = 24,
        Kayn = 141,
        Orianna = 134,
        Rakan = 497,
        Draven = 119,
        Garen = 86,
        Nocturne = 56,
        Veigar = 45,
        Alistar = 32,
        Ezreal = 81,
        Renekton = 75,
        Shyvana = 28,
        Janna = 117,
        Jinx = 222,
        Zed = 238,
        Nami = 267,
        Annie = 84,
        Sejuani = 35,
        Soraka = 40,
        Zoe = 121
    }
        public enum Items
    {
        InfinityEdge = 1,
        ImmortalShieldbow = 2,
        Galeforce = 3,
        KrakenSlayer = 4,
        ProwlersClaw = 5,
        Eclipse = 6,
        AxiomArc = 7,
        DuskbladeOfDraktharr = 8,
        BlackCleaver = 9,
        DeathsDance = 10,
        Bloodthirster = 11,
        BladeOfTheRuinedKing = 12,
        RavenousHydra = 13,
        TitanicHydra = 14,
        GuinsoosRageblade = 15,
        MortalReminder = 16,
        WitsEnd = 17,
        Stormrazor = 18,
        RapidFirecannon = 19,
        PhantomDancer = 20,
        LudensTempest = 21,
        LiandrysAnguish = 22,
        RabadonsDeathcap = 23,
        ZhonyasHourglass = 24
    }

    #endregion
}
