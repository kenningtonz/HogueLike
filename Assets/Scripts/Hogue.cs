using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hogue : Character
{
    Rigidbody2D HogueController;
    Vector3 motion;
    public float speed = 1;
    public float currSpeed;
    public Vector3 mousePos;
    public Vector3 shootDir;
    public float bulletSpeed = 6;
    public float shotDelay = 0.75f;
    public float currDamage;
    public bool alive = true;
    public Camera cam;
    float SD;
    public bool beardCharge = true;
    bool soapCharge = true;
    public float DrunkTime;
    public CoffeeMeter CM;
    public EnemyCounter EC;

    public float coffeeCost = 10;
    public Items ItemsUI;
    public Sprite skelly;
    public Data data;
    public Data lvlData;
    public AudioSource AS;
    public AudioClip beardOilClip;
    public AudioClip soapClip;
    public AudioClip attackClip;

    // Start is called before the first frame update
    void Start()
    {
        HogueController = gameObject.GetComponent<Rigidbody2D>();
        SD = shotDelay;
        currSpeed = speed;
        currDamage = 1;
        player = true;
        AS = this.gameObject.GetComponent<AudioSource>();

        if (lvlData.contin == false)
        {
            data.enemiesKilled = lvlData.enemiesKilled;
            EC.SetCounter(data.enemiesKilled);

            data.drunk = lvlData.drunk;
            DrunkTime = data.drunk;

            data.coffee = lvlData.coffee;
            CM.setCoffee(data.coffee);

            data.beardCharge = lvlData.beardCharge;
            this.beardCharge = data.beardCharge;
            ItemsUI.SetOil(!data.beardCharge);

            data.soapCharge = lvlData.soapCharge;
            this.soapCharge = data.soapCharge;
            ItemsUI.SetSoap(data.soapCharge);
        }
        else
        {
            EC.SetCounter(data.enemiesKilled);

            DrunkTime = data.drunk;

            CM.setCoffee(data.coffee);

            this.beardCharge = data.beardCharge;
            ItemsUI.SetOil(!data.beardCharge);

            this.soapCharge = data.soapCharge;
            ItemsUI.SetSoap(data.soapCharge);
        }

        
        OT = oilTimer;
        ItemsUI = GameObject.FindGameObjectWithTag("GameController").GetComponent<Items>();
    }

    // Update is called once per frame
    void Update()
    {
        EC.SetCounter(data.enemiesKilled);
        if (alive == false)
        {
            HogueController.velocity = Vector3.zero;
            return;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDir = mousePos - this.transform.position;
        shootDir = shootDir / Mathf.Sqrt(shootDir.x * shootDir.x + shootDir.y * shootDir.y);
        shootDir.z = 1;
        SD -= Time.deltaTime;
        if(DrunkTime > 0)
        {
            currDamage = 2;
            DrunkTime -= Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
            {
                motion.y = -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                motion.y = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                motion.x = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                motion.x = -1;
            }
        }
        else
        {
            currDamage = 1;
            if (Input.GetKey(KeyCode.W))
            {
                motion.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                motion.y = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                motion.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                motion.x = 1;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currSpeed = speed * 5;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currSpeed = speed * 1.6f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currSpeed = speed;
        }
        if (Input.GetKey(KeyCode.E) && beardCharge == true)
        {
            beardCharge = false;
            ItemsUI.SetOil(true);
            beardOil = true;
            data.beardCharge = false;

        }
        if (Input.GetKey(KeyCode.Q) && soapCharge == true)
        {
            bulletList.Add(Instantiate(Resources.Load("Soap", typeof(GameObject)), this.transform.position + (-shootDir * 1.1f), Quaternion.identity) as GameObject);
            ItemsUI.SetSoap(false);
            soapCharge = false;
            data.soapCharge = false;
        }
        if (Input.GetKey(KeyCode.Space) && SD <= 0 && CM.current_coffee > 10)
        {
            bulletList.Add(Instantiate(Resources.Load("MadFowl", typeof(GameObject)), this.transform.position + (shootDir * 1.1f), Quaternion.identity) as GameObject);
            bulletList[bulletList.Count - 1].gameObject.GetComponent<Bullet>().vel = shootDir * bulletSpeed;
            bulletList[bulletList.Count - 1].GetComponent<Bullet>().parent = this;
            bulletList[bulletList.Count - 1].GetComponent<Bullet>().dmg = currDamage;

            if(Random.Range(0,11) == 10)
            {
                AS.clip = attackClip;
                AS.Play();
            }

            SD = shotDelay;
            CM.lossCoffee(coffeeCost);
        }
        HogueController.velocity = motion * currSpeed;
        motion = Vector3.zero;

        if (beardOil == true)
        {
            OT -= Time.deltaTime;
            if (OT <= 0)
            {
                beardOil = false;
                OT = oilTimer;
            }
        }
    }

    public void TakeDamage()
    {
        alive = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = skelly;
        //this.gameObject.SetActive(false);
    }

    public void Slow()
    {
        alive = false;
        this.gameObject.SetActive(false);
    }

    public void Coffee(int s)
    {
        CM.addCoffee(s);
    }
}
