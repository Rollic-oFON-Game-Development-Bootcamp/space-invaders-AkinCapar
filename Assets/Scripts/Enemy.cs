using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 1f;
    private int randomness;


    // Start is called before the first frame update
    void Start()
    {
        randomness = UnityEngine.Random.Range(0, 3);
        Debug.Log(randomness);
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
            Debug.Log("sola çarptı");
            if (randomness == 0 ||randomness == 2 )
            {
                transform.position += transform.right * 6.4f;
            }

            else { return; }
        }

        if (collision.gameObject.tag == "EnemyRelocatorRight")
        {
            Debug.Log("sağa çarptı");
            if (randomness == 1 || randomness == 3)
            {
                transform.position -= transform.right * 6.4f;
            }

            else { return; }
        }
    }

}
