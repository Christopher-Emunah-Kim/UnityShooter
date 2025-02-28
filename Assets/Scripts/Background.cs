using UnityEngine;

public class Background : MonoBehaviour
{
    //배경 머티리얼
    public Material bgmaterial;
    //스크롤 속도
    public float scrollspeed = 0.2f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;
        
        //아래로 스크롤
        bgmaterial.mainTextureOffset += dir * (scrollspeed * Time.deltaTime);
    }
}
