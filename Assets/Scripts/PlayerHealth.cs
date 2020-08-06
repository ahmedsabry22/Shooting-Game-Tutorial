using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider health_Slider;
    public GameObject enemyDestroyedPrefab;

    private int Health;

    private const int MAX_HEALTH = 100;

    private void Start()
    {
        Health = MAX_HEALTH;
    }

    public void DecreaseHealth(int amountOfHealth)
    {
        Health -= amountOfHealth;
        health_Slider.value = Health;

        if (Health <= 0)
        {
            // Player is dead.
            Destroy(gameObject);
            Debug.Log("You are dead!");
            Instantiate(enemyDestroyedPrefab, transform.position, Quaternion.identity);
        }
    }
}