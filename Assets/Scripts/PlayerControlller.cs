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
        mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();

        
    }


    
    void Update()
    {
        if(gameController.PlayerLives < 1) 
        {
            Debug.Log("Dead");
            Die(); 
        }
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
            StartCoroutine(new WaitForSecondsRealtime(1f));
            mySpriteRenderer.color = Color.white;
        }
        
    }
    

    void Die()
    {

        gameController.ProcessPlayerDeath();        

    }
    
}
