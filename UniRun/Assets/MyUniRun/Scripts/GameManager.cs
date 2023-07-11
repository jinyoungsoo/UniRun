using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;                 //gfun해놔서 필요 없음 업데이트에

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;       

    public bool isGaneOver = false;
    public TMP_Text scoreText;            //text mesh pro 컴포넌트 쓴 경우
    //public Text scoreText_;             //legacy text 컴포넌트 쓴 경우
    public GameObject gameoverUi;

    private int score = 0;


    private void Awake()
    {
        if (Instance.IsValid() == false)
        {
            Instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다");
            Destroy(gameObject);
        }
        List<int> intList = new List<int>();
        intList.Add(0);

        Debug.LogFormat("inList가 유효한지? (존재하는지?) : {0}", intList.IsValid());   //log는 {0}를 넣을 수 없어서 
        //Debug.Log("inList가 유효한지? (존재하는지?) : {0}, { intList.IsValid()}");     //이렇게 하면 가능함
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGaneOver == true && Input.GetMouseButtonDown(0))
        {
            //GFunc.LoadScene("PlayScene");
            GFunc.LoadScene(GFunc.GetAcriveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if(isGaneOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    public void OnPlayerDead()
    {
        isGaneOver = true;
        gameoverUi.SetActive(true);
    }
}
