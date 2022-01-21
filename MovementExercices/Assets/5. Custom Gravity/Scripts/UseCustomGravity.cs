using UnityEngine;

public class UseCustomGravity : MonoBehaviour
{
    public bool useSphericalGravity;

    public static UseCustomGravity instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Debug.LogError("More than one GameManager instance in the scene !");
    }
}
