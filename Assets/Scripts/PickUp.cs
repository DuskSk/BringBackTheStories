using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController = FindObjectOfType<GameController>();
            gameController.AddStoriesToLeveScore();
            gameController.AddStoriesToTotalScore();
            Destroy(gameObject);
        }
    }
}
