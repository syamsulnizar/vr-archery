using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerStats : CharacterStats
{
    [SerializeField] private int damage;

    private PlayerHUD hud;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth);
    }

    //public void KenaSerangan()
    //{
    //    TakeDamage(10);
    //}
}
