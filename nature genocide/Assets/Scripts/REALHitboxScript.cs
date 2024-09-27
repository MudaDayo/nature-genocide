using UnityEngine;

public class REALHitboxScript : HitboxScript
{
    private GameObject ssa;

    private void Start()
    {
        ssa = GameObject.Find("SoundSourceAttack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Enemy")
        {
            ssa.GetComponent<AudioSource>().Play();
        }

    }
}
