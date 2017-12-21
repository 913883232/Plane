using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDirector : MonoBehaviour {
    private int playerLifeCount = 3;
    public Action GameStartAction;
    public Action GameOverAction;
    private static LevelDirector instance;
    public static LevelDirector Instance
    {
        get
        {if (instance == null)
            {
                throw new NullReferenceException("There is no LevelDirector");
            }
            return instance;
        }
    }
    [SerializeField]private MainPlane mainPlane;
    [SerializeField]private GameObject bossPlane;
    [SerializeField]private PlayerData date;
    private int score;
    private int maxScore;
    
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (maxScore < score)
            {
                date.maxScore = value;
                maxScore = value;
            }
        }
    }
    public int MaxScore { get { return maxScore; } }
    public int PlayerLifeCount { get { return playerLifeCount; } }
    private MainPlane currentPlane;
    void Awake()
    {
        instance = this;
        Init();
    }
    void Start () {
        StartCoroutine(Step());
	}
	
	void Init () {
        mainPlane = Resources.Load<MainPlane>("Prefabs/MainPlane");
        bossPlane = Resources.Load<GameObject>("Prefabs/Boss");
        date = Resources.Load<PlayerData>("PlayerData");

        maxScore = date.maxScore;
    }
    private IEnumerator Step()
    {
        yield return new WaitForSeconds(2);
        currentPlane = Instantiate(mainPlane, mainPlane.transform.position, Quaternion.identity);
        currentPlane.OnDeadEvent += OnMainPlaneDead;
    } 
    private void OnMainPlaneDead()
    {
        playerLifeCount --;
        if (playerLifeCount > 0)
        {
            StartCoroutine(Step());
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        if(GameOverAction != null)
        {
            GameOverAction();
        }
    }
}
