using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Obstacle : MonoBehaviour
    {
        public float speed;

        private void FixedUpdate()
        {
            gameObject.transform.position += Vector3.left * (Time.deltaTime * speed);
        }
    }
}