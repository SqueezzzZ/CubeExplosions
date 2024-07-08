using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private float _explosionRadius = 10;

    public void MakeCubesExplosion(List<Cube> cubes)
    {
        foreach(var cube in cubes)
        {
            cube.AddExplosionForce(_explosionForce, _explosionRadius);
        }
    }
}
