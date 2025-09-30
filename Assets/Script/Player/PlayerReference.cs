using UnityEngine;

[CreateAssetMenu(menuName = "References/PlayerReference")]
public class PlayerReference : ScriptableObject
{
    [System.NonSerialized] public Character player;
}