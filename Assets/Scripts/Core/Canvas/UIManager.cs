using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Canvas
{
    public class UIManager : MonoBehaviour
    { 
    [SerializeField] private Image fadeImage;
    [SerializeField] private Animator settingsAnimator;
        private float _fadeOutInTime = 0.5f;
        private int _effectControl = 0;
        /*
         * BUTTONS
         */
        [SerializeField] private GameObject settingsOpen, settingsClose;
        [SerializeField] private GameObject soundOpen, soundClose;
        [SerializeField] private GameObject vibrationOpen, vibrationClose;
        private string _privacyPolicyUrl = "https://www.emirhanmamak.com/privacy-policy/";
        private string _termsOfUse = "https://www.emirhanmamak.com/term-of-use/";
        public void PrivacyPolicyClick()
        {
            Application.OpenURL(_privacyPolicyUrl);
        }
        public void TermsOfUseClick()
        {
            Application.OpenURL(_termsOfUse);
        }
        public void SoundButtonOn()
        {
            soundOpen.SetActive(false);
            soundClose.SetActive(true);
        }
        public void SoundButtonOff()
        {
            soundOpen.SetActive(true);
            soundClose.SetActive(false);
        }        
        public void VirbationButtonOn()
        {
            vibrationOpen.SetActive(false);
            vibrationClose.SetActive(true);
        }
        public void VirbationButtonOff()
        {
            vibrationOpen.SetActive(true);
            vibrationClose.SetActive(false);
        }
        public void SettingsButonOpen()
        {
            settingsAnimator.SetTrigger("SettingsOpen");
            settingsAnimator.ResetTrigger("SettingsClose");
            settingsOpen.SetActive(false);
            settingsClose.SetActive(true);
        }
        public void SettingsButonClose()
        {
            settingsAnimator.SetTrigger("SettingsClose");
            settingsAnimator.ResetTrigger("SettingsOpen");
            settingsOpen.SetActive(true);
            settingsClose.SetActive(false);
        }
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
