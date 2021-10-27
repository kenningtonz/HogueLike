using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeMeter : MonoBehaviour
{
    public float MAX_COFFEE = 100.0f;
    public float current_coffee;
    public Slider coffeeMeter;
    public bool canDrain;
    public float coffeeRegenSpeed;
    float coffeeDelay;
    public float MAX_COFFEE_DELAY = 2.0f;

    float shoot;

    // Start is called before the first frame update
    void Start()
    {
        coffeeRegenSpeed = 10.0f;
        coffeeDelay = 0.0f;
        current_coffee = MAX_COFFEE;
        coffeeMeter.value = current_coffee;
    }

    // Update is called once per frame
    void Update()
    {
        coffeeDelay -= Time.deltaTime;
        if (coffeeDelay <= 0.0f)
        {
            addCoffee(coffeeRegenSpeed * Time.deltaTime);
            if (current_coffee > MAX_COFFEE)
                current_coffee = MAX_COFFEE;
        }

        //if (current_coffee < MAX_COFFEE)
        //{
        //    current_coffee += coffeeRegenSpeed * Time.deltaTime;
        //    if (current_coffee > MAX_COFFEE)
        //        current_coffee = MAX_COFFEE;
        //}

    }

    public void setCoffee(float coffee)
    {
        current_coffee = coffee;
    }

    public void addCoffee(float coffee)
    {
        current_coffee += coffee;
        if (current_coffee >= MAX_COFFEE)
            current_coffee = MAX_COFFEE;

        coffeeMeter.value = (current_coffee/ MAX_COFFEE);
    }

    public void lossCoffee(float coffee)
    {
        current_coffee -= coffee;
        if (current_coffee <= 0)
            current_coffee = 0;

        coffeeMeter.value = (current_coffee/MAX_COFFEE);
        coffeeDelay = MAX_COFFEE_DELAY;
    }
}
