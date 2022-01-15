using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private float laserLifetime;
    [SerializeField] private float firingRate;
    [SerializeField] private bool gameStarted;
    [SerializeField] private int playerHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }
    
    private IEnumerator Fire()
    {
        while (gameStarted == true)
        {
            yield return new WaitForSeconds(firingRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject instance = Instantiate(playerLaser, transform.position, Quaternion.identity);
        Destroy(instance, laserLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyLaser")
        {
            collision.gameObject.SetActive(false);

            if(playerHealth == 1)
            {
                Destroy(gameObject); //game over
            }

            else
            {
                playerHealth -= 1;
            }
        }
    }
}
