using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어가 사용할 속력
    public float speed = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //기본 입력 처리 진행
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print("h :" + h + "v :" + v);
        
         
        //이동처리.
        Vector3 dir = new Vector3(h, v, 0);
        // transform.Translate(dir * (speed * Time.deltaTime));
        transform.position += dir * (speed * Time.deltaTime);
    }
}
