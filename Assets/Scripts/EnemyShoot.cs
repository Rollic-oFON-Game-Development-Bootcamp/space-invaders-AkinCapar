using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float laserLifetime;
    [SerializeField] private float firingRate;
    [SerializeField] private bool gameStarted;

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
        GameObject instance = Instantiate(enemyLaser, transform.position, Quaternion.identity);
        Destroy(instance, laserLifetime);
    }
}
