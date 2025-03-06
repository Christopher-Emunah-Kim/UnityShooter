using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알 공장
    public GameObject bulletFactory;
    //총알발사위치
    public GameObject firePosition;
    
    //탄창에 넣을 수 있는 총알 갯수
    public int poolSize = 10;
    
    //오브젝트 풀 배열
    //private GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //탄창을 원하는 크기만큼 생성
        bulletObjectPool = new List<GameObject>();
        
        //탄창에 넣을 총알 개수만큼 총알을 생성해서 담기
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false); //비활성화해두기
        }
    }

    // Update is called once per frame
    void Update()
    {
        //사용자 발사입력처리
        if (Input.GetButtonDown("Fire1"))
        {
            //탄창에 있는 비활성화 총알 을 발사
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);
                
                bullet.transform.position = transform.position;
            }
        }
    }
}
