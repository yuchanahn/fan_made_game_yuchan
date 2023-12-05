using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public float movSpd;      //이동 속도
    public float maxHp;       //최대 이동 속도
    public float coolTime;    //능력 사용 쿨 타임
    public int hitBoxSize;    //피격 범위를 레인으로 표시한 것으로 해당 변수가 2인 경우 레인 2개 크기의 히트 박스를 가졌다는 뜻
    public bool laneMoveableTrigger;
    
    
    void Update()
    {
        
    }
}
