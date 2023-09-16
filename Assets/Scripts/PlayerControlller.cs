using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int playerLives = 3;

    GameController gameController;

    Rigidbody2D myRigidbody;

    Vector2 moveInputValue;
   
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        if(playerLives < 1) { Die(); }
        Run();

    }

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    void Run()
    {
        
        myRigidbody.velocity = moveInputValue * moveSpeed;
    }

    public void TakeLife()
    {
        playerLives--;
        gameController.AddLivesToCanvas();
    }

    void Die()
    {
        Destroy(gameObject);
        gameController.ProcessPlayerDeath();
        
    }

    public int PlayerLives
    {
        get { return playerLives; }
    }
}
