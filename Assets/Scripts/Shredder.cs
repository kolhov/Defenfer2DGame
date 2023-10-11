using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var gameObj = col.gameObject;
        if (gameObj.GetComponent<Attacker>())
        {
            _playerHealth.LoseHealth(gameObj.GetComponent<Attacker>().GetDamage());
        }
        Destroy(gameObj, 1f);
    }
    
}
