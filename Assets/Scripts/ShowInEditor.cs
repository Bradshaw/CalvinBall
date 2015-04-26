using UnityEngine;
using System.Collections;

public class ShowInEditor : MonoBehaviour {

    public Color color;
    public float size;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);
    }

}
