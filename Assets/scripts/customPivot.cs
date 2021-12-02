using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customPivot : MonoBehaviour
{
    public float gizmoSize = .75f;

    public float rotationSpeed = 360f;
    public Color gizmoColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }

}
