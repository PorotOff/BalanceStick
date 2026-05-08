using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Configurations/Projectiles/ProjectileConfig", order = 0)]
public class ProjectileConfig : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
}