using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


//[DllImport("k8055d.dll")]
public class EEGManager : MonoBehaviour
{
    [DllImport("Nyp.Razor.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    [DllImport("Nyp.Razor.dll")]
    private static extern IntPtr GetActiveWindow();
    // Start is called before the first frame update
    void Start()
    {
        //IntPtr hWnd = GetActiveWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
