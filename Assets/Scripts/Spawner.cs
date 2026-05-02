using UnityEngine;
using static Utils;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;

    [SerializeField] private MinMaxPair _amountOfDescendants = new MinMaxPair(2, 6);
    [SerializeField] private float _chanceDecayingRate = 2f;
    [SerializeField, Range(0f, 1f)] private float _scaleOfChild = 0.5f;

    [SerializeField] private Cube _spawnedObject;

    public void Spawn(Vector3 spawnPosition, Cube progenitor)
    {
        if (IsProcessed(progenitor.ChanceToReplicate))
        {
            int descendantsNumber = GetRandomNumber(_amountOfDescendants.Min, _amountOfDescendants.Max);

            for (int i = 0; i < descendantsNumber; i++)
            {
                Cube child = Instantiate(_spawnedObject, GetRandomOffset() + spawnPosition, Quaternion.identity);
                child.SetParameters(progenitor, _chanceDecayingRate, _scaleOfChild);
                child.gameObject.SetActive(true);
            }
        }

        Destroy(progenitor.gameObject);
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
