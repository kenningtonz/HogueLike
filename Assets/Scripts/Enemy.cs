using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Rigidbody2D rigid;
    public float hp;
    public float maxHP = 5;
    GameObject target;
    public GameObject glitchChild;
    public LevelGen lvlGen;

    public float speed = 1;
    public float currSpeed;
    public Vector3 targetPos;
    public Vector3 shootDir;
    public bool ranged;
    public float bulletSpeed = 6;
    public float shotDelay = 0.75f;
    float SD;
    public List<Sprite> glitches;
    float glitchTime;
    float glitching = 0;
    int glitchframe;
    float animPrevSpeed;
    Animator animator;
    public float stun;

    public AudioClip AudioClip;

    Vector2 motion;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        target = GameObject.FindGameObjectWithTag("Player");
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        currSpeed = speed;
        glitchTime = Random.Range(5, 20);
        glitching = Random.Range(1, 2);

        glitchframe = Random.Range(0, 3);
        if (glitches.Count > 0)
        {
            animator = GetComponent<Animator>();
            animPrevSpeed = animator.speed;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(beardOil == true || stun >0 || lvlGen.loadPause >  0)
        {
            stun -= Time.deltaTime;
            return;
        }
        targetPos = target.transform.position;
        shootDir = targetPos - this.transform.position;
        shootDir = shootDir / Mathf.Sqrt(shootDir.x * shootDir.x + shootDir.y * shootDir.y);
        shootDir.z = 1;
        SD -= Time.deltaTime;

        if (hp <= 0)
        {
            lvlGen.enemyList.Remove(this.gameObject);
            target.GetComponent<Hogue>().data.enemiesKilled++;
            target.GetComponent<Hogue>().AS.clip = AudioClip;
            target.GetComponent<Hogue>().AS.Play();


            Destroy(this.gameObject);
        }

        if (SD <= 0 && ranged == true)
        {
            bulletList.Add(Instantiate(Resources.Load("RogueCode", typeof(GameObject)), this.transform.position + (shootDir * 0.55f), Quaternion.identity) as GameObject);
            bulletList[bulletList.Count - 1].gameObject.GetComponent<Bullet>().vel = shootDir * bulletSpeed;
            bulletList[bulletList.Count - 1].GetComponent<Bullet>().parent = this;
            bulletList[bulletList.Count - 1].GetComponent<Bullet>().dmg = 1;
            SD = shotDelay;
        }
        motion = shootDir * 2;
        rigid.velocity = motion * currSpeed;
        motion = Vector3.zero;
        if(glitches.Count >0)
        {
            if (glitchTime <= 0 )
            {
                animator.speed = 0;
                if (glitching > 0)
                {
                    glitchChild.GetComponent<SpriteRenderer>().enabled = true;
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    glitchChild.GetComponent<SpriteRenderer>().sprite = glitches[glitchframe];
                    glitching -= Time.deltaTime;
                }
                else
                {
                    glitchTime = Random.Range(0.05f, 5);
                    glitching = Random.Range(0.05f, 0.25f);
                    glitchframe = Random.Range(0, 3);
                    glitchChild.GetComponent<SpriteRenderer>().enabled = false;
                    this.GetComponent<SpriteRenderer>().enabled = true;
                    animator.speed = animPrevSpeed;
                }

            }
            else
            {
                glitchTime -= Time.deltaTime;
                animator.speed = animPrevSpeed;
            }
        }

        

    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;

    }
}
