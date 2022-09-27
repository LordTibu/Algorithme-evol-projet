using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMov : MonoBehaviour
{
    public Rigidbody ball;
    public Rigidbody armA;
    public Rigidbody armB;
    public float movForce = 50;
    void FixedUpdate(){
        if(Input.GetKey("z")){
            //ball.AddForce(new Vector3(0f, 0f, movForce));
            armA.AddRelativeTorque(new Vector3(20f, 0f, 0f));
            armB.AddRelativeTorque(new Vector3(20f, 0f, 0f));
        }
        if(Input.GetKey("q")) ball.AddForce(new Vector3(-movForce, 0f, 0f));
        if(Input.GetKey("s")){
            //ball.AddForce(new Vector3(0f, 0f, -movForce));
            armA.AddRelativeTorque(new Vector3(-20f, 0f, 0f));
            armB.AddRelativeTorque(new Vector3(-20f, 0f, 0f));
        }
        if(Input.GetKey("d")) ball.AddForce(new Vector3(movForce, 0f, 1f));
    }
}
