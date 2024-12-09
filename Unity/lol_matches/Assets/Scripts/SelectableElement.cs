using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableElement : MonoBehaviour
{
    [Header("Infos")]
    [SerializeField] private string elementName;
    [SerializeField] private Sprite elementIcon;
    
    public void Start()
    {
        GetComponent<Image>().sprite = elementIcon;
    }

    public string GetElementName()
    {
        return elementName;
    }

    public Sprite GetElementIcon()
    {
        return elementIcon;
    }
}
