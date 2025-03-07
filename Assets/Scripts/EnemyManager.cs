using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyManager : MonoBehaviour
{
    
    //현재 시간
    private float currentTime;
    //일정 시간
    public float createTime = 1.0f;
    //난수 최소/최대 시간
    private float minTime = 1.0f;
    private float maxTime = 5.0f;
    
    //적 공장
    public GameObject enemyFactory;
    
    //오브젝트풀 관련
    public int poolSize = 10; //크기
    public List<GameObject> enemyObjectPool; //오브젝트 풀배열
    public Transform[] spawnPoints; //SpawnPoint 배열
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //태어날때 생성시간 결정
        createTime = Random.Range(minTime, maxTime);
        
        //오브젝트 풀을 에너미 크기만큼 생성
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            
            // Rigidbody rb = enemy.GetComponent<Rigidbody>();
            // if(rb != null)
            //         rb.isKinematic = true;
            
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false); //처음엔 비활성화
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        //시간이 흐르다가 일정시간이 되면 에너미 스폰해 에너미 매니저 자리에 가져다두기
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            //오브젝트 풀에 에너미가 있다면
            if (enemyObjectPool.Count > 0)
            {
                //오브젝트 풀에서 enemy를 가져다 쓰고
                GameObject enemy = enemyObjectPool[0];
                //오브젝트 풀에서 제거
                enemyObjectPool.Remove(enemy);
                //랜덤으로 인덱스 선택해서 스폰포인트에 위치
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
                
                // Rigidbody rb = enemy.GetComponent<Rigidbody>();
                // if (rb != null)
                // {
                //     rb.isKinematic = false;
                //     rb.WakeUp();
                // }
            }
            
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
