using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class StarCounter : MonoBehaviour
{
    [SerializeField] private int stars = 100;
    private Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        string newText = stars.ToString();
        starText.text = newText;
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int amountStars)
    {
        stars += amountStars;
        UpdateDisplay();
    }

    public void SpendStars(int starsToSpend)
    {
        stars -= starsToSpend; 
        UpdateDisplay();
    }
}
