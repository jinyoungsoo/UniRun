using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;                 //gfun�س��� �ʿ� ���� ������Ʈ��

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;       

    public bool isGaneOver = false;
    public TMP_Text scoreText;            //text mesh pro ������Ʈ �� ���
    //public Text scoreText_;             //legacy text ������Ʈ �� ���
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
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�");
            Destroy(gameObject);
        }
        List<int> intList = new List<int>();
        intList.Add(0);

        Debug.LogFormat("inList�� ��ȿ����? (�����ϴ���?) : {0}", intList.IsValid());   //log�� {0}�� ���� �� ��� 
        //Debug.Log("inList�� ��ȿ����? (�����ϴ���?) : {0}, { intList.IsValid()}");     //�̷��� �ϸ� ������
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
