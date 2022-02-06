using System.Collections.Generic;
using CubeGameScripts.models;
using UnityEngine;

namespace CubeGameScripts
{
    public class Player : BaseCube
    {
        public float moveSpeed = 5;
        // Start is called before the first frame update
    
        public Player(List<GameObject> cubesList, int powerToHit) : base(cubesList, powerToHit) {}

        public override void Move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;

            transform.position += tempVect;
        }

    }
}
