using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private Transform _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        ResetVelocity();
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void Init(Vector3 spawnPosition, Material material, Transform target)
    {
        _target = target;
        SetPosition(spawnPosition);
        _renderer.material = material;
    }

    private void SetPosition(Vector3 position)
    {
        position.y += transform.localScale.y;
        transform.position = position;
    }

    private void ResetVelocity()
    {
        if (_rigidbody.velocity != Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target, Vector3.up);
    }
}
