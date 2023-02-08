using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class ControlCuadrado : MonoBehaviour
{
    HelloWorld helloWorld; 
    // Start is called before the first frame update
    void Start()
    { 
       helloWorld = helloWorld.GetComponent<HelloWorld>();
       helloWorld.Saludar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
