using System.Collections.Generic;
using UnityEngine;
using static Utils;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private MinMaxPair _amountOfDescendants = new MinMaxPair(2,2);
    [Range(0f, 1f)] public float _ratioOfReplicate = 1.0f;
    [SerializeField] private float _chanceDecayingRate = 2f;
    [SerializeField, Range(0f, 1f)] private float _scaleOfChild = 0.5f;    

    [SerializeField] private GameObject spawnedObject;

    [SerializeField] private float _explosionForce;

    private void OnDestroy()
    {
        Explode();        
    }


    private void Explode()
    {
        if (IsProcessed(_ratioOfReplicate))
        {
            int descendantsNumber = GetRandomNumber(_amountOfDescendants.Min, _amountOfDescendants.Max);

            Vector3 offset = GetRandomOffset();

            for (int i = 0; i < descendantsNumber; i++)
            {
                GameObject child = Instantiate(spawnedObject, offset + this.transform.position, Quaternion.identity);
                SetChildParameters(child);
                child.SetActive(true);

                child.GetComponent<Rigidbody>().AddForce(offset * _explosionForce);
            }
        }


    }

    private void SetChildParameters(GameObject child)
    {
        child.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        CubeDivider parametersToSet = child.GetComponent<CubeDivider>(); 
        parametersToSet._amountOfDescendants = _amountOfDescendants;
        child.transform.localScale *= _scaleOfChild;
        parametersToSet._ratioOfReplicate = _ratioOfReplicate / _chanceDecayingRate; ;
        parametersToSet._chanceDecayingRate = _chanceDecayingRate;
        parametersToSet._explosionForce = _explosionForce;
    }

    private Vector3 GetRandomOffset()
    {
        float xOffset = this.transform.localScale.x * GetRandomValue();
        float yOffset = this.transform.localScale.y * GetRandomValue();
        float zOffset = this.transform.localScale.z * GetRandomValue();

        return new Vector3(xOffset, yOffset, zOffset);
    }
}
