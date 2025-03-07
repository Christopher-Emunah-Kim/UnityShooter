using System;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    //이동속도
    public float speed = 2.0f;
    Vector3 dir;
    
    //폭발처리
    GameObject player;
    public GameObject explosionFactory;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnEnable()
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
        //에너미가 잡힐때마다 현재 점수를 카운트하고싶다.
        ScoreManager.Instance.Score++;

        //VFX생성
        GameObject explosion = Instantiate(explosionFactory);
        
        //VFX위치 지정
        explosion.transform.position = transform.position;
        
        //(other.gameObject); //상대 제거
        //bullet은 비활성화하고 나머진 제거
        if (other.gameObject.name.Contains("Bullet"))
        //if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            //PlayerFire 클래스 얻어와서 리스트에 삽입
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
            playerFire.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        
        //Destroy(gameObject); //나 제거
        gameObject.SetActive(false); //나 비활성화
        
        //에너미 풀에 다시 돌려보내기
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);
    }
}
