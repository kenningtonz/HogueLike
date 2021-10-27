using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public PickupType PT;
    public float strength = 2;
    public GameObject controller;

    public AudioClip audioClip;
    public void OnTriggerStay2D(Collider2D col)
    {
       if (col.gameObject.tag == "Player")
        {
            switch (PT)
            {
                case PickupType.Coffee:
                    col.gameObject.GetComponent<Hogue>().Coffee((int)strength);
                    col.gameObject.GetComponent<Hogue>().data.enemiesKilled++;
                    col.gameObject.GetComponent<Hogue>().AS.clip = audioClip;
                    col.gameObject.GetComponent<Hogue>().AS.Play();
                    Destroy(this.gameObject);
                    break;
                case PickupType.Vodka:
                    col.gameObject.GetComponent<Hogue>().DrunkTime = strength;
                    col.gameObject.GetComponent<Hogue>().data.enemiesKilled++;
                    col.gameObject.GetComponent<Hogue>().AS.clip = audioClip;
                    col.gameObject.GetComponent<Hogue>().AS.Play();
                    Destroy(this.gameObject);
                    break;
                case PickupType.Egg:
                    SceneManager.LoadScene("EasterEgg");
                    col.gameObject.GetComponent<Hogue>().data.enemiesKilled++;
                    col.gameObject.GetComponent<Hogue>().AS.clip = audioClip;
                    col.gameObject.GetComponent<Hogue>().AS.Play();
                    Destroy(this.gameObject);
                    break;
            }
        }
                
    }

    public enum PickupType
    {
        Coffee,
        Vodka,
        Egg

    }
}
