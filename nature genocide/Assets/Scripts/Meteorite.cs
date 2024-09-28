using System;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private GameObject _player;
    public Vector3 _target;
    private Vector3 _direction;

    [SerializeField] private float _speed;

    [SerializeField] private GameObject _tempVisualiser;
    [SerializeField] private GameObject _damageCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("PlayerAttackThing");
        Debug.Log(_player.name);

        Physics.Raycast(_player.transform.position, Vector3.down, out RaycastHit hitInfo);
        _target = new Vector3(_player.transform.position.x, hitInfo.point.y, _player.transform.position.z);

        Debug.Log(_target);
        Instantiate(_tempVisualiser, _target, Quaternion.identity);
        

        transform.LookAt(_target);
        _direction = (_target - new Vector3(0, 10f, 0) - this.transform.position);
        _direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * _speed * Time.deltaTime;
    }    
}
