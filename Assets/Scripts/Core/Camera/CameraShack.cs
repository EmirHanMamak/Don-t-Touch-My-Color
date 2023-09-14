using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Camera
{
    public class CameraShack : MonoBehaviour
    {
        private bool _shackControl = false;
        public IEnumerator CameraShacks(float duration, float magnitude)
        {
            Vector3 orginalPos = transform.localPosition;
            float elapsed = 0f;
            while (elapsed < duration)
            {

                float x = Random.Range(-1, 1) * magnitude;
                float y = Random.Range(-1, 1) * magnitude;
                transform.localPosition = new Vector3(x, y, orginalPos.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            transform.localPosition = orginalPos;
        }

        public void CameraShackCall()
        {
            if(_shackControl) return;
            StartCoroutine(CameraShacks(0.22f, 0.40f));
            _shackControl = true;
        }
    }
}
