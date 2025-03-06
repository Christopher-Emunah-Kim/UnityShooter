using UnityEngine;
//유니티UI를 사용하기 위한 네임스페이스
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //싱글턴 객체
    public static ScoreManager Instance = null;

    public Text currentScoreUI;
    //public int currentScore;
    private int currentScore; //private 멤버로 전환

    public Text bestScoreUI;
    //public int bestScore;
    private int bestScore; //private 멤버로 전환
    
    //Get/Set프로퍼티 선언
    public int Score
    {
        get{ return currentScore; }
        set
        {
            //3. ScoreManger 클래스의 속성에 값을 할당
            currentScore = value;
            //4. 화면에 점수 표시
            currentScoreUI.text = "현재점수 :  " + currentScore;
        
            //현재 점수가 기존 최고점수를 초과하면
            if (currentScore > bestScore)
            {
                bestScore = currentScore; //갱신
                bestScoreUI.text = "최고 점수 :  " + bestScore;
                //최고점수 저장
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
    
    
    //싱글턴 객체가 null이면, 생성된 자기 자신을 할당
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //this는 ScoreManager 인스턴스 객체.
        }
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //최고점수를 불러와 화면에 표시
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 :  " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
