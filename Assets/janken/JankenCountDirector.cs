using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;

public class JankenCountDirector : MonoBehaviour
{
    GameObject countobj;
    GameObject time;
    GameObject titlebgm;
    public GameObject startcountdown;
    float totalTime = 3.5f;
    int seconds;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.titlebgm =  GameObject.Find("TitleBGM");
        this.startcountdown = GameObject.Find("StartCount");   
        this.titlebgm.GetComponent<AudioSource>().Stop();     
    }
    
    // Update is called once per frame
    void Update()
    {
        if(totalTime >= 3 && totalTime - Time.deltaTime < 3)
        {
            GetComponent<AudioSource>().Play();
        }
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime + 1;
        if(seconds == 4){
            this.startcountdown.GetComponent<TextMeshProUGUI>().text = "3";
        }
        else if(totalTime >= 0.2f)
        {
            this.startcountdown.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
        }  
        else
        {
            SceneManager.LoadScene("JankenScene");
            //totalTime = 3;
        }   
    }

}
