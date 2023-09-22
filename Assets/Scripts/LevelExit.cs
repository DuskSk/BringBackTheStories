using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]int storiesLimitPerLevel = 2;
    [SerializeField] bool isFinalLevel;
    int currentSceneIndex;
    int nextSceneIndex;
    

    GameController gameController;
    ParticleSystem myParticleSystem;
    SpriteRenderer mySpriteRenderer;


    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myParticleSystem = GetComponent<ParticleSystem>();
        

        myParticleSystem.Stop();

        mySpriteRenderer.color = Color.black;

        
    }

    private void Update()
    {
        if(FindObjectOfType<GameController>().StoriesCollectedPerLevel == storiesLimitPerLevel || isFinalLevel)
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
        yield return new WaitForSecondsRealtime(1f);

        gameController = FindObjectOfType<GameController>();
        gameController.StoriesCollectedPerLevel = 0;
        gameController.AddStoriesScoreToCanvas();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

        //Check if there is another scene to load, based on the build length
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            gameController.ResetGameSession();            
        }
        else if(nextSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            gameController.LoadFinalLevel();
            SceneManager.LoadScene(nextSceneIndex);
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
