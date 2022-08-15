using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class HealthController : MonoBehaviour
    {
        private static readonly OnSufferedDamage VoidCallback = (a, d) => {};

        private OnSufferedDamage _onDamageCallback = VoidCallback;
        public OnSufferedDamage OnSufferedDamageCallback
        {
            private get => _onDamageCallback;
            set => _onDamageCallback = value ?? VoidCallback;
        }

        //ENCAPSULATION
        [SerializeField]
        private float _health = 100f;
        public float Health
        {
            get => _health;
            set => _health = Math.Max(value, 0.0f);
        }

        public HealthController(float health)
        {
            Health = _health;
        }

        public void InflictDamage(GameObject attacker, float damage)
        {
            Health -= damage;
            _onDamageCallback(attacker, damage);
        }
    }

    public delegate void OnSufferedDamage(GameObject attacker, float damage);
}

