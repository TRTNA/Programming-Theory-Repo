using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(HealthController))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Animal : MonoBehaviour
    {
        protected static readonly int AnimalLayer = 1 << 6;


        protected readonly string AnimalName;


        protected Animal(string name)
        {
            this.AnimalName = name;
        }

        public abstract void Walk();
        public abstract void Jump();

        public virtual void Talk()
        {
            Debug.Log("Hi i'm " + AnimalName);
        }
        public abstract void Attack();
    }
}
