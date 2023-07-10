using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XizukiMethods
{
    namespace GameObjects
    {
        public static class Xi_Helper_GameObjects
        {

            public static bool MonoInitialization<T>(ref T variable, T AssignedValue)
            {
                if (variable is null)           // < Works for Unity Defined Classes
                {
                    variable = AssignedValue;
                    return true;
                }
                else if (variable.Equals(null)) // < Works for self defined Classes but not for ( Unity GetComponent<>() )   
                {
                    variable = AssignedValue;
                    return true;
                }
                // ^ No Idea why its different
                return false;
            }



            public static GameObject[] FilterOutWithScript<T>(GameObject[] GOs)
            {
                // Filter Out Gameobjects that doesnt have component <T>
                List<int> falseIndexes = new List<int>();
                for (int i = 0; i < GOs.Length; i++)
                {
                    if (GOs[i].GetComponent<T>() == null)
                    {
                        falseIndexes.Add(i);
                    }
                }
                return XizukiMethods.Array.Xi_Array.Remove(GOs, falseIndexes);
            }



            public static T[] FilterOutWithScript<T>(ref GameObject[] GOs)
            {
                // Filter Out Gameobjects that doesnt have component <T>
                // and return an array of component <T>

                List<int> falseIndexes = new List<int>();
                T[] scripts = new T[GOs.Length];

                for (int i = 0; i < GOs.Length; i++)
                {
                    if (GOs[i].GetComponent<T>() == null)
                    {
                        falseIndexes.Add(i);
                    }
                    else
                    {
                        scripts[i] = GOs[i].GetComponent<T>();
                    }
                }
               

                scripts = XizukiMethods.Array.Xi_Array.Remove(scripts, falseIndexes);

                GOs = XizukiMethods.Array.Xi_Array.Remove(GOs, falseIndexes);
                return scripts;
            }


        }
    }
}