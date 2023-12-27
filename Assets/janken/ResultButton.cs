using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    private bool retryAudioEnd = false;
    private bool backAudioEnd = false;
    GameObject director;
    GameObject titlebgm;

    void Start()
    {
        this.titlebgm =  GameObject.Find("TitleBGM");
        this.titlebgm.GetComponent<AudioSource>().Play();
    }

    public void ResultButtonDown(int i)
    {
        if(i == 0)
        {
            this.director = GameObject.Find("JankenDirector");
            director.GetComponent<JankenDirector>().Reset();
            GetComponent<AudioSource>().Play();
            retryAudioEnd = true;
            
        }
        else if(i == 1)
        {
            this.director = GameObject.Find("JankenDirector");
            director.GetComponent<JankenDirector>().Reset();
            GetComponent<AudioSource>().Play();
            backAudioEnd = true;
        }
    }

    void Update(){
        if(!GetComponent<AudioSource>().isPlaying && retryAudioEnd)
        {
            
            SceneManager.LoadScene("JankenCountScene");
        }
        if(!GetComponent<AudioSource>().isPlaying && backAudioEnd)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
