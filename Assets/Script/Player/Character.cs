using System;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterStats stats;
    private NavMeshAgent agent;
    public PlayerReference playerRef;
    public Animator animator;
    public ISpell[] spells;

    void Awake()
    {
        playerRef.player = this;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.vitesseDeplacement;
        animator = GetComponent<Animator>();
        spells = new ISpell[] {
        new ConeAttack(this),
        new FireBallAttack(this),
        };
    }

    private void Update()
    {
        stats.RegenererVie();
        agent.speed = stats.vitesseDeplacement;
    }

    public void Attaquer(Ennemi cible, float degats)
    {
        degats += stats.degatsPhysiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique !");
        }

        cible.stats.TakeDamage(degats, false);
    }

    public void LancerSort(Character cible)
    {
        float degats = stats.degatsMagiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique magique !");
        }

        cible.stats.TakeDamage(degats, true);
    }


    public void StopMoovement() {
        agent.ResetPath();
    }

    public void Death()
    {
        throw new NotImplementedException();
    }
}