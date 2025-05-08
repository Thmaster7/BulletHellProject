using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Rotate(this Vector2 originalVector, float rotateAngleInDegress)
    {
        Quaternion rotation = Quaternion.AngleAxis(rotateAngleInDegress, Vector3.forward);
            return rotation * originalVector;
    }
}
