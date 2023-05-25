using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Code.TowerDefense.PlayerUnit
{
    public class DamageZoneComponent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Enemy")
            {
                this.transform.parent.transform.parent.GetComponent<PieceAttackerComponent>().EnemyEnteredAttackZone(collision.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision works!");
        }
    }
}
