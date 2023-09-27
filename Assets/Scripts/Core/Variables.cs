using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Variables : MonoBehaviour
    {
        public static int firstTouch = 0;
        public static int GameCondition = -1;
        public static int GC_Started = 0, GC_ENDED = 1;
        
        /*
         * CAMERA
         */
        public static float fowardsSpeed = 5f;
    }
}
