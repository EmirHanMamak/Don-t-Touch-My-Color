using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Level;
using UnityEngine;

namespace Core.Camera
{
    public class CameraMove : MonoBehaviour
    {
        // Start is called before the first frame update
        private LevelDesignController _levelDesignController;
        void LateUpdate()
        {
            if (Variables.GameCondition == Variables.GC_Started)
            {
                transform.position += new Vector3(0f, 0f, Variables.fowardsSpeed * Time.deltaTime);
            } 
        }
    }
}
