using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.y = 0;
        _rigidbody.velocity = direction.normalized * _speed * Time.deltaTime;
    }
}
