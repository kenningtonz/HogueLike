using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length >1)
        {
            for(int i = 1; i < objs.Length; i++)
            {
                Destroy(objs[i]);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
