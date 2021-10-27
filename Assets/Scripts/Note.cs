using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public TMP_Text text;
    public string display;
    public GameObject C;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        text.text = num + ": " + display;
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            C.SetActive(true);
        }

    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            C.SetActive(false);
        }

    }
}
