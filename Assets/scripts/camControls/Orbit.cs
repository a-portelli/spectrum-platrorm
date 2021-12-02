using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;

    public float horizMove = 1f;
    public float vertMove = 1f;

    public void MoveHorizontal(bool left)
    {
        float dir = 1;
        if (!left)
        {
            dir *= -1;
        }
        transform.RotateAround(target.position, Vector3.up, horizMove * dir);
    }

    public void MoveVert(bool up)
    {
        float dir = 1;
        if (!up)
        {
            dir *= -1;
        }
        transform.RotateAround(target.position, transform.TransformDirection(Vector3.right), vertMove * dir);
    }
}
