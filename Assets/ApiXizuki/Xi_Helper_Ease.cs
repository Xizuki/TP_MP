using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XizukiMethods
{
    namespace Data
    {
        public static class Xi_Helper_Ease
        {
            public static List<float> easeValues;
            static float test;
            public static float GetValues(ref float var)
            {
                return var;
            }
            public static IEnumerator StartEase(float test)
            {
                while(test > 0) 
                {
                    yield return null;
                }
            }

         
        }

     
    }

}