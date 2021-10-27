using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public AttackType AT;
    public float strength = 2;

    public void OnTriggerStay2D(Collider2D col)
    {
        switch (AT)
        {
            case AttackType.DMG:
                if (col.gameObject.tag == "Player")
                {
                    col.gameObject.GetComponent<Hogue>().TakeDamage();

                }
                break;
            case AttackType.Aura:
                if (col.gameObject.tag == "Player")
                {
                    col.gameObject.GetComponent<Hogue>().currSpeed = col.gameObject.GetComponent<Hogue>().speed / strength;

                }
                break;
            case AttackType.Buff:
                if (col.gameObject.tag == "Enemy")
                {
                    col.gameObject.GetComponent<Enemy>().currSpeed = col.gameObject.GetComponent<Enemy>().speed * strength;

                }
                break;
            case AttackType.Stun:
                if (col.gameObject.tag == "Enemy")
                {
                    col.gameObject.GetComponent<Enemy>().stun = strength;
                    Destroy(this.gameObject);

                }
                break;

        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        switch (AT)
        {
            case AttackType.DMG:
                
                break;
            case AttackType.Aura:
                if (col.gameObject.tag == "Player")
                {
                    col.gameObject.GetComponent<Hogue>().currSpeed = col.gameObject.GetComponent<Hogue>().speed;

                }
                break;
            case AttackType.Buff:
                if (col.gameObject.tag == "Enemy")
                {
                    col.gameObject.GetComponent<Enemy>().currSpeed = col.gameObject.GetComponent<Enemy>().speed;

                }
                break;

        }
    }

    public enum AttackType
    {
        DMG,
        Aura,
        Buff,
        Stun

    }
}
