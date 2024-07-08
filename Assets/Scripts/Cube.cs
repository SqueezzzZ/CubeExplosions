using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private readonly string _materialPropertyName = "_Color";

    public int PartitionChance { get; private set; } = 100;

    public void SetPartitionChance(int partitionChance)
    {
        if (partitionChance > 0 && partitionChance <= PartitionChance)
            PartitionChance = partitionChance;
    }

    public void SetColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor(_materialPropertyName, color);
    }

    public void SetSize(Vector3 size)
    {
        transform.localScale = size;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AddExplosionForce(float explosionForce, float explosionRadius)
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
    }

    public bool CanDivide()
    {
        int minChance = 1;
        int maxChance = 101;

        return Random.Range(minChance, maxChance) < PartitionChance;
     }
}