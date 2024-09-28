using System;
using System.Collections;
using UnityEngine;

public class MeteoriteHit : MonoBehaviour
{
    [SerializeField] private GameObject _seed;
    [SerializeField] private GameObject _damageCollision;

    private GameObject _parent;
    private Meteorite _parentScript;

    [SerializeField] private int _numberOfExplosions = 5;
    [SerializeField] private GameObject _explosion;
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
            Instantiate(_seed, new Vector3(_parentScript._target.x, -3.75f, _parentScript._target.z), Quaternion.identity);
            Instantiate(_damageCollision, new Vector3(_parentScript._target.x, -3.75f, _parentScript._target.z), Quaternion.identity);

            StartCoroutine(SpawnExplosions());
            StartCoroutine(Explode());
        }
    }

    private IEnumerator SpawnExplosions()
    {
        for (int i = 0; i < _numberOfExplosions; i++)
        {
            SpawnExplosion();
            yield return null;
        }
    }

    private void SpawnExplosion()
    {
        Debug.Log("Spawned Explosion");
        Vector3 randomSpawnPos = UnityEngine.Random.insideUnitSphere * 5;

        Instantiate(_explosion, this.transform.position + randomSpawnPos + new Vector3(0f, 10.5f, 0f), Quaternion.identity);
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.05f);

        Debug.Log("boooom");
        Destroy(this.transform.parent.gameObject);
    }
}