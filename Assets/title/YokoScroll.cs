using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoScroll : MonoBehaviour
{
    private float speed = 1;
    public static int backprotect = 0;
    void Start()
    {
        
        if(backprotect <= 3)
        {
            DontDestroyOnLoad(this.gameObject);
            backprotect++;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
   
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0);
 
        if(transform.position.x <= -14.0f)
        {
            transform.position = new Vector3(14.0f, 0);
        }
    }
}
