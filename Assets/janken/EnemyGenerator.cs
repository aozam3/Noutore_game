using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject janken_guPrefab;
    public GameObject janken_chokiPrefab;
    public GameObject janken_paPrefab;
    public GameObject katouPrefab;
    public GameObject makeyouPrefab;
    public GameObject aikoPrefab;
    GameObject enemy;
    GameObject question;
    string answerlabel;
    string mondailabel;
    string state;
    int enemyhand;
    int mondai;

    // Start is called before the first frame update

    public (string Answerlabel, string Mondailabel) Generator(string str)
    {
        //state = RuleButton.getState();
        if(str == "easy")
        {
            mondai = 2;
        }
        else
        {
            mondai = Random.Range(1, 4);
        }

        enemyhand = Random.Range(1, 4);
        switch (enemyhand)
        {
            case 1: //グーを出す
                enemy = Instantiate(janken_guPrefab);
                enemy.transform.position = new Vector3(0.1f, 8.9f, 0);
                answerlabel = "gu";
                break;
            case 2: //チョキを出す
                enemy = Instantiate(janken_chokiPrefab);
                enemy.transform.position = new Vector3(0.1f, 9.0f, 0);
                answerlabel = "choki";
                break;
            case 3: //パーを出す
                enemy = Instantiate(janken_paPrefab);
                enemy.transform.position = new Vector3(0.1f, 9.0f, 0);
                answerlabel = "pa";
                break;
        }

        switch (mondai)
        {
            case 1: //勝とう
                question = Instantiate(katouPrefab);
                question.transform.position = new Vector3(0.05f, 0.6f, 0);
                mondailabel = "katou";
                break;
            case 2: //負けよう
                question = Instantiate(makeyouPrefab);
                question.transform.position = new Vector3(0.05f, 0.6f, 0);
                mondailabel = "makeyou";
                break;
            case 3: //あいこ
                question = Instantiate(aikoPrefab);
                question.transform.position = new Vector3(0.05f, 0.6f, 0);
                mondailabel = "aiko";
                break;
        }

        return (answerlabel, mondailabel);
    }
}
