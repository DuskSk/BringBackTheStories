using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    //[SerializeField] private int playerLives = 3;

    GameController gameController;
    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;

    Vector2 moveInputValue;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        
    }


    
    void Update()
    {
        if(gameController.PlayerLives < 1) { Die(); }
        Run();
        ChangeColorOnHit();

    }

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    void Run()
    {
        
        myRigidbody.velocity = moveInputValue * moveSpeed;
    }    

    void ChangeColorOnHit()
    {
        if (gameController.IsPlayerImmune)
        {
            mySpriteRenderer.color = Color.magenta;
        }
        else
        {
            mySpriteRenderer.color = Color.white;
        }
    }
    

    void Die()
    {

        FindObjectOfType<GameController>().ProcessPlayerDeath();        

    }
    
}
