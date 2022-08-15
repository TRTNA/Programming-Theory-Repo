using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Bear : Animal
{
    [SerializeField] private float damage = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float speed = 3f;
    private Rigidbody rb;

    private Collider[] colliders = new Collider[50];

    public Bear(string name) : base(name) { }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HealthController hc = GetComponent<HealthController>();
        hc.OnSufferedDamageCallback = ((attacker, damage) =>
        {
            Debug.Log(gameObject.name + " has suffered " + damage);
            //bears attack when damaged
            Attack();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Walk()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        //bears walk like jumping around
        Jump();
    }

    public override void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight * 100f, ForceMode.Force);
    }


    public override void Talk()
    {
        base.Talk();
        Debug.Log("and i'm a bear");
    }

    public override void Attack()
    {
        Debug.Log(gameObject.name + " inflict damage");
        int result = Physics.OverlapSphereNonAlloc(transform.position, 5f, colliders, AnimalLayer);
        for (int i = 0; i < result; i++)
        {
            HealthController healthController;
            colliders[i].gameObject.TryGetComponent<HealthController>(out healthController);
            healthController?.InflictDamage(gameObject, damage);
        }
    }
}