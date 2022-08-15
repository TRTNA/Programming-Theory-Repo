using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(HealthController))]
    [RequireComponent(typeof(Rigidbody))]
    //ABSTRACTION
    public abstract class Animal : MonoBehaviour
    {

        public bool ControlledByPlayer = false;

        [SerializeField] private float damage = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float maxHealth = 100f;

        protected static readonly int AnimalLayer = 1 << 6;
        protected Collider[] colliders = new Collider[50];
        protected HealthController hc;
        protected ICommands commands;

        

        public abstract void Walk();
        public abstract void Jump();
        public abstract void Attack();


        public virtual void Talk()
        {
            Debug.Log("Hi i'm " + gameObject.name);
        }

        //ENCAPSULATION
        protected float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = Mathf.Max(value, 0.0f);
        }

        //ENCAPSULATION
        protected float Damage
        {
            get => damage;
            set => damage = Mathf.Max(value, 0.0f);
        }

        //ENCAPSULATION
        protected float JumpHeight
        {
            get => jumpHeight;
            set => jumpHeight = Mathf.Max(value, 0.0f);
        }

        //ENCAPSULATION
        protected float Speed
        {
            get => speed;
            set => speed = Mathf.Max(value, 0.0f);
        }
    }
}
