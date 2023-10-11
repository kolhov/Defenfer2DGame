using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;
    
    //reference
    private SpriteRenderer myRenderer;
    private Color originalColor;
    private DefenderButton[] buttons;
    private SpawnDefenders spawner;
    
    //Methods
    private void OnMouseDown()
    {
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = originalColor;
        }
        myRenderer.color = Color.white;
        spawner.SetCurrentDefender(defenderPrefab);
        
    }
    

    private void Start()
    {
        spawner = FindObjectOfType<SpawnDefenders>();
        buttons = FindObjectsOfType<DefenderButton>();
        myRenderer = GetComponent<SpriteRenderer>();
        originalColor = myRenderer.color;

        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning(name + " has no cost label, make one!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }
}
