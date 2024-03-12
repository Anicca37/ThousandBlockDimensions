using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineGrowthController : MonoBehaviour
{
    public List<GameObject> vines;
    public Vector3 maxScale = new Vector3(10f, 10f, 10f);
    private Dictionary<GameObject, Vector3> originalVineScales = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        // Initialize the vines with a scale of 0 (invisible)
        foreach (var vine in vines)
        {
            vine.transform.localScale = Vector3.zero;
            originalVineScales[vine] = maxScale;
        }
    }

    // Call this method to update the vines' growth based on the clock's rotation
    public void UpdateVineGrowth(float rotationAmount)
    {
        float growthFactor = Mathf.Clamp((Mathf.Abs(rotationAmount) % 360) / 360f, 0f, 1f);
        foreach (var vine in vines)
        {
            vine.transform.localScale = Vector3.Lerp(Vector3.zero, originalVineScales[vine], growthFactor);
        }
    }
}
