using Game.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundInitializer : MonoBehaviour
{
    [SerializeField] private RoundConfigData roundConfigData;

    private int currentRound = 0;

    private RoundSettings roundSettings;

    private void Update()
    {
        currentRound = GameManager.Instance.currentRound;

        if (roundSettings == null)
            roundSettings = GetComponent<RoundSettings>();

        var data = roundConfigData.roundInfo.First(d => d.round == currentRound);

        var roundMonsterData = roundConfigData.roundInfo
            .Where(d => d.round == currentRound)
            .Select(d => d.monsterId)
            .ToArray();

        var roundSpawnNumData = roundConfigData.roundInfo
            .Where (d => d.round == currentRound)
            .Select(d => d.spawnNum)
            .ToArray();

        roundSettings.Initialize(data, roundMonsterData, roundSpawnNumData);
    }
}
