using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Audiency : MonoBehaviour
{
    [SerializeField] HealthPlayer player;
    float currentHealth;
    [SerializeField] List<SpriteRenderer> audience = new List<SpriteRenderer>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth =  player.GetHP();
        for(int i = 0; i < currentHealth - 1; i++)
        {
            audience[i].enabled = true;
        }
        for(int i = (int)currentHealth;  i < audience.Count-1; i++)
        {
            audience[i].enabled = false;

        }


    }
}
