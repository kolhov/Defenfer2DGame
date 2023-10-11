using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardScript : MonoBehaviour
{
    //reference
    private Attacker myAttackerScript;
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject otherGameObject = col.gameObject;
        if (otherGameObject.GetComponent<Defender>())
        {
            myAttackerScript.Attack(otherGameObject);
        }
        
    }

    private void Start()
    {
        myAttackerScript = GetComponent<Attacker>();
    }
}
