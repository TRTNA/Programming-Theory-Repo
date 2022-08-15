using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;

//INHERITANCE
public class Cow : Animal
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
            transform.position -= transform.forward * Speed * Time.deltaTime;
        });
    }

    void FixedUpdate()
    {
        commands.Update();
    }

    public override void Walk()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        
    }

    public override void Jump()
    {
        rb.AddForce(Vector3.up * JumpHeight * 100f, ForceMode.Force);
    }

    public override void Talk()
    {
        base.Talk();
        Debug.Log("and i'm a cow");
    }

    public override void Attack()
    {
        if (Random.value >= 0.5)
        {
            Debug.Log(gameObject.name + " DO NOT inflict damage");
            return;
        }
        Debug.Log(gameObject.name + " inflict damage");
        int result = Physics.OverlapSphereNonAlloc(transform.position, 5f, colliders, AnimalLayer);
        if (result != 0)
        {
            int nearestIndex = Utils.FindNearest(transform.position, colliders, result);
            HealthController nearestHealthController;
            colliders[nearestIndex].gameObject.TryGetComponent<HealthController>(out nearestHealthController);
            if (nearestHealthController == null)
            {
                Debug.LogWarning(gameObject.name + " could not attack nearest animal because it was null.");
                return;
            }

            nearestHealthController.InflictDamage(gameObject, Damage);
        }

    }
}