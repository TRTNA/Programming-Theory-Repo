using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCommands : ICommands
    {
        private readonly Animal animal;

        public PlayerCommands(Animal animal)
        {
            this.animal = animal;
        }

        public void Update()
        {
            float horizInput = Input.GetAxis("Horizontal");
            animal.GetComponent<Rigidbody>().MoveRotation(animal.transform.rotation * Quaternion.AngleAxis(horizInput * 10f, Vector3.up));
            if (Input.GetKeyUp(KeyCode.Space)) animal.Jump();
            if (Input.GetKey(KeyCode.W)) animal.Walk();
            if (Input.GetKeyUp(KeyCode.T)) animal.Talk();
            if (Input.GetMouseButtonUp(0)) animal.Attack();
        }
    }
}
