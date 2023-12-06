using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Public Variables
    [Header("재화")]
    public int gold = 0;

    public int point = 0;

    [Header("게임 기능")]
    [Tooltip("유닛 이동 가능한 횟수")]
    public int canMoveCount = 0;
    
    [Tooltip("유닛 이동 가능한 횟수를 늘리는 데 필요한 골드")]
    public int addMovePrice = 10;

    [Tooltip("라운드 시작 트리거")]
    private bool roundStartTrigger = false;

    [Header("라운드 세팅")]
    public int currentRound;

    public bool RoundStartTrigger
    {
        get { return roundStartTrigger; }
        set
        {
            if (value == true && roundStartTrigger == false)
            {
                Debug.Log("라운드가 시작되었습니다.");
            }
            roundStartTrigger = value;
        }
    }

    [HideInInspector] public bool canMove = false;

    [HideInInspector] public bool isGameStart = false;

    [HideInInspector] public SlotGenerator slotGenerator;
    #endregion

    private void Update()
    {
        if (canMoveCount > 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void AddPoint(int amount)
    {
        point += amount;
    }

    public void AddMoveCount()
    {
        if (gold < addMovePrice)
        {
            Debug.Log("골드가 부족합니다.");
            return;
        }

        gold -= addMovePrice;
        canMoveCount++;
    }
}
