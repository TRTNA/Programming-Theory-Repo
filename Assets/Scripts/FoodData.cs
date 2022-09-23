using JetBrains.Annotations;
using UnityEngine;
using Unity;

[CreateAssetMenu(fileName = "FoodData", menuName = "ScriptableObjects/FoodDataObject", order = 1)]
public class FoodData : ScriptableObject
{
    public int Calories;
    public Color Color;

    FoodData(int calories, Color color)
    {
        this.Calories = Mathf.Max(calories, 0);
        this.Color = color;
    }
}


