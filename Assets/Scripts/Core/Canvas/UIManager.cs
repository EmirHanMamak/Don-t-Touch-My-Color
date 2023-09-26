using System;
using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.Canvas
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        [SerializeField] private Animator settingsAnimator;
        private static int CT_OFF = 0, CT_ON = 1;
        private float _fadeOutInTime = 0.5f;
        private int _effectControl = 0;
        /*
         * BUTTONS
         */
        [SerializeField] private GameObject settingsOpen, settingsClose;
        [SerializeField] private GameObject soundOpen, soundClose;
        [FormerlySerializedAs("vibrationOpen")] [SerializeField] private GameObject hapticOpen;
        [FormerlySerializedAs("vibrationClose")] [SerializeField] private GameObject hapticClose;
        private string _privacyPolicyUrl = "https://www.emirhanmamak.com/privacy-policy/";
        private string _termsOfUse = "https://www.emirhanmamak.com/term-of-use/";

        private void Start()
        {
            CheckHasKey();

            CheckConditions();
        }

        private void CheckConditions()
        {
            /*
             * Sound
             */
            if (PlayerPrefs.GetInt(TagList.PP_Sound) == CT_ON)
            {
                SoundButtonOff();
            }
            else if (PlayerPrefs.GetInt(TagList.PP_Sound) == CT_OFF)
            {
                SoundButtonOn();
            }
            /*
             * Haptic 
             */
            if (PlayerPrefs.GetInt(TagList.PP_Haptic) == CT_ON)
            {
                HapticButtonOn();
            }
            else if (PlayerPrefs.GetInt(TagList.PP_Haptic) == CT_OFF)
            {
                HapticButtonOff();
            }
        }

        private static void CheckHasKey()
        {
            if (PlayerPrefs.HasKey(TagList.PP_Sound) == false)
            {
                PlayerPrefs.SetInt(TagList.PP_Sound, CT_ON);
            }

            if (PlayerPrefs.HasKey(TagList.PP_Haptic) == false)
            {
                PlayerPrefs.SetInt(TagList.PP_Haptic, CT_ON);
            }
        }

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
            PlayerPrefs.SetInt(TagList.PP_Sound, CT_OFF);
            AudioListener.volume = 0;
        }
        public void SoundButtonOff()
        {
            soundOpen.SetActive(true);
            soundClose.SetActive(false);
            PlayerPrefs.SetInt(TagList.PP_Sound, CT_ON);
            AudioListener.volume = 1;
        }        
        public void HapticButtonOn()
        {
            hapticOpen.SetActive(false);
            hapticClose.SetActive(true);
            PlayerPrefs.SetInt(TagList.PP_Haptic, CT_ON);
        }
        public void HapticButtonOff()
        {
            hapticOpen.SetActive(true);
            hapticClose.SetActive(false);
            PlayerPrefs.SetInt(TagList.PP_Haptic, CT_OFF);
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
