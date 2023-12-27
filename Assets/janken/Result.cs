using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    GameObject time;
    GameObject rate;
    GameObject rank_num;
    GameObject score_num;
    GameObject director;
    public GameObject canvas;
    public GameObject rankS;
    public GameObject rankA;
    public GameObject rankB;
    public GameObject rankC;
    float score = 0;
    public float highScore = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        this.time = GameObject.Find("Result");
        this.rate = GameObject.Find("Rate");
        this.score_num = GameObject.Find("Score");
        this.rank_num = GameObject.Find("Ranking");
        this.highScore = PlayerPrefs.GetInt ("SCORE", 0);

        this.director = GameObject.Find("JankenDirector");
        var result = director.GetComponent<JankenDirector>().Score();
        this.time.GetComponent<TextMeshProUGUI>().text = result.Time.ToString("F2") + "s";
        this.rate.GetComponent<TextMeshProUGUI>().text = "正答率 " + result.Rate.ToString("F1") + "%";

        score = (1 / result.Time) * result.Rate * 100;
        this.score_num.GetComponent<TextMeshProUGUI>().text = "SCORE " + score.ToString("F1");

        if (highScore < score)  //ハイスコアを超えた場合に更新
        {
            highScore = score;
            this.rank_num.GetComponent<TextMeshProUGUI>().text = "New Record!!";
        　　　//"SCORE"をキーとして、ハイスコアを保存
            PlayerPrefs.SetFloat("SCORE", highScore);
            PlayerPrefs.Save();//ディスクへの書き込み
        }

        director.GetComponent<JankenDirector>().Reset();

        if(score >= 800.0f)
        {
            GameObject go = (GameObject)Instantiate(rankS);
            go.transform.SetParent(canvas.transform, false);
        }
        else if(score >= 500.0f)
        {
            GameObject go = (GameObject)Instantiate(rankA);
            go.transform.SetParent(canvas.transform, false);
        }
        else if(score >= 300.0f)
        {
            GameObject go = (GameObject)Instantiate(rankB);
            go.transform.SetParent(canvas.transform, false);
        }
        else
        {
            GameObject go = (GameObject)Instantiate(rankC);
            go.transform.SetParent(canvas.transform, false);
        }
    }


}
