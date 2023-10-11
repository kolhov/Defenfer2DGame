using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projSpeed = 2f;
    [SerializeField] private int damage = 100;
    
    //reference
    private Health objHealthRef;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Hit(col);
    }

    private void Hit(Collider2D col)
    {
        Destroy(gameObject);
        objHealthRef = col.gameObject.GetComponent<Health>();
        if (objHealthRef) objHealthRef.DealDamage(damage);
    }

    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * projSpeed) );
    }
}
