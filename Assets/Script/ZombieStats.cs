using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    [SerializeField] private bool canAttack;

    private Animator anim = null;

    public UnityEvent eventAfterDie;




    private void Start()
    {
        InitVariables();
        GetReferences();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        anim.SetTrigger("die");
        StartCoroutine(DestroyAfterAnimation());
        eventAfterDie.Invoke();
    }


    private IEnumerator DestroyAfterAnimation()
    {

        
        // Wait until the "die" animation has finished playing
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        yield return new WaitForSeconds(0.5f);

        // Destroy the game object
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        maxHealth = 30;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();

    }
}
