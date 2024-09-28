using UnityEngine;

public class MeteoriteHit : MonoBehaviour
{
    [SerializeField] private GameObject _seed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Explode();
            Instantiate(_seed, new Vector3(this.transform.position.x, -3.75f, this.transform.position.z), Quaternion.identity);
        }
    }

    private void Explode()
    {
        Debug.Log("boooom");
        Destroy(this.transform.parent.gameObject);
    }
}
