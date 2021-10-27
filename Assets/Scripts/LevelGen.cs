using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGen : MonoBehaviour
{
    public List<GameObject> levels;
    public List<Vector3> PSpawns;
    public List<GameObject> Spawns;
    public List<GameObject> enemyList;
    public List<GameObject> itemList;
    public List<GameObject> noteList;
    public Data data;
    public Data ECdata;
    Hogue player;
    int selectedLvl;
    int numEnemy;
    int numItem;
    float lvlTimer = 6;
    bool itemsSpawned = false;
    public float loadPause = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        selectedLvl = Random.Range(0, 7);
        levels[selectedLvl].SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hogue>();
        player.gameObject.transform.position = PSpawns[selectedLvl];
        numEnemy = Random.Range(1, 3 + (data.lvls /2));
        for (int i = 0; i < numEnemy; i++)
        {
            EnemyT e;
            e = (EnemyT)Random.Range(0, 5);
            Vector3 pos = new Vector3(
                Random.Range(Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.min.x, Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.max.x),
                Random.Range(Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.min.y, Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.max.y),
                0
                );
            switch (e)
            {
                case EnemyT.Melee:
                    enemyList.Add(Instantiate(Resources.Load("Enemies/Melee", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                    enemyList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                    break;
                case EnemyT.Ranged:
                    enemyList.Add(Instantiate(Resources.Load("Enemies/Ranged", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                    enemyList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                    break;
                case EnemyT.Aura:
                    enemyList.Add(Instantiate(Resources.Load("Enemies/Aura", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                    enemyList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                    break;
                case EnemyT.Buff:
                    enemyList.Add(Instantiate(Resources.Load("Enemies/Buff", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                    enemyList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                    break;
                case EnemyT.Block:
                    enemyList.Add(Instantiate(Resources.Load("Enemies/Defend", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                    enemyList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                    break;
            }
        }
    }

    public enum EnemyT
    {
        Melee,
        Aura,
        Ranged,
        Buff,
        Block
    }
    public enum ItemT
    {
        Vodka,
        Coffee,
        Egg
    }


    // Update is called once per frame
    void Update()
    {
        loadPause -= Time.deltaTime;
        if (enemyList.Count == 0 || player.alive == false)
        {
            lvlTimer -= Time.deltaTime;
            if (itemsSpawned == false)
            {
                itemsSpawned = true;

                int notenum = Random.Range(1, 20);
                switch (notenum)
                {
                    case 1:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note1", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 2:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note2", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 3:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note3", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 4:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note4", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 5:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note5", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 6:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note6", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 7:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note7", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 8:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note8", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 9:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note9", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 10:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note10", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 11:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note11", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 12:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note12", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 13:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note13", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 14:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note14", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 15:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note15", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 16:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note16", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 17:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note17", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 18:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note69", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    case 19:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note420", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                        break;
                    default:
                        noteList.Add(Instantiate(Resources.Load("Notes/Note420", typeof(GameObject)), player.transform.position, Quaternion.identity) as GameObject);
                        break;

                }

                numItem = Random.Range(0, 2);
                for (int i = 0; i < numItem; i++)
                {
                    ItemT item;
                    item = (ItemT)Random.Range(0, 3);
                    
                    Vector3 pos = new Vector3(
                        Random.Range(Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.min.x, Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.max.x),
                        Random.Range(Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.min.y, Spawns[selectedLvl].GetComponent<BoxCollider2D>().bounds.max.y),
                        0
                        );
                    switch (item)
                    {
                        case ItemT.Vodka:
                            itemList.Add(Instantiate(Resources.Load("Vodka", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                            //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                            break;
                        case ItemT.Coffee:
                            itemList.Add(Instantiate(Resources.Load("Coffee", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                            //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                            break;
                        case ItemT.Egg:
                            itemList.Add(Instantiate(Resources.Load("Easter Egg", typeof(GameObject)), pos, Quaternion.identity) as GameObject);
                            //itemList[enemyList.Count - 1].GetComponent<Enemy>().lvlGen = this;
                            break;
                    }


                }
            }
            
            if (lvlTimer <= 0)
            {
                //if(player.alive == true)
                //{
                    data.contin = true;
                //}
                if (player.alive == false)
                {
                    ECdata.enemiesKilled = data.enemiesKilled;
                    Destroy(GameObject.FindGameObjectWithTag("Music"));
                    SceneManager.LoadScene("Death");
                    return;
                }
                player.data.drunk = player.DrunkTime;
                player.data.coffee = player.CM.current_coffee;
                data.lvls++;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
