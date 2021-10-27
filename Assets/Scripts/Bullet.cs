using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 vel;
    public Character parent;
    public float dmg;
    public float life = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += vel * Time.deltaTime;
        life -= Time.deltaTime;
        if(life <=0)
        {
            parent.bulletList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Blocker")
        {
            parent.bulletList.Remove(this.gameObject);
            Destroy(this.gameObject);
            return;
        }
        if (collision.gameObject.tag != "Player" && parent.player == true)
        {
            if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().lvlGen.loadPause <0)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
            }
            parent.bulletList.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag != "Enemy" && parent.player == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Hogue>().TakeDamage();
            }
            parent.bulletList.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
    }
}
