using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1;

    protected PlayerControlller myPlayer;

    protected Rigidbody2D myEnemyRigidbody;

    GameController gameController;
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerControlller>();
        myEnemyRigidbody = GetComponent<Rigidbody2D>();
        gameController = GetComponent<GameController>();
    }

    
    void Update()
    {
        MoveEnemy();

    }

    //Move the enemy towards the player
    protected void MoveEnemy()
    {
        if (myPlayer == null) { return; }
        Vector2 currentPlayerPosition = myPlayer.transform.position - transform.position;

        currentPlayerPosition.Normalize();

        myEnemyRigidbody.velocity = currentPlayerPosition * enemyMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {           
            myPlayer.TakeLife(); 


        }
    }

  


}
