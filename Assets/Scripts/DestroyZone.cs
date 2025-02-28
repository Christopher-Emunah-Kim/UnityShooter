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
        Destroy(other.gameObject);
    }
    
    
}
