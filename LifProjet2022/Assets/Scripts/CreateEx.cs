using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEx : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public GameObject Eve;
    int x = 0, z = 0;
    GameObject Clone;
    void Start()
    {
        //Cloning a Head into an existing Body
        Clone = Object.Instantiate(headPrefab, new Vector3(x,
         Eve.transform.position.y + 0.75f, z), Quaternion.identity, Eve.transform);
        Debug.Log("The name of the new object is " + Clone.name);
        //Cloning a Head and a Body directly from the prefabs
        /*x += 5;
        Clone = Object.Instantiate(bodyPrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
        Clone = Object.Instantiate(headPrefab, new Vector3(x, 1.25f, z), Quaternion.identity, Clone.transform);
        Debug.Log("The name of the new object is " + Clone.name);
        x = -5;
        Object.Instantiate(Eve, new Vector3(x, 1.25f, z), Quaternion.identity);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
