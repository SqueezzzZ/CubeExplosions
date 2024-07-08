using UnityEngine;

public class CubeClicker : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Camera _camera;

    private int _scalingDivisor = 2;
    private int _partitionChanceDivisor = 2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.TryGetComponent(out Cube cube))
            {
                if (cube.CanDivide())
                {
                    _exploder.MakeCubesExplosion(_cubeSpawner.CreateRandomCubes(cube.transform.position, 
                        cube.transform.localScale / _scalingDivisor, 
                        cube.PartitionChance / _partitionChanceDivisor));
                }

                cube.Destroy();
            }
        }
    }
}