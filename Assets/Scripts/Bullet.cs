using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알이동속도
    public float speed = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //총알 이동 처리
        Vector3 dir = Vector3.up;
        transform.position += dir * (speed * Time.deltaTime);
    }
}
