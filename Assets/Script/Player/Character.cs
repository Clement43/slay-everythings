using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public CharacterStats stats;
    private NavMeshAgent agent;
    public ISpell[] spells;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.vitesseDeplacement;
        spells = new ISpell[] {
        new ConeAttack(this),
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
}