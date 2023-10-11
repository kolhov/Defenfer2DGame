using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public int GetHealth()
    {
        return health;
    }

    public void DealDamage(int damage)
    {
        health -= damage; 
        if (health <= 0)
        {
            DeathProceed();
        }
    }

    private void DeathProceed()
    {
        var vfx = GetComponent<ScriptVFX>();
        if (vfx) vfx.PlayOnDeathVFX();
        Destroy(gameObject);
    }
}
