using UnityEngine;

namespace Player
{
    public class Bounds : MonoBehaviour
    {
        public Transform backVector;
        public Transform upVector;
        public Transform rightVector;
        public Transform leftVector;

        private void LateUpdate()
        {
            Vector3 viewVector = transform.position;
            viewVector.z = Mathf.Clamp(viewVector.z, backVector.transform.position.z, upVector.transform.position.z);
            viewVector.x = Mathf.Clamp(viewVector.x, leftVector.transform.position.x, rightVector.transform.position.x);
            transform.position = viewVector;
        }
    }
}