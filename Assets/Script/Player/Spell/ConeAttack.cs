using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.InputSystem;
using UnityEngine.Internal;
using UnityEngine.TextCore.Text;
using UnityEngineInternal;


public class ConeAttack : ISpell
{
    public float attackRange = 5f;
    public float coneAngle = 45f;
    public int damage = 10;
    
    public InputActionReference clickAction;
    public float displayTime = 1f;

    public float cooldownDuration = 1.5f; // en secondes 
    private float nextAttackTime = 0f;
    private Character character;

    public ConeAttack(Character character) { 
    this.character = character;
    cooldownDuration = 1 / character.stats.vitesseAttaque;

}


public void AttackWithCooldown(Vector3 origin, Vector3 forward, LayerMask enemyLayer)
    {
        cooldownDuration = 1 / character.stats.vitesseAttaque;
        // Vérifie si le cooldown est fini
        if (Time.time >= nextAttackTime)
        {
            UseAttack(origin, forward, enemyLayer);
            nextAttackTime = Time.time + cooldownDuration; // relance le cooldown
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
                    character.Attaquer(enemy, damage);
                }
            }
        }
    }

    public Sprite getImage()
    {
        return Resources.Load<Sprite>("Image/Spell/coneAttack");
    }

    public float getCdSpell() {
        float attackTime = (float)Math.Round(nextAttackTime - Time.time, 1);
        return attackTime > 0 ? attackTime : 0;
    }
}