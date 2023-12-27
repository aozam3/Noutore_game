using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    private bool isAudioEnd;
    GameObject bgm;
    // Update is called once per frame

    void Start()
    {
        //this.bgm = GameObject.Find("BGM");
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            isAudioEnd = true;          
        }

        if(!GetComponent<AudioSource>().isPlaying && isAudioEnd)
        {
            //SceneManager.MoveGameObjectToScene(bgm, SceneManager.GetActiveScene());
            //SceneManager.LoadScene("MainichiMenuScene");
            FadeManager.Instance.LoadScene ("MainichiMenuScene", 0.1f);
        }
    }
}
