using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    public static SingletonBanner bannerInstance = null;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (bannerInstance == null)
        {
            bannerInstance = this;
        }
        else if (this != bannerInstance)
        {
            Destroy(gameObject);
        }
    }
}
