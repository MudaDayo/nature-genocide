using UnityEngine;

public class SeedHoldingEnemy : Enemy
{
    [SerializeField] private GameObject _plantSeed;
    [SerializeField] private GameObject _plantSeedPreview;

    public override void TakeDamage(float damageAmount)
    {
        // To-Do:
        // Trigger Seed Taking Animation
        // Set holding seed in PlaceSeed script --> _seed
        // Set holding seed Preview in PlaceSeed script --> previewHoldedSeed

        base.TakeDamage(damageAmount);
    }
}
