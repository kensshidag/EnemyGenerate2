using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _checkPoints;
    [SerializeField] private Target _target;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _target = Instantiate(_target);
        _target.Init(_renderer.material, _checkPoints);
    }

    public Material GetMaterial()
    {
        return _renderer.material;
    }

    public Transform GetTarget()
    {
        return _target.transform;
    }
}
