using UnityEngine;

namespace Core.Level
{
    public class DestroyFalledObjects : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning("istouced");
            other.gameObject.SetActive(false);
        }
    }
}
