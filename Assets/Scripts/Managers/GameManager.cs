using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Public Variables
    [Header("��ȭ")]
    public int gold = 0;

    public int point = 0;

    [Header("���� ���")]
    [Tooltip("���� �̵� ������ Ƚ��")]
    public int canMoveCount = 0;
    
    [Tooltip("���� �̵� ������ Ƚ���� �ø��� �� �ʿ��� ���")]
    public int addMovePrice = 10;

    [Header("���� ����")]
    public int currentRound;

    [Tooltip("���� ���� Ʈ����")]
    public bool roundStartTrigger = false;

    [HideInInspector] public bool canMove = false;

    [HideInInspector] public bool isGameStart = false;

    [HideInInspector] public SlotGenerator slotGenerator;

    [HideInInspector] public MonsterSpawner monsterSpawner;

    [HideInInspector] public List<Lane> lanes = new List<Lane>();
    #endregion

    #region Action
    public event Action OnRoundStart;
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

        if (roundStartTrigger)
        {
            OnRoundStart?.Invoke();
            roundStartTrigger = false;
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
            Debug.Log("��尡 �����մϴ�.");
            return;
        }

        gold -= addMovePrice;
        canMoveCount++;
    }
}
