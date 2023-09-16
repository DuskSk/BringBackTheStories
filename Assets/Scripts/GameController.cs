using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int totalStoriesCollected = 0;
    [SerializeField] int storiesCollectedPerLevel = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI levelStoriesText;
    [SerializeField] TextMeshProUGUI totalStoriestext;

    int storiesLimitPerLevel = 5;

    PlayerControlller playerControlller;

    private void Awake()
    {
       playerControlller = FindObjectOfType<PlayerControlller>();
       int gameControllerAmount = FindObjectsOfType<GameController>().Length;

       if(gameControllerAmount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerControlller.PlayerLives > 1)
        {
            playerControlller.TakeLife();

        }
        else
        {
            ResetGameSession();
        }
    }
    
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void AddTotalStoriesToCanvas()
    {
        totalStoriestext.text = $"Total Stories: {totalStoriesCollected}/15";
    }

    private void AddStoriesScoreToCanvas()
    {
        levelStoriesText.text = $"Level Stories: {storiesCollectedPerLevel}/5";
    }

    public void AddLivesToCanvas()
    {
        livesText.text = $"Lives: {playerControlller.PlayerLives}";
    }

    public void AddStoriesToTotalScore()
    {
        totalStoriesCollected++;
        AddTotalStoriesToCanvas();
    }

    public void AddStoriesToLeveScore()
    {
        storiesCollectedPerLevel++;
        AddStoriesScoreToCanvas();
    }

    public void ResetLevelStoriesCount()
    {
        storiesCollectedPerLevel = 0;
        AddLivesToCanvas();
    }

}
