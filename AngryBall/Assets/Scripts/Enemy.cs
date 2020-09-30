using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 4f;
    public static int enemiesAlive = 0;

    void Start()
    {
        // Entspricht der Menge an Gengnern, da jeder Gegner das Script ausführt und +1 hinzufügt
        enemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collisionforce is higher than the health of the enemy
        if(coll.relativeVelocity.magnitude > health)
        {
            Die();
        }
        // instantiate the particel Effect at the position of the Gameobject with noch Rotation (quaternion)
        // substract one enemiesAlive
        void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            enemiesAlive--;
            if (enemiesAlive <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }
}
