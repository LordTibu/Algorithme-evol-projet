using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEx : MonoBehaviour
{
    public GameObject myPrefab;
    public Transform Eve;
    void Start()
    {
        //Object.Instantiate(myPrefab, new Vector3(0f, 2f, 0f), Quaternion.identity);
        Object.Instantiate(myPrefab, new Vector3(0f, 1.25f, 0f), Quaternion.identity, Eve);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
