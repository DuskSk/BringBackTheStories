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
    CapsuleCollider2D myCapsuleCollider;

    Vector2 moveInputValue;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();        
        mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

        
    }


    
    void Update()
    {
        if(gameController.PlayerLives < 1) 
        {
            Debug.Log("Dead");
            Die(); 
        }
        Run();
        //ChangeColorOnHit();

    }

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    void Run()
    {
        
        myRigidbody.velocity = moveInputValue * moveSpeed;
    }    
    
    

    void Die()
    {
        StartCoroutine(new WaitForSecondsRealtime(2f));
        mySpriteRenderer.color = Color.red;
        gameController.ResetGameSession();        

    }
    
}
