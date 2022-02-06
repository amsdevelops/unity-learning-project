using System.Collections.Generic;
using CubeGameScripts.models;
using UnityEngine;

namespace CubeGameScripts
{
    public class Enemy : BaseCube
    {
        public float moveSpeed = 5;
        public float accelerationTime = 2f;
        public float maxSpeed = 5f;
        private Vector2 movement;
        private float timeLeft;
        // Start is called before the first frame update
    
        public Enemy(List<GameObject> cubesList, int powerToHit) : base(cubesList, powerToHit) {}

        public override void Move()
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeLeft += accelerationTime;
                transform.position = movement;
            }
        }

    }
}
