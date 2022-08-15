using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

//INHERITANCE
public class Wolf : Animal
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        if (ControlledByPlayer) commands = new PlayerCommands(this);
        else commands = new AICommands(this);
        hc = GetComponent<HealthController>();
        hc.Health = MaxHealth;

        rb = GetComponent<Rigidbody>();
        hc.OnSufferedDamageCallback = ((attacker, damage) =>
        {
            Debug.Log(gameObject.name + " has suffered " + damage);
            //bears attack when damaged
            Attack();
        });
    }


    public override void Walk()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    public override void Jump()
    {
        rb.AddForce(Vector3.up * JumpHeight * 100f, ForceMode.Force);
        rb.AddForce(Vector3.up * JumpHeight * 50f, ForceMode.Force);

    }


    public override void Talk()
    {
        base.Talk();
        Debug.Log("and i'm a wolf");
    }

    public override void Attack()
    {
        Debug.Log(gameObject.name + " inflict damage");
        int result = Physics.OverlapSphereNonAlloc(transform.position, 5f, colliders, AnimalLayer);
        if (result != 0)
        {
            for (int i = 0; i < 2; i++)
            {
                HealthController healthController;
                colliders[i].gameObject.TryGetComponent<HealthController>(out healthController);
                healthController?.InflictDamage(gameObject, Damage);
            }
        }

    }
}
