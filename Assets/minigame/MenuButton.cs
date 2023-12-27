using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private bool backAudioEnd = false;
    private bool jankenAudioEnd = false;
    private bool sansuuAudioEnd = false;
    private bool eawaseAudioEnd = false;
    private bool maxminAudioEnd = false;

    public void MenuButtonDown(string menu){
        switch (menu)
        {
            case "back":
                GetComponent<AudioSource>().Play();
                backAudioEnd = true;
                break;
            case "janken":
                GetComponent<AudioSource>().Play();
                jankenAudioEnd = true;
                break;
            case "sansuu":
                GetComponent<AudioSource>().Play();
                sansuuAudioEnd = true;
                //SceneManager.LoadScene("JankenRuleScene");
                break;
            case "eawase":
                //SceneManager.LoadScene("JankenRuleScene");
                break;
            case "maxmin":
                //SceneManager.LoadScene("JankenRuleScene");
                break;
        }

    }
    void Update(){
        if(!GetComponent<AudioSource>().isPlaying && backAudioEnd)
        {
            SceneManager.LoadScene("MainichiMenuScene");
        }
        if(!GetComponent<AudioSource>().isPlaying && jankenAudioEnd)
        {
            SceneManager.LoadScene("JankenRuleScene");
        }
        if(!GetComponent<AudioSource>().isPlaying && sansuuAudioEnd)
        {
            SceneManager.LoadScene("SansuuScene");
        }
    }
}
