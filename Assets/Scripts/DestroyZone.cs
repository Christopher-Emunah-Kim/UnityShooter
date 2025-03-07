using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //충돌감지함수
    private void OnTriggerEnter(Collider other)
    {
        //부딪친게 Enemy나 Bullet이면
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false); //비활성화
            
            //총알일 경우엔 리스트로 돌리기
            if (other.gameObject.name.Contains("Bullet"))
            {
                //PlayerFire 클래스 얻어와서 리스트에 삽입
                PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
                playerFire.bulletObjectPool.Add(other.gameObject);
            }
            //에너미일 경우에도 리스트로 돌리기
            else if (other.gameObject.name.Contains("Enemy"))
            {
                //EnemyManager 클래스 얻어오기
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                //리스트에 삽입
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
    
    
}
