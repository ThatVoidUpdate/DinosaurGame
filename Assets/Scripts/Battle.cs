﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DamageType {Hit, Block, Grab};
//hit < block < grab < hit
public class Battle : MonoBehaviour
{
    public GameObject enemy;

    [Space]
    public Slider PlayerHealthBar;
    public Slider EnemyHealthBar;

    [Space]
    public int PlayerHealth;
    public int MaxPlayerHealth;
    public int EnemyHealth;
    public int MaxEnemyHealth;

    [Space]
    public DamageType[] EnemyCards;

    //[Space]
    //public DamageType PlayerCard;

    void Start()
    {
        PlayerHealth = MaxPlayerHealth;
        EnemyHealth = MaxEnemyHealth;
        PlayerHealthBar.value = PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = EnemyHealth / MaxEnemyHealth;
    }

    public void Turn(DamageType PlayerCard)
    {
        //enemy chooses card
        DamageType enemyCard = EnemyCards[Random.Range(0, EnemyCards.Length)];

        switch (enemyCard)
        {
            case DamageType.Hit:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        //no winner
                        break;
                    case DamageType.Block:
                        EnemyHealth -= 5;
                        break;
                    case DamageType.Grab:
                        PlayerHealth -= 5;
                        break;
                }
                break;
            case DamageType.Block:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        PlayerHealth -= 5;
                        break;
                    case DamageType.Block:
                        //no win
                        break;
                    case DamageType.Grab:
                        EnemyHealth -= 5;
                        break;
                }
                break;
            case DamageType.Grab:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        EnemyHealth -= 5;
                        break;
                    case DamageType.Block:
                        PlayerHealth -= 5;
                        break;
                    case DamageType.Grab:
                        //no win
                        break;
                }
                break;
        }

        if (PlayerHealth <= 0)
        {
            Debug.Log("Player whited out!");
        }
        if (EnemyHealth <= 0)
        {
            Debug.Log("You won!");
        }

        PlayerHealthBar.value = (float)PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = (float)EnemyHealth / MaxEnemyHealth;

        

    }

    public void Hit()
    {
        Turn(DamageType.Hit);
    }

    public void Block()
    {
        Turn(DamageType.Block);
    }

    public void Grab()
    {
        Turn(DamageType.Grab);
    }
}