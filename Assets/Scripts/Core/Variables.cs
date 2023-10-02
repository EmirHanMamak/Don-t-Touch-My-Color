using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Variables : MonoBehaviour
    {
        public static int currentLevel;
        public static int firstTouch = 0;
        public static int GameCondition = -1;
        public static int GC_NONE = -1, GC_Started = 0, GC_ENDED = 1, GC_NEXTLEVEL = 2;
        /*
         * CAMERA
         */
        public static float fowardsSpeed = 5f;
    }
}
