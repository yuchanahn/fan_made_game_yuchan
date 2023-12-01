using UnityEngine;
using System.Linq;

[System.Serializable]
public class PrefabProbability
{
    public GameObject prefab;
    [Range(0, 1)] public float probability;
}

[CreateAssetMenu(fileName = "PrefabData", menuName = "ScriptableObjects/PrefabData", order = 1)]
public class PrefabData : ScriptableObject
{
    public PrefabProbability[] prefabProbabilities;

    // ���� �������� �����ϴ� �Լ�
    public GameObject GetRandomPrefab()
    {
        if (prefabProbabilities == null || prefabProbabilities.Length == 0)
        {
            Debug.LogError("PrefabData�� �������� �������� �ʾҽ��ϴ�.");
            return null;
        }

        float totalProbability = prefabProbabilities.Sum(p => p.probability);
        float randomPoint = Random.value * totalProbability;

        foreach (var prefabProbability in prefabProbabilities)
        {
            if (randomPoint < prefabProbability.probability)
                return prefabProbability.prefab;
            randomPoint -= prefabProbability.probability;
        }

        return null;
    }

    public float[] GetProbabilityPercentages()
    {
        float totalProbability = prefabProbabilities.Sum(p => p.probability);
        return prefabProbabilities.Select(p => (p.probability / totalProbability) * 100).ToArray();
    }
}
