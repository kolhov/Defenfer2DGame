using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile, gun;

    //reference
    private AttackerSpawner myLaneSpawner;
    private Animator myAnimator;

    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("isAttacking", true);
        }
        else
        {
            myAnimator.SetBool("isAttacking", false);
        }
    }

    private void Start()
    {
        SetLaneSpawner();
        myAnimator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] _spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in _spawners)
        {
            bool isCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
    
}
