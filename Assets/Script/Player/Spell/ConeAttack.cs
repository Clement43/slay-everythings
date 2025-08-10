using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConeAttack : MonoBehaviour
{
    public float attackRange = 5f;         // Distance max du cône
    public float coneAngle = 45f;          // Demi-angle du cône
    public int damage = 10;                // Dégâts infligés
    public LayerMask enemyLayer;           // Couches à détecter

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            List<Ennemi> enemiesInCone = GetEnemiesInCone();

            foreach (Ennemi enemy in enemiesInCone)
            {
                enemy.stats.TakeDamage(damage); // Appelle la méthode de ton script Ennemi
            }
        }
    }

    List<Ennemi> GetEnemiesInCone()
    {
        List<Ennemi> enemiesInCone = new List<Ennemi>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider col in colliders)
        {
            Vector3 directionToTarget = (col.transform.position - transform.position).normalized;
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget <= coneAngle)
            {
                Ennemi ennemi = col.GetComponent<Ennemi>();
                if (ennemi != null)
                {
                    enemiesInCone.Add(ennemi);
                }
            }
        }

        return enemiesInCone;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 leftLimit = Quaternion.Euler(0, -coneAngle, 0) * transform.forward;
        Vector3 rightLimit = Quaternion.Euler(0, coneAngle, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftLimit * attackRange);
        Gizmos.DrawLine(transform.position, transform.position + rightLimit * attackRange);
    }


}