using System;
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

    [SerializeField]int playerLives;
    [SerializeField]bool isPlayerImmune = false;

    GameObject playerCanvas, menuCanvas, finalLevelCanvas;
    
    
    int gameControllerAmount;
    

    private void Awake()
    {
       
        gameControllerAmount = FindObjectsOfType<GameController>().Length;
        playerCanvas = GetComponentInChildren<CanvasPlayer>().gameObject;
        menuCanvas = GetComponentInChildren<CanvasMenu>().gameObject;
        finalLevelCanvas = GetComponentInChildren<FinalLevelReset>().gameObject;


       if(gameControllerAmount > 1)
       {
            Destroy(gameObject);
       }
       else
       {
            DontDestroyOnLoad(gameObject);
       }
    }
    private void Start()
    {
        
        AddLivesToCanvas();
        AddStoriesScoreToCanvas();
        AddTotalStoriesToCanvas();
        menuCanvas.SetActive(true);
        playerCanvas.SetActive(false);
        finalLevelCanvas.SetActive(false);

    }

    public void ProcessPlayerDeath()
    {
          
        ResetGameSession();
        
    }
    
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    //Method to take 1 life from player and await for 1s to take it again, so the Player cannot proc multiple times the method cuz of the collision
    public IEnumerator TakeLife()
    {
        if (!isPlayerImmune)
        {
            playerLives--;
            AddLivesToCanvas();
            isPlayerImmune = true;
            yield return new WaitForSecondsRealtime(1f);
        }
        isPlayerImmune = false;
        
        
    }

    /// 
    ///  Getter for properties
    /// 


    public int PlayerLives 
    {
        get { return playerLives; }
    }

    public int StoriesCollectedPerLevel
    {
        get { return storiesCollectedPerLevel; }
        set { storiesCollectedPerLevel = value;}
    }

    public bool IsPlayerImmune
    {
        get { return isPlayerImmune; }
    }



    /// 
    /// Canvas related methods
    /// 

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        playerCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void LoadFinalLevel()
    {
        
        playerCanvas.SetActive(false);        
        finalLevelCanvas.SetActive(true);
    }

    private void AddTotalStoriesToCanvas()
    {
        totalStoriestext.text = $"Total Stories: {totalStoriesCollected}/15";
    }

    public void AddStoriesScoreToCanvas()
    {
        levelStoriesText.text = $"Level Stories: {storiesCollectedPerLevel}/5";
    }

    private void AddLivesToCanvas()
    {
        livesText.text = "Lives: " + Convert.ToString(playerLives);
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
