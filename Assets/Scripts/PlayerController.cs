using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;

    [SerializeField] private int _health = 100;
    [SerializeField] private int _calories = 1000;
    [SerializeField] private int _thirst = 100;

    private Vector3 dir;

    private float horizInput;
    private float vertInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
        if (horizInput.CompareTo(0.0f) != 0 || vertInput.CompareTo(0.0f) != 0)
        {
            dir = (horizInput * Vector3.right + vertInput * Vector3.up).normalized;
            transform.Translate(speed * Time.deltaTime * dir);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Food"))
        {
            Debug.Log("Eaten some food");
            FoodEffects fe = collider.gameObject.GetComponent<Food>().Eat();
            _thirst += fe.Thirst;
            _health += fe.Health;
            _calories += fe.Calories;
        }
    }
}
