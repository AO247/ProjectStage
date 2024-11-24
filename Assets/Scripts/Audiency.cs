using UnityEngine;
using System.Collections.Generic;

public class Audiency : MonoBehaviour
{
    [SerializeField] private HealthPlayer player;
    private float currentHealth;
    private float previousHealth = -1;
    [SerializeField] private List<SpriteRenderer> audience = new List<SpriteRenderer>();

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned in the inspector.");
            return;
        }

        currentHealth = Mathf.Clamp(player.GetHP(), 0, audience.Count);

        if (Mathf.Approximately(currentHealth, previousHealth)) return;
        previousHealth = currentHealth;

        for (int i = 0; i < audience.Count; i++)
        {
            audience[i].enabled = i < currentHealth;
        }
    }
}
