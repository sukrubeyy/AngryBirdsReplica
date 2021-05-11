using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    const float healt = 4f;
    public GameObject deathEffect;
    public static int enemiesCount;

    private void Start()
    {
        enemiesCount++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude>healt)
        {
            Die();
        }
      
    }
    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemiesCount--;
         if(enemiesCount<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Destroy(this.gameObject);
    }
}
