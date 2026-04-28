using UnityEngine;
using static Utils;

public class Replicator : MonoBehaviour
{
    [SerializeField] private MinMaxPair _amountOfDescendants = new MinMaxPair(2,6);
    [SerializeField, Range(0f, 1f)] private float _ratioOfReplicate = 1.0f;
    [SerializeField] private float _chanceDecayingRate = 2f;
    [SerializeField, Range(0f, 1f)] private float _scaleOfChild = 0.5f;    

    [SerializeField] private Replicant _spawnedObject;
    [SerializeField] private ExplosionZone _explosionZone;

    private void OnDestroy()
    {
        Replicate();
        
        ExplosionZone explosion = Instantiate(_explosionZone, this.transform.position, Quaternion.identity);
        explosion.SetExplosionParameters(1/this.transform.localScale.magnitude, 1/this.transform.localScale.magnitude);
    }


    private void Replicate()
    {
        if (IsProcessed(_ratioOfReplicate))
        {
            int descendantsNumber = GetRandomNumber(_amountOfDescendants.Min, _amountOfDescendants.Max);

            Vector3 offset = GetRandomOffset();

            for (int i = 0; i < descendantsNumber; i++)
            {
                GameObject child = Instantiate(_spawnedObject.gameObject, offset + this.transform.position, Quaternion.identity);
                SetChildParameters(child);
                child.SetActive(true);
            }
        }
    }

    private void SetChildParameters(GameObject child)
    {
        child.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Replicator parametersToSet = child.GetComponent<Replicator>(); 
        parametersToSet._amountOfDescendants = _amountOfDescendants;
        child.transform.localScale *= _scaleOfChild;
        parametersToSet._ratioOfReplicate = _ratioOfReplicate / _chanceDecayingRate; ;
        parametersToSet._chanceDecayingRate = _chanceDecayingRate;
    }

    private Vector3 GetRandomOffset()
    {
        float xOffset = this.transform.localScale.x * GetRandomValue();
        float yOffset = this.transform.localScale.y * GetRandomValue();
        float zOffset = this.transform.localScale.z * GetRandomValue();

        return new Vector3(xOffset, yOffset, zOffset);
    }
}
