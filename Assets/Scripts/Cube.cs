using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minNewCubes = 2;
    [SerializeField] private int _maxNewCubes = 6;
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private Cube _cubePrefab;

    private int _scalingDivisor = 2;
    private int _partitionChance = 100;

    private void OnMouseUpAsButton()
    {
        if(GetRandomBoolByChance(_partitionChance))
        {
            DivideCube();
        }

        Destroy(gameObject);
    }

    private void DivideCube()
    {
        string _materialPropertyName = "_Color";
        int randomCubesAmount = Random.Range(_minNewCubes, _maxNewCubes+1);

        for (int i = 0; i < randomCubesAmount; i++)
        {
            var cube = Instantiate(_cubePrefab, transform.position, transform.rotation);

            cube.SetPartitionChance(_partitionChance / _scalingDivisor);
            cube.transform.localScale /= _scalingDivisor;
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            cube.GetComponent<Renderer>().material.SetColor(_materialPropertyName, Random.ColorHSV());
        }
    }

    private bool GetRandomBoolByChance(int chance)
    {
        int minChance = 1;
        int maxChance = 101;
        int randomValue = Random.Range(minChance, maxChance);

        if(chance < minChance || chance >= maxChance)
        {
            Debug.LogError("ERROR: Chance value out of bounds");
            return false;
        }
        else return randomValue < chance;
    }

    public void SetPartitionChance(int partitionChance)
    {
        if(partitionChance > 0 && partitionChance <= _partitionChance)
            _partitionChance = partitionChance;
    }
}