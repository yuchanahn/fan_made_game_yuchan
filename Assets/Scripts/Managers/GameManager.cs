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

    [Tooltip("���� ���� Ʈ����")]
    private bool roundStartTrigger = false;

    [Header("���� ����")]
    public int currentRound;

    public bool RoundStartTrigger
    {
        get { return roundStartTrigger; }
        set
        {
            if (value == true && roundStartTrigger == false)
            {
                Debug.Log("���尡 ���۵Ǿ����ϴ�.");
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
            Debug.Log("��尡 �����մϴ�.");
            return;
        }

        gold -= addMovePrice;
        canMoveCount++;
    }
}
