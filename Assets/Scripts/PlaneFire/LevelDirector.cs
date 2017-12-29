using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDirector : Singleton<LevelDirector> {
    private int playerLifeCount = 3;
    public Action GameStartAction;
    public Action GameOverAction;
    public Action VictoryAction;
    
    [SerializeField]private MainPlane mainPlane;
    [SerializeField]private Boss bossPlane;
    [SerializeField]private PlayerData date;
    private int score;
    private int maxScore;
    //分数比较和记录
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
    public int PlayerLifeCount { get { return playerLifeCount; } }//定义生命值
    public MainPlane currentPlane { get;private set; }
    private Boss currentBoss;
    protected override void Awake()
    {
        Init();
    }
    void Start () {
        //if (GameStartAction != null)
        //    GameStartAction();
        if (UIManager.Instance != null)
            UIManager.Instance.FaderOn(false, 1f);
        StartCoroutine(Step());
        StartCoroutine(Enermy());
	}
	
	void Init () {
        mainPlane = Resources.Load<MainPlane>("Prefabs/MainPlane");
        bossPlane = Resources.Load<Boss>("Prefabs/Boss");
        date = Resources.Load<PlayerData>("PlayerData");

        maxScore = date.maxScore;
    }
    private IEnumerator Step()
    {
        yield return new WaitForSeconds(2);
        currentPlane = Instantiate(mainPlane, mainPlane.transform.position, Quaternion.identity);
        currentPlane.OnDeadEvent += OnMainPlaneDead;
    }
    private IEnumerator Enermy()
    {
        yield return new WaitForSeconds(1);
        currentBoss = Instantiate(bossPlane, bossPlane.transform.position, Quaternion.identity);
        currentBoss.OnBossDeadEvent += OnBossDead;
    }
    private void OnMainPlaneDead()
    {
        playerLifeCount --;
        print(playerLifeCount);
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
    private void OnBossDead()
    {
        //StartCoroutine(Enermy());
        Victory();
    }
    public void Victory()
    {
        if (VictoryAction != null)
        {
            VictoryAction();
        }
    }
}
