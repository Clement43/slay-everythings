using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class SpellTrigger : MonoBehaviour
{
    public LayerMask enemyLayer;
    public InputActionReference inputSpell1;
    public InputActionReference inputSpell2;
    public InputActionReference inputSpell3;
    public InputActionReference inputSpell4;
    private Character character;

    void Start()
    {
        character = GetComponent<Character>();

    }

    void OnEnable()
    {
        inputSpell1.action.performed += CastAttack;
        inputSpell2.action.performed += CastAttack;
        inputSpell1.action.Enable();
        inputSpell2.action.Enable();
    }


    void OnDisable()
    {
        inputSpell1.action.performed -= CastAttack;
        inputSpell2.action.performed -= CastAttack;
        inputSpell1.action.Disable();
        inputSpell2.action.Disable();
    }

    private void CastAttack(InputAction.CallbackContext context) {
        int indexSpell = 0;
        switch (context.action.name)
        {
            case "QSpell":
                indexSpell = 0;
                break;
            case "ZSpell":
                indexSpell = 1;
                break;
            case "ESpell":
                indexSpell = 2;
                break;
            case "RSpell":
                indexSpell = 3;
                break;
        }
        if (character.spells.Length > indexSpell)
        {
            character.spells[indexSpell].AttackWithCooldown(transform.position, transform.forward, enemyLayer);
        }
        else
        {
            Debug.LogError("No spell for this input");
        }

    }
}
