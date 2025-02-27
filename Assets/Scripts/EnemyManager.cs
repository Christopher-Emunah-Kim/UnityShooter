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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //태어날때 생성시간 결정
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //시간이 흐르다가 일정시간이 되면 에너미 스폰해 에너미 매니저 자리에 가져다두기
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position; 
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime); //생성시간 재설정
        }
    }
}
