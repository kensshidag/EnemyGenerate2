using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    private float _speed;
    private Renderer _renderer;
    private Transform[] _checkPoints;
    private int _nextCheckpoint = 0;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Move();
    }

    public void Init(Material material, Transform[] checkPoints)
    {
        _checkPoints = checkPoints;
        float minSpeed = 1.5f;
        float maxSpeed = 4.0f;

        _renderer.material = material;
        _speed = Random.Range(minSpeed, maxSpeed);
        SetStartPosition();
    }

    private void Move()
    {
        Debug.Log(_nextCheckpoint);

        if (transform.position == _checkPoints[_nextCheckpoint].position)
        {
            _nextCheckpoint++;

            if ((_nextCheckpoint + 1) >= _checkPoints.Length)
            {
                _nextCheckpoint = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _checkPoints[_nextCheckpoint].position, _speed * Time.deltaTime);
    }

    private void SetStartPosition()
    {
        _nextCheckpoint = Random.Range(0, _checkPoints.Length);
        transform.position = _checkPoints[_nextCheckpoint].position;
    }
}
