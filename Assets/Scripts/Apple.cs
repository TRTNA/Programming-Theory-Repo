using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//INHERITANCE
public class Apple : Food
{
    [SerializeField] private int _health;
    [SerializeField] private FoodData _foodData;

    void Awake()
    {
        base.FoodData = _foodData;
    }

    //POLYMORPHISM
    public override FoodEffects Eat()
    {
        Debug.Log("I'm an apple and i will restore your health");

        var fe = base.Eat();
        fe.Health = _health;
        return fe;
    }
}
