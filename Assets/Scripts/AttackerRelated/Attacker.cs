using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Tooltip("Damage before difficulty scale")]
    [SerializeField] private float rawDamage = 50;
    
    private int difficulty => PlayerPrefsController.GetDifficulty();
    private int damage;
    
    //reference
    private Animator myAnimator;
    private GameObject currentTarget;

    private void Awake()
    {
        CalculateDamage();
        
    }

    private void CalculateDamage()
    {
        float difficultyScale = (difficulty + 1) * 0.5f;
        damage = Mathf.RoundToInt(rawDamage * difficultyScale);
    }

    private void OnDestroy()
    {
        var controller = FindObjectOfType<LevelController>();
        if (controller) controller.AttackerKilled();
    }

    public void Attack(GameObject target)
    {
        myAnimator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if(!currentTarget) { return; }

        Health enemyHealth = currentTarget.GetComponent<Health>();
        if (enemyHealth)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            myAnimator.SetBool("isAttacking", false);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
}
