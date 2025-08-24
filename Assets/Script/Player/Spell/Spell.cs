using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using static UnityEngine.UI.Image;

public class Spell
{
    protected void LookFaceMouse(Character character)
    {
        // 1. Raycast depuis la souris
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Plan au sol (Y = 0)
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // 2. Faire tourner le perso vers la souris
            Vector3 direction = (hitPoint - character.transform.position).normalized;
            direction.y = 0; // Garder rotation uniquement sur l’axe Y
            character.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}