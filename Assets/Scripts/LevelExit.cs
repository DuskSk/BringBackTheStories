using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    int currentSceneIndex;
    int nextSceneIndex;

    GameController gameController;
    ParticleSystem myParticleSystem;
    SpriteRenderer mySpriteRenderer;


    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myParticleSystem = GetComponent<ParticleSystem>();
        gameController = FindObjectOfType<GameController>();

        myParticleSystem.Stop();

        mySpriteRenderer.color = Color.black;

        
    }

    private void Update()
    {
        if(gameController.StoriesCollectedPerLevel == 5)
        {
            ActivatePortalToNextLevel();
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }


    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(2f);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

        //Check if there is another scene to load, based on the build length
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
            
        }



    }

    private void ActivatePortalToNextLevel()
    {
        mySpriteRenderer.color = Color.white;
        myParticleSystem.Play();
    }
}
