using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ABSTRACTION
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Food : MonoBehaviour
{

    //ENCAPSULATION
    public FoodData FoodData
    {
        get;
        protected set;
    }

    //ENCAPSULATION
    public bool Eaten { get; private set; }

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = FoodData.Color;
    }

    public virtual FoodEffects Eat()
    {
        var fe = new FoodEffects();
        fe.Calories = FoodData.Calories;
        Eaten = true;
        return fe;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }

}

public struct FoodEffects
{
    public int Calories;
    public int Health;
    public int Thirst;
}
