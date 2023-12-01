using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int gold = 0;

    public int point = 0;

    [HideInInspector] public SlotGenerator slotGenerator;
}
