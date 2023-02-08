using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour

{
    [SerializeField] private string mensaje;
    // Start is called before the first frame update
    void Start()
    {
        Saludar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Saludar()
    {
        Debug.Log(mensaje);
    }
}
