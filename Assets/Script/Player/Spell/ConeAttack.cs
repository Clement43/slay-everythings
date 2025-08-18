using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConeAttack : ISpell
{
    public float attackRange = 5f;
    public float coneAngle = 45f;
    public int damage = 10;
    
    public InputActionReference clickAction;
    public float displayTime = 1f;

    public float cooldownDuration = 1.5f; // en secondes 
    private float nextAttackTime = 0f;

    public void AttackWithCooldown(Vector3 origin, Vector3 forward, LayerMask enemyLayer)
    {
        // Vérifie si le cooldown est fini
        if (Time.time >= nextAttackTime)
        {
            UseAttack(origin, forward, enemyLayer);
            nextAttackTime = Time.time + cooldownDuration; // relance le cooldown
        }
        else
        {
            float remaining = nextAttackTime - Time.time;
            Debug.Log($"Attaque en cooldown : encore {remaining:F1} sec");
        }
    }


    public void UseAttack(Vector3 origin, Vector3 forward, LayerMask enemyLayer)
    {
        Collider[] colliders = Physics.OverlapSphere(origin, attackRange, enemyLayer);

        foreach (Collider col in colliders)
        {
            Vector3 directionToTarget = (col.transform.position - origin).normalized;
            float angleToTarget = Vector3.Angle(forward, directionToTarget);

            if (angleToTarget <= coneAngle)
            {
                Ennemi enemy = col.GetComponent<Ennemi>();
                if (enemy != null)
                {
                    enemy.stats.TakeDamage(damage);
                }
            }
        }
    }
}