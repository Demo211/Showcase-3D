using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]  private float _chanceToReplicate = 1f;

    public float ChanceToReplicate => _chanceToReplicate;

    public void SetParameters(Cube parent, float chanceReductionRatio, float sizeRatio)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _chanceToReplicate = parent.ChanceToReplicate / chanceReductionRatio;
        transform.localScale = parent.transform.localScale * sizeRatio;
    }
}
