using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StickmanRagdoll.Gameplay.Player
{
    public class Balance : MonoBehaviour
    {
        public float restingAngle = 0f;
        public float force = 750;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, restingAngle, force * Time.deltaTime));
        }
    }
}
