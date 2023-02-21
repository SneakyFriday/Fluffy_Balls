using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private Image[] heartSprites;

    private void Start()
    {
        currentHealth = heartSprites.Length;
    }

    public void TakeDamage()
    {
        currentHealth--;

        // Deactivate heart sprites to reflect current health
        for (int i = 0; i < heartSprites.Length; i++)
        {
            if (i < currentHealth)
            {
                heartSprites[i].enabled = true;
            }
            else
            {
                heartSprites[i].enabled = false;
            }
        }
    }
}
