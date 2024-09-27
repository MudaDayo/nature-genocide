using UnityEngine;

public class SeedHoldingEnemy : Enemy
{
    [SerializeField] private GameObject _plantSeed;

    public override void TakeDamage(float damageAmount)
    {
        // To-Do:
        // Trigger Seed Taking Animation
        // Set holding seed --> _seed

        base.TakeDamage(damageAmount);
    }
}
