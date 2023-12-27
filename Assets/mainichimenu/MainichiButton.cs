using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainichiButton : MonoBehaviour
{
    private bool MainichiAudioEnd = false;
    private bool chokoAudioEnd = false;
    private bool collectAudioEnd = false;
    
    // Start is called before the first frame update
    public void MainichiButtonDown(string menu){
        switch (menu)
        {
            case "mainichi":
                //GetComponent<AudioSource>().Play();
                //MainichiAudioEnd = true;
                
                break;
            case "choko":
                GetComponent<AudioSource>().Play();
                chokoAudioEnd = true;
                break;
            case "collect":
                //GetComponent<AudioSource>().Play();
                //collectAudioEnd = true;
                
                break;
        }

    }

    void Update(){
        if(!GetComponent<AudioSource>().isPlaying && chokoAudioEnd)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
