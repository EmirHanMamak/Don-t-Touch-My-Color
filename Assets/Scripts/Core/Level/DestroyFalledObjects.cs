using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Level
{
    public class DestroyFalledObjects : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning("istouced");
            Destroy(other.gameObject);
        }
    }
}
