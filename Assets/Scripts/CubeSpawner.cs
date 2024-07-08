using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minNewCubes = 2;
    [SerializeField] private int _maxNewCubes = 6;
    [SerializeField] private Cube _cubePrefab;

    private Cube CreateCube(Cube cubePrafab, Vector3 position, Vector3 size, Color color, int partitionChance)
    {
        var cube = Instantiate(cubePrafab, position, Quaternion.identity);

        cube.SetColor(color);
        cube.SetSize(size);
        cube.SetPartitionChance(partitionChance);

        return cube;
    }

    public List<Cube> CreateRandomCubes(Vector3 position, Vector3 size, int partitionChance)
    {
        int cubesAmount = Random.Range(_minNewCubes, _maxNewCubes+1);
        List<Cube> cubes = new();

        for (int i = 0; i < cubesAmount; i++)
            cubes.Add(CreateCube(_cubePrefab, position, size, Random.ColorHSV(), partitionChance));

        return cubes;
    }
}