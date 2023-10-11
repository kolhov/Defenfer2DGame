using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Text healthDisplay;
    private Health _health;

    private void Start()
    {
        healthDisplay = GetComponent<Text>();
        _health = GetComponent<Health>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthDisplay.text = _health.GetHealth().ToString();
    }

    public void LoseHealth(int damage)
    {
        _health.DealDamage(damage);
        UpdateDisplay();
    }
    private void OnDisable()
    {
        FindObjectOfType<LevelController>().LevelLose();
    }
}
