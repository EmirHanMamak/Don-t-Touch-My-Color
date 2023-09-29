using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    public static SingletonBanner bannerInstance = null;
    private void Start()
    {
        if (bannerInstance == null)
        {
            bannerInstance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != bannerInstance)
        {
            Destroy(gameObject);
        }
    }
}
