using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    Vector3 myVector;
    // Start is called before the first frame update
    void Start()
    {
        //DamagePopUp.Create(Vector3.zero, 300);
        myVector = new Vector3(12.0f, 0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DamagePopUp.Create(myVector,1);
        }
    } 
}
