using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDirector : MonoBehaviour
{
    GameObject titlebgm;
    public static bool bgmflag = false;
    // Start is called before the first frame update
    void Start()
    {
        this.titlebgm =  GameObject.Find("TitleBGM");

        if(bgmflag)
        {
            //this.titlebgm.GetComponent<AudioSource>().Play();
            bgmflag = false;
        }
    }

    public void bgmFlag()
    {
        bgmflag = true;
    }


}
