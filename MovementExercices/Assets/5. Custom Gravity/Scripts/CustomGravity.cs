using UnityEngine;

public static class CustomGravity 
{
    public static Vector3 GetGravity(Vector3 position)
    {
        if(UseCustomGravity.instance.useSphericalGravity)
        {
            return position.normalized * Physics.gravity.y;
        }
        else
        {
            return Physics.gravity;
        }
    }

    public static Vector3 GetUpAxis(Vector3 position)
    {
        if (UseCustomGravity.instance.useSphericalGravity)
        {
            Vector3 up = position.normalized;
            return Physics.gravity.y < 0f ? up : -up;
        }
        else
        {
            return -Physics.gravity.normalized;
        }
    }

    public static Vector3 GetGravity(Vector3 position, out Vector3 upAxis)
    {
        if (UseCustomGravity.instance.useSphericalGravity)
        {
            Vector3 up = position.normalized;
            upAxis = Physics.gravity.y < 0f ? up : -up;
            return up * Physics.gravity.y;
        }
        else
        {
            upAxis = -Physics.gravity.normalized;
            return Physics.gravity;
        }
    }
}
