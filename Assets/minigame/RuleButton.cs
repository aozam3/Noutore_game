using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleButton : MonoBehaviour
{
    private bool backAudioEnd = false;
    private bool okAudioEnd = false;
    public static bool firstflag = false;
    public static string state = "normal";
    public GameObject normal;
    public GameObject easy;
    public GameObject diff;
    GameObject right_arrow;
    GameObject left_arrow;
    GameObject obj;
    //GameObject obj_easy;
    //GameObject obj_diff;

    void Start()
    {
        
        //this.obj_easy = GameObject.Find("kantan");
        //this.obj_diff = GameObject.Find("muzukashi");
        this.right_arrow = GameObject.Find("right_arrow");
        this.left_arrow = GameObject.Find("left_arrow");
    }

    // Start is called before the first frame update
    public void RuleButtonDown(string menu){
        this.obj = GameObject.Find("futsuu(Clone)");
        switch (menu)
        {
            case "back":
                GetComponent<AudioSource>().Play();
                backAudioEnd = true;
                break;
            case "ok":
                GetComponent<AudioSource>().Play();
                okAudioEnd = true; 
                break;
            case "right":
                if(state == "normal")
                {
                    this.obj = GameObject.Find("futsuu(Clone)");
                    Destroy(obj);
                    this.right_arrow.SetActive(false);
                    this.left_arrow.GetComponent<AudioSource>().Play();
                    obj = Instantiate(diff) as GameObject;
                    state = "diff";
                }
                else if(state == "easy")
                {
                    this.obj = GameObject.Find("kantan(Clone)");
                    Destroy(obj);
                    this.left_arrow.SetActive(true);
                    GetComponent<AudioSource>().Play();
                    obj = Instantiate(normal) as GameObject;
                    state = "normal";
                }
                break;
            case "left":
                if(state == "normal")
                {
                    this.obj = GameObject.Find("futsuu(Clone)");
                    if(firstflag){
                        
                    }
                    firstflag = true;
                    Destroy(obj);
                    this.left_arrow.SetActive(false);
                    this.right_arrow.GetComponent<AudioSource>().Play();
                    obj = Instantiate(easy) as GameObject;
                    state = "easy";
                }
                else if(state == "diff")
                {
                    this.obj = GameObject.Find("muzukashi(Clone)");
                    Destroy(obj);
                    this.right_arrow.SetActive(true);
                    GetComponent<AudioSource>().Play();
                    obj = Instantiate(normal) as GameObject;
                    state = "normal";
                }
                
                break;
        }

    }

    void Update(){
        if(!GetComponent<AudioSource>().isPlaying && backAudioEnd)
        {
            firstflag = false;
            state = "normal";
            SceneManager.LoadScene("MenuScene");
        }
        if(!GetComponent<AudioSource>().isPlaying && okAudioEnd)
        {
            firstflag = false;
            SceneManager.LoadScene("JankenCountScene");
        }
    }

    public static string getState(){
        string stateinfo =  state;
        state = "normal";
		return stateinfo;
	}
}
