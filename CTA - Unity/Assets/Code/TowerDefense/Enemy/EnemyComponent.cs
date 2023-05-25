using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.TowerDefense.Enemy
{
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField]
        public int Health;

        private void Awake()
        {
            Debug.Log("Enemy loaded");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Trigger from enemy");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision from enemy");
        }
    }
}