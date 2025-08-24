using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBallAttack : Spell, ISpell
{
    public int damage = 10;

    public InputActionReference clickAction;

    private float cooldownDuration = 1.5f; // en secondes 
    private float nextAttackTime = 0f;
    private readonly Character character;
    private GameObject fireBallGameObject;

    public FireBallAttack(Character character)
    {
        this.character = character;
        cooldownDuration = 1 / character.stats.vitesseIncantation;
        fireBallGameObject  = Resources.Load<GameObject>("Prefab/FireBall");
    }

    public void AttackWithCooldown(LayerMask enemyLayer)
    {
        cooldownDuration = 1 / character.stats.vitesseIncantation;
        // Vérifie si le cooldown est fini
        if (Time.time >= nextAttackTime)
        {
            LaunchAttack(enemyLayer);
            character.StopMoovement();
            nextAttackTime = Time.time + cooldownDuration; // relance le cooldown
        }
    }

    private void LaunchAttack(LayerMask enemyLayer)
    {
        this.LookFaceMouse(character);
        GameObject fireBall = GameObject.Instantiate(
            fireBallGameObject,
            character.transform.position,
            character.transform.rotation
        );

        // Récupérer le script FireBall du prefab
        FireBall fireBallScript = fireBall.GetComponent<FireBall>();
        fireBallScript.Init(character, damage, enemyLayer);
    }
    public Sprite getImage()
    {
        return Resources.Load<Sprite>("Image/Spell/fireBall");
    }

    public float getCdSpell()
    {
        float attackTime = (float)Math.Round(nextAttackTime - Time.time, 1);
        return attackTime > 0 ? attackTime : 0;
    }
}