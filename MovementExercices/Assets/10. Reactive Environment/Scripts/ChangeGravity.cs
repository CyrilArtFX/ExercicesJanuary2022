using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    [SerializeField] Vector3 gravity = default;

    public void Change()
    {
        Physics.gravity = gravity;
    }
}
