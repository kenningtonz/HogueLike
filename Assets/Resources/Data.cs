using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data : ScriptableObject
{
    public float coffee;
    public float drunk;
    public bool beardCharge;
    public bool soapCharge;
    public int enemiesKilled;
    public bool contin;
    public int lvls;
}
