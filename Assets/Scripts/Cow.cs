using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cow : Animal
{
    [SerializeField] private float damage = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float speed = 3f;
    public Cow(string name) : base(name)
    {
    }

    private Collider[] colliders = new Collider[50];
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HealthController hc = GetComponent<HealthController>();
        hc.OnSufferedDamageCallback = ((attacker, damage) =>
        {
            Debug.Log(gameObject.name + " has suffered " + damage);
            transform.position -= transform.forward * speed * Time.deltaTime;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float mouse = Input.GetAxis("Horizontal");
        rb.MoveRotation(transform.rotation * Quaternion.AngleAxis(mouse * 10f, Vector3.up));
        if (Input.GetKeyUp(KeyCode.Space)) Jump();
        if (Input.GetKey(KeyCode.W)) Walk();
        if (Input.GetKeyUp(KeyCode.T)) Talk();
        if (Input.GetMouseButtonUp(0)) Attack();
    }

    public override void Walk()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public override void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight * 100f, ForceMode.Force);
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
        int nearestIndex = Utils.FindNearest(transform.position, colliders, result);
        HealthController nearestHealthController;
        colliders[nearestIndex].gameObject.TryGetComponent<HealthController>(out nearestHealthController);
        if (nearestHealthController == null)
        {
            Debug.LogWarning(gameObject.name + " could not attack nearest animal because it was null.");
            return;
        }

        nearestHealthController.InflictDamage(gameObject, damage);
    }
}