using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알 공장
    public GameObject bulletFactory;
    //총알발사위치
    public GameObject firePosition;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //사용자 발사입력처리
        if (Input.GetButtonDown("Fire1"))
        {
            //총알 공장에서 총알생성
            GameObject bullet = Instantiate(bulletFactory, firePosition.transform.position, firePosition.transform.rotation);
            
            //총알 발사
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
