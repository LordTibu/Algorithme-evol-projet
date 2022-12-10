using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureDNA : MonoBehaviour
{
    public int limbNumb = 0;
    public int limbSelfReflec = 0;
    public int torsoSelfReflec = 0;

    public void Start(){
        /*Debug.Log("A creature has been created");
        limbNumb = (int)Random.Range(0f, 5f);
        limbSelfReflec = (int)Random.Range(0f, 3f);
        torsoSelfReflec = (int)Random.Range(0f, 3f);
        Debug.Log("Limbs = " + limbNumb);
        Debug.Log("LimbsSelf = " + limbSelfReflec);
        Debug.Log("TorsoSelf = " + torsoSelfReflec);
        */
    }

    public void create(){
        Debug.Log("A creature has been created");
        /*limbNumb = (int)Random.Range(1f, 5f);
        limbSelfReflec = (int)Random.Range(0f, 3f);
        torsoSelfReflec = (int)Random.Range(0f, 3f);*/
        Debug.Log("Limbs = " + limbNumb);
        Debug.Log("LimbsSelf = " + limbSelfReflec);
        Debug.Log("TorsoSelf = " + torsoSelfReflec);
    }

    public void inContact(Vector3 position){
        
    }
}