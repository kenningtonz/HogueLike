using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    Text txt;
    public Data data;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.GetComponent<Text>();
        txt.text = "Enemies Killed: " + data.enemiesKilled;
    }
}
