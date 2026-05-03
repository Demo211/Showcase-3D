using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]  private float _chanceToReplicate = 1f;
    public float ChanceToReplicate => _chanceToReplicate;

    public void SetCubeParameters(float chanceToReplicate, Vector3 scale)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _chanceToReplicate = chanceToReplicate;
        transform.localScale = scale;
    }
}
