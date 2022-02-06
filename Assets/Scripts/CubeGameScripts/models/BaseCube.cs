using System.Collections.Generic;
using CubeGameScripts.contracts;
using UnityEngine;

namespace CubeGameScripts.models
{
    public abstract class BaseCube : MonoBehaviour, IMovable, IAttackable, IHittable
    {
        public int hp = 100;
        private int powerToHit;
        protected List<GameObject> cubesList;

        public BaseCube(List<GameObject> cubesList, int powerToHit)
        {
            this.cubesList = cubesList;
            this.powerToHit = powerToHit;
        }
        

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public abstract void Move();
        
        public void Attack()
        {
            foreach (var baseCube in cubesList)
            {
                var diff = baseCube.transform.position - transform.position;
                var curDist = diff.sqrMagnitude;
                Debug.Log(curDist);
            }
        }

        public void OnHit(int hitPower)
        {
            hp -= hitPower;
            if (hp <= 0)
            {
                Destroy(this);
            }
        }
    }
}