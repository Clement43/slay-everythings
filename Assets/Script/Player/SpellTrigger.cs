using UnityEngine;
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
        inputSpell1.action.Enable();
        inputSpell2.action.Enable();
        inputSpell3.action.Enable();
        inputSpell4.action.Enable();
    }

    void OnDisable()
    {
        inputSpell1.action.Disable();
        inputSpell2.action.Disable();
        inputSpell3.action.Disable();
        inputSpell4.action.Disable();
    }

    void Update()
    {
        // Vérifie si la touche est maintenue
        if (inputSpell1.action.IsPressed())
            CastAttack(0);

        if (inputSpell2.action.IsPressed())
            CastAttack(1);

        if (inputSpell3.action.IsPressed())
            CastAttack(2);

        if (inputSpell4.action.IsPressed())
            CastAttack(3);
    }

    private void CastAttack(int indexSpell)
    {
        if (character.spells.Length > indexSpell)
        {
            character.spells[indexSpell].AttackWithCooldown(enemyLayer);
        }
        else
        {
            Debug.LogError("No spell for this input");
        }
    }
}