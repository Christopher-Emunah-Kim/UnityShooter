using System;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    //이동속도
    public float speed = 2.0f;
    Vector3 dir;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //30%확률로 플레이어 방향으로 출발하도록 하기
        int randValue = UnityEngine.Random.Range(0, 10);
        if (randValue < 3)
        {
            //플레이어를 타겟으로 방향을 잡고 정규화
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.down;
        transform.position += dir * (speed * Time.deltaTime);
    }
    
    //충돌시작 처리함수
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject); //상대 제거
        Destroy(gameObject); //나 제거
    }
}
