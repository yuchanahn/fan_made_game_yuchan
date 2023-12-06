using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LaneGenerator : MonoBehaviour
{
    [Tooltip("���� ĭ ��")]
    public int width = 1;
    
    [Tooltip("���� ĭ ��")]
    public int height = 10;
    
    [Tooltip("���� ���� ���� ���� ����")]
    public float laneSpacingX = 1.0f;
    
    [Tooltip("���� ���� ���� ���� ����")]
    public float laneSpacingY = 1.0f;
    
    [Tooltip("������ X�� ������")]
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
