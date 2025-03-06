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
        }
    }
    
    
}
