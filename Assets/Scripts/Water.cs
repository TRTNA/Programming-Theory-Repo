using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Water : Food
{
    [SerializeField] private int _thirst;
    [SerializeField] private FoodData _foodData;

    void Awake()
    {
        base.FoodData = _foodData;
    }

    //POLYMORPHISM
    public override FoodEffects Eat()
    {
        Debug.Log("I'm water and i will quench your thirst");
        var fe = base.Eat();
        fe.Thirst = _thirst;
        return fe;
    }
}
