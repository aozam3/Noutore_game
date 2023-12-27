using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBGM : MonoBehaviour
{
    public static bool protect = false;
    void Start()
    {
        
        if(!protect)
        {
            DontDestroyOnLoad(this.gameObject);
            protect = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    

}
