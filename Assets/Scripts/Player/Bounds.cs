using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private Vector3 backVector;
    [SerializeField] private Vector3 upVector;
    [SerializeField] private Vector3 rightVector;
    [SerializeField] private Vector3 leftVector;

    private void LateUpdate()
    {
        Vector3 viewVector = transform.position;
        viewVector.z = Mathf.Clamp(viewVector.z, backVector.z, upVector.z);
        viewVector.x = Mathf.Clamp(viewVector.x, leftVector.x, rightVector.x);
        transform.position = viewVector;
    }
}