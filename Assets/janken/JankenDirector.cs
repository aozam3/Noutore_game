using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;

public class JankenDirector : MonoBehaviour
{
    GameObject countobj;
    GameObject time;
    GameObject director;
    static GameObject bgm;
    GameObject obj;
    
    public GameObject maru;
    public GameObject batsu;
    public GameObject canvas;
    public GameObject[] myArray = new GameObject[3];
    List<GameObject>myList = new List<GameObject>();
    int[] locateX = {-220, 220, 0};
    int[] locateY = {730, 730, 300};
    int Pos = 0;
    
    public static int count = 0;
    public static float delta = 0.0f;
    public static string answerlabel;
    public static string mondailabel;
    public static string state;
    bool flag = false;
    public static float correct = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.countobj = GameObject.Find("Count");
        this.time = GameObject.Find("Time");
        this.director = GameObject.Find("EnemyGenerator");
        bgm = GameObject.Find("BGM");

        foreach(GameObject item in myArray)
        {
            myList.Add(item);
        }

        if(Application.loadedLevelName == "JankenScene")
        {       
            if(count == 0)
            {
                bgm.GetComponent<AudioSource>().Play();
                state = RuleButton.getState();                                   
            }
            Debug.Log(state);
            ButtonGenerator(state);
            GameStart(); 
        }
          
    }
    
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(Application.loadedLevelName == "JankenScene")
        {
            this.countobj.GetComponent<TextMeshProUGUI>().text = count + " / 10";
            this.time.GetComponent<TextMeshProUGUI>().text = delta.ToString("F2") + "s";
        }            
    }

    void GameStart()
    {
        if(Application.loadedLevelName == "JankenScene")
        {
            if(count == 0)
            {
                this.GetComponent<AudioSource>().Play();
            }
            var label = director.GetComponent<EnemyGenerator>().Generator(state);
            answerlabel = label.Answerlabel;
            mondailabel = label.Mondailabel;
            Debug.Log(answerlabel);
            Debug.Log(mondailabel);
        }  
    }

    void ButtonGenerator(string str)
    {
        if(str == "easy" || str == "normal")
        {
            for(int i  = 0; i < 3; i++)
            {
                GameObject janken = Instantiate(myList[i]);
                janken.transform.SetParent(canvas.transform, false);
            }
        }
        else if(str == "diff")
        {
            while (myList.Count > 0) 
            {
                int count = Random.Range(0, myList.Count);
                GameObject janken = Instantiate(myList[count]);
                janken.transform.position = new Vector3(locateX[Pos], locateY[Pos], 0);
                janken.transform.SetParent(canvas.transform, false);
                myList.RemoveAt(count);
                Pos++;
            }
        }
        
    }

    public void ButtonDown(string answer)
    {
        Debug.Log(count);
        if (mondailabel == "katou")
        {
            switch (answerlabel)
            {
                case "gu": //グーを出す
                    if (answer == "pa")　
                    {
                        Instantiate(maru); 
                        correct += 1.0f; 
                    }                                  
                    else
                    {
                        Instantiate(batsu); 
                    } 
                    break;
                case "choki": //チョキを出す
                    if (answer == "gu"){
                        Instantiate(maru); 
                        correct += 1.0f; 
                    }                        
                    else
                    {
                        Instantiate(batsu);
                    }  
                    break;
                case "pa": //パーを出す
                    if (answer == "choki")
                    {
                        Instantiate(maru); 
                        correct += 1.0f;
                    } 
                    else 
                    {
                        Instantiate(batsu); 
                    }
                    break;
            }
        }
        else if (mondailabel == "makeyou")
        {
            switch (answerlabel)
            {
                case "gu": //グーを出す
                    if (answer == "choki") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f; 
                    }
                    else {
                        Instantiate(batsu);
                    }
                    break;
                case "choki": //チョキを出す
                    if (answer == "pa") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f;
                    } 
                    else 
                    {
                        Instantiate(batsu);
                    }
                    break;
                case "pa": //パーを出す
                    if (answer == "gu") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f;
                    }
                    else 
                    {
                        Instantiate(batsu);
                    }
                    break;
            }
            
        }

        else if (mondailabel == "aiko")
        {
            switch (answerlabel)
            {
                case "gu": //グーを出す
                    if (answer == "gu") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f; 
                    }
                    else {
                        Instantiate(batsu);
                    }
                    break;
                case "choki": //チョキを出す
                    if (answer == "choki") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f;
                    } 
                    else 
                    {
                        Instantiate(batsu);
                    }
                    break;
                case "pa": //パーを出す
                    if (answer == "pa") 
                    {
                        Instantiate(maru); 
                        correct += 1.0f;
                    }
                    else 
                    {
                        Instantiate(batsu);
                    }
                    break;
            }
        }

        count++;
        flag = true;
        Scene();
    }

    public async Task Scene()
    {
        if (flag)
        {
            Debug.Log("flag");
            flag = false;
            await Task.Delay(500);
            if (count == 10) 
            {
                Debug.Log("result");
                bgm.GetComponent<AudioSource>().Stop();
                //SceneManager.MoveGameObjectToScene(bgm, SceneManager.GetActiveScene());
                SceneManager.LoadScene("ResultScene");
            }
            else 
            {
                //protect = true;
                SceneManager.LoadScene("JankenScene");
            }
        }
    }

    public (float Time, float Rate) Score()
    {
        float FinalTime = delta;
        float FinalRate = correct * 10;
        return (FinalTime, FinalRate);
    }

    public void Reset(){
        count = 0;
        correct = 0;
        delta = 0;
    }

}
