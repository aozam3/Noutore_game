using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhand_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 3.8f)
        {
            transform.Translate(0, -0.9f, 0);
        }
    }
}
