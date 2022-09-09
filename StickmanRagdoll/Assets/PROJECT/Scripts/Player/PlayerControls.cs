using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StickmanRagdoll.Gameplay.Player
{
    public class PlayerControls : MonoBehaviour
    {
        [Header("Movement")]
        public float movementForce;
        public float jumpForce;

        [Space(5)]
        [Range(0f, 100f)] public float raycastDistance = 1.5f;
        public LayerMask layerMask;

        [Header("Camera Follow")]
        public Camera cam;
        [Range(0f, 1f)] public float interpolation = 0.1f;
        public Vector3 offset = new Vector3(0f, 2f, -10f);

        [Header("Animation")]
        public Animator anim;
        public Transform head;

        private Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            Movement();
            Jump();
            CameraFollow();
        }
        private void Movement()
        {
            float xDir = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);

            // animation

            if (xDir > 0)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkBack", false);
            }
            if (xDir < 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkBack", true);
            }
            if(xDir == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkBack", false);
            }


            // rotation head follow dir move
            //if (xDir != 0)
            //    head.localScale = new Vector3(xDir * 0.3f, 0.3f, 1f);
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                if (IsGrounded())
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, layerMask);
            return hit.collider != null;
        }

        private void CameraFollow()
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, interpolation);
        }

    }
}