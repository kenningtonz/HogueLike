using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TMP_Text glitchesRemoved;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCounter(int c)
    {
        counter = c;
        if (counter < 10)
            glitchesRemoved.text = "0" + counter.ToString();
        else
            glitchesRemoved.text = counter.ToString();
    }

    public void DestroyCounter()
    {
        counter++;
        if (counter < 10)
            glitchesRemoved.text = "0" + counter.ToString();
        else
            glitchesRemoved.text = counter.ToString();
    }
}
