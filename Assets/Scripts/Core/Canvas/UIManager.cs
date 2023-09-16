using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Canvas
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        private float _fadeOutInTime = 0.5f;
        private int _effectControl = 0;
        
        public IEnumerator Fade()
        {
            //yield return new WaitForSeconds(0.15f);
            fadeImage.gameObject.SetActive(true);
            while (_effectControl == 0)
            {
                if (fadeImage.color == new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f))
                {
                    _effectControl = 1;
                }
                yield return new WaitForSeconds(0.0001f);
                fadeImage.color += new Color(0f, 0f, 0f,0.1f);
            }

            while (_effectControl == 1)
            {
                Debug.Log("Inside");
                if (fadeImage.color == new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f))
                {
                    Debug.Log("Inside22");

                    _effectControl = 2;
                }
                yield return new WaitForSeconds(0.0001f);
                fadeImage.color += new Color(0, 0, 0,-0.1f);
            }
        }
    }
}
