using UnityEngine;

public class AccelerationZone : MonoBehaviour
{
    [SerializeField, Min(0f)] float acceleration = 10f;
    [SerializeField] Vector3 speed = new Vector3(0f, 10f, 0f);

    void OnTriggerEnter(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;
        if (body) Accelerate(body);
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;
        if (body) Accelerate(body);
    }

    void Accelerate(Rigidbody body)
    {
        Vector3 velocity = transform.InverseTransformDirection(body.velocity);
        if ((speed.x != 0 && velocity.x >= speed.x) && (speed.y != 0 && velocity.y >= speed.y) && (speed.z != 0 && velocity.z >= speed.z)) return;

        if(acceleration > 0f)
        {
            if(speed.x != 0) velocity.x = Mathf.MoveTowards(velocity.x, speed.x, acceleration * Time.deltaTime);
            if (speed.y != 0) velocity.y = Mathf.MoveTowards(velocity.y, speed.y, acceleration * Time.deltaTime);
            if (speed.z != 0) velocity.z = Mathf.MoveTowards(velocity.z, speed.z, acceleration * Time.deltaTime);
        }
        else
        {
            if (speed.x != 0) velocity.x = speed.x;
            if (speed.y != 0) velocity.y = speed.y;
            if (speed.z != 0) velocity.z = speed.z;
        }

        body.velocity = transform.TransformDirection(velocity);

        if(body.TryGetComponent(out MovingSphereReactiveEnvironment sphere))
        {
            if(speed.y > 0f) sphere.PreventSnapToGround();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(speed));
    }
}
