using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.InteropServices;

public class Main : MonoBehaviour {
    [DllImport("rust_unity")]
    private static extern IntPtr rust_string(int num);

    [DllImport("rust_unity")]
    private static extern IntPtr rust_string_arg(IntPtr param);

    [DllImport("rust_unity")]
    private static extern IntPtr rust_string_array();

    [DllImport("rust_unity")]
    private static extern int rust_mul(int a, int b);

    [DllImport("rust_unity")]
    private static extern bool rust_bool(int num);

    // Use this for initialization
    void Start () {
        IntPtr res = rust_string(3);
        Debug.Log(Marshal.PtrToStringAnsi(res));

        string strPath = "from unity";
        IntPtr ptrPath = Marshal.StringToHGlobalAnsi(strPath);
        IntPtr resArg = rust_string_arg(ptrPath);
        Debug.Log(Marshal.PtrToStringAnsi(resArg));

        int len = 3;
        IntPtr resArray = rust_string_array();
        IntPtr[] array = new IntPtr[len];
        Marshal.Copy(resArray, array, 0, len);

        for (int i = 0; i< array.Length; i++)
        {
            string rustStr = Marshal.PtrToStringAnsi(array[i]);
            Debug.Log(rustStr);
        }

        int mulRes = rust_mul(3, 5);
        Debug.Log(mulRes);

        bool b = rust_bool(3);
        Debug.Log(b);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
