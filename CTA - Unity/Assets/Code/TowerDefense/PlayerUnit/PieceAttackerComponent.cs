using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.TowerDefense.PlayerUnit
{
    public class PieceAttackerComponent : MonoBehaviour
    {
        private List<GameObject> enemiesInAttackZone = new List<GameObject>();



        private void Update()
        {
            
        }

        public void EnemyEnteredAttackZone(GameObject enemy)
        {
            if (!enemiesInAttackZone.Contains(enemy))
            {
                enemiesInAttackZone.Add(enemy);
            }
        }

        public void EnemyLeftAttackZone(GameObject enemy)
        {
            enemiesInAttackZone.Remove(enemy);
        }
    }
}