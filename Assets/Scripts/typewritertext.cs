using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typewritertext : MonoBehaviour
{
    public int lineindex = 0;
    public string[] textlines;
    public AudioClip[] audiolines;

    //hogue is 0, other is 1, none is 3
    public int[] whosays;

    private float speed = 0.05f;
    private string fulltext;
    private string currenttext = "";
    public GameObject textbox;

    //hogue is 0, other is 1
    public GameObject[] nametags = new GameObject[2];
    public GameObject hoguetalks;

    public GameObject othercharacter;


    void Start()
    {
       
        if (this.tag == "Death")
        {
            lineindex = Random.Range(0, 4);

        }
        fulltext = textlines[lineindex];

        this.GetComponent<AudioSource>().clip = audiolines[lineindex];
       
        StartCoroutine(ShowText());
    }
   
        IEnumerator ShowText(){
        this.GetComponent<AudioSource>().Play();
        for (int i = 0; i < fulltext.Length; i++)
            {
                currenttext = fulltext.Substring(0, i);
            textbox.GetComponent<Text>().text = currenttext;
                yield return new WaitForSeconds(speed);
            }
        }

    void Update()
    {
        switch (whosays[lineindex])
        {
            case 0:
                nametags[0].gameObject.SetActive(true);
                nametags[1].gameObject.SetActive(false);
                hoguetalks.gameObject.SetActive(true);
              

                break;
            case 1:

                nametags[0].gameObject.SetActive(false);
                nametags[1].gameObject.SetActive(true);
                hoguetalks.gameObject.SetActive(false);
                othercharacter.gameObject.SetActive(true);
                break;
            case 2:
                nametags[0].gameObject.SetActive(false);
                nametags[1].gameObject.SetActive(false);
                hoguetalks.gameObject.SetActive(false);
                break;

        }

        switch (this.tag)
        {
            case "Death":
                break;
            case "intro":

                if (lineindex == 14)
                    othercharacter.gameObject.SetActive(false);
                break;


            case "egg":
                break;
        }



        if ( currenttext.Length + 1 == fulltext.Length && Input.GetKeyDown(KeyCode.Space))
        {
            if (lineindex + 1 == textlines.Length)
            {

                SceneManager.LoadScene("SampleScene");
            }
            else if (this.tag == "Death" && lineindex >= 5)
            {
                SceneManager.LoadScene("End");
            }

            if (this.tag == "Death")
            {
                lineindex = Random.Range(5, 9);

            }
            else
            {
                lineindex++;
            }
            currenttext = "";
            fulltext = textlines[lineindex];
            textbox.GetComponent<Text>().text = "";
            speed = 0.05f;
            this.GetComponent<AudioSource>().clip = audiolines[lineindex];
            StartCoroutine(ShowText());



        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 0;
          
        }

      
    }

}
