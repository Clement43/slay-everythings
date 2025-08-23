using UnityEngine;

public interface ISpell
{
    void AttackWithCooldown(Vector3 origin, Vector3 forward, LayerMask enemyLayer);
    void UseAttack(Vector3 origin, Vector3 forward, LayerMask enemyLayer);
    Sprite getImage();
    float getCdSpell();
}