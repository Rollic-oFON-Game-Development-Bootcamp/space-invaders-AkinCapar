using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 1f;
    private int randomness;
    [SerializeField] private int enemyHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        randomness = UnityEngine.Random.Range(0, 3);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoveRandomly();
    }

    private void EnemyMoveRandomly()
    {
        if (randomness == 0)
        {
            EnemyMoveLeft();
        }

        if (randomness == 1)
        {
            EnemyMoveRight();
        }

        if (randomness == 2)
        {
            EnemyMoveLeftFaster();
        }

        if (randomness == 3)
        {
            EnemyMoveRightFaster();
        }
    }

    private void EnemyMoveLeft()
    {
        transform.position -= (transform.up + transform.right) * enemySpeed * Time.deltaTime;
    }

    private void EnemyMoveRight()
    {
        transform.position -= (transform.up - transform.right) * enemySpeed * Time.deltaTime;
    }

    private void EnemyMoveLeftFaster()
    {
        transform.position -= (transform.up * 2 + transform.right) * enemySpeed * Time.deltaTime;
    }

    private void EnemyMoveRightFaster()
    {
        transform.position -= (transform.up * 2 - transform.right) * enemySpeed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyRelocatorLeft")
        {
            if (randomness == 0 ||randomness == 2 )
            {
                transform.position += transform.right * 6.4f;
            }

            else { return; }
        }

        if (collision.gameObject.tag == "EnemyRelocatorRight")
        {
            if (randomness == 1 || randomness == 3)
            {
                transform.position -= transform.right * 6.4f;
            }

            else { return; }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerLaser")
        {
            collision.gameObject.SetActive(false);
        }
    }

}
