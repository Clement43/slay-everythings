using System;
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
    private readonly Character character;

    public ConeAttack(Character character) { 
    this.character = character;
    cooldownDuration = 1 / character.stats.vitesseAttaque;

}


public void AttackWithCooldown(LayerMask enemyLayer)
    {
        cooldownDuration = 1 / character.stats.vitesseAttaque;
        // Vérifie si le cooldown est fini
        if (Time.time >= nextAttackTime)
        {
            UseAttack(character.transform.position, character.transform.forward, enemyLayer);
            character.StopMoovement();
            nextAttackTime = Time.time + cooldownDuration; // relance le cooldown
        }
    }

    private void UseAttack(Vector3 origin, Vector3 forward, LayerMask enemyLayer)
    {
        // 1. Raycast depuis la souris
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Plan au sol (Y = 0)
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // 2. Faire tourner le perso vers la souris
            Vector3 direction = (hitPoint - origin).normalized;
            direction.y = 0; // Garder rotation uniquement sur l’axe Y
            character.transform.rotation = Quaternion.LookRotation(direction);
        }

        // 3. Attaque dans le cône devant soi
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