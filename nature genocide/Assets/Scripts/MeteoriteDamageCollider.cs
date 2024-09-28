using UnityEngine;

public class MeteoriteDamageCollider : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private float _timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
