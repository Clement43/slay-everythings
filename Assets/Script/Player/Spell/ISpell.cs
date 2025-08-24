using UnityEngine;

public interface ISpell
{
    void AttackWithCooldown(LayerMask enemyLayer);
    Sprite getImage();
    float getCdSpell();
}