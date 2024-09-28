using UnityEngine;

public class MeteoriteHit : MonoBehaviour
{
    [SerializeField] private GameObject _seed;
    private GameObject _parent;
    private Meteorite _parentScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _parent = this.transform.parent.gameObject;
        _parentScript = _parent.GetComponent<Meteorite>();
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
            Instantiate(_seed, new Vector3(_parentScript._target.x, -3.75f, _parentScript._target.z), Quaternion.identity);
        }
    }

    private void Explode()
    {
        Debug.Log("boooom");
        Destroy(this.transform.parent.gameObject);
    }
}