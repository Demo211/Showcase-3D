using UnityEngine;
using static Utils;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private float _chanceDecayingRatio = 0.5f;
    [SerializeField] private float _scaleRatio = 0.5f;

    [SerializeField] private Cube _cubePrefab;

    public void SpawnCube(Vector3 spawnPosition, float chanceToReplicate, Vector3 previousScale)
    {
        Cube child = Instantiate(_cubePrefab, GetRandomOffset() + spawnPosition, Quaternion.identity);
        child.SetCubeParameters(chanceToReplicate * _chanceDecayingRatio, previousScale * _scaleRatio);
        child.gameObject.SetActive(true);
    }

    private Vector3 GetRandomOffset()
    {
        float maxOffsetInAxisScale = 0.5f;

        float xOffset = transform.localScale.x * GetRandomValue();
        float yOffset = transform.localScale.y * GetRandomValue();
        float zOffset = transform.localScale.z * GetRandomValue();

        return new Vector3(xOffset, yOffset, zOffset) * maxOffsetInAxisScale;
    }
}
