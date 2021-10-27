using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public Toggle soap;
    public Toggle beardOil;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOil(bool oil)
    {
        beardOil.isOn = oil;
    }
    public void SetSoap(bool _soap)
    {
        soap.isOn = _soap;
    }
}
