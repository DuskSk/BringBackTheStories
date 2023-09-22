using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBigCande : EnemyController
{
    CapsuleCollider2D myCapsuleCollider;
    
    private void Awake()
    {
        myPlayer = FindObjectOfType<PlayerControlller>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Player"))) {  return; }

        StartCoroutine(FindObjectOfType<GameController>().TakeLife());


    }
}
