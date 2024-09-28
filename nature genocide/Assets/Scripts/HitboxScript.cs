using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 0.2f;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
