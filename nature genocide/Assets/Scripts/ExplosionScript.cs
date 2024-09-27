using UnityEngine;

public class ExplosionScript : HitboxScript
{
    private GameObject ssa;

    private void Start()
    {
        ssa = GameObject.Find("SoundSourceExplosion");
        ssa.GetComponent<AudioSource>().Play();
    }
}
