using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LaneGenerator : MonoBehaviour
{
    [Tooltip("가로 칸 수")]
    public int width = 1;
    
    [Tooltip("세로 칸 수")]
    public int height = 10;
    
    [Tooltip("가로 방향 라인 간의 간격")]
    public float laneSpacingX = 1.0f;
    
    [Tooltip("세로 방향 라인 간의 간격")]
    public float laneSpacingY = 1.0f;
    
    [Tooltip("라인의 X축 오프셋")]
    public float laneXOffset = 10.0f;
    
    public GameObject lanePrefab;
    
    private MonsterSpawner monsterSpawner;

    void Start()
    {
        monsterSpawner = GetComponent<MonsterSpawner>();

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var point = new Vector3(x * laneSpacingX + laneXOffset, y * laneSpacingY, 0) + transform.position;
                var obj = Instantiate(lanePrefab, point, Quaternion.identity);
                obj.transform.parent = transform;
                monsterSpawner.spawnTransform.Add(obj);
            }
        }
    }

}
