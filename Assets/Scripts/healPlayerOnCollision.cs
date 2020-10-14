﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerController playerHealth;

    void heal(float health)
    {
        playerHealth.currentHealth += health;
        playerHealth.healthBar.SetHealth(playerHealth.currentHealth);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KnightCharacter")
        {
            Destroy(gameObject);
            Debug.Log("healing");
            heal(10f);
        }
    }
}
