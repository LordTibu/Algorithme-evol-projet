using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEx : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public GameObject armPrefab;
    public GameObject Eve;
    int x = 0, z = 0;
    GameObject Clone, Father, Arm;
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
        x = -5;
        //Father = Object.Instantiate(creaturePrefab, new Vector3(x, 0f, z), Quaternion.identity);
        Clone = Object.Instantiate(bodyPrefab, new Vector3(x,
         bodyPrefab.transform.lossyScale.y / 2, z), Quaternion.identity);
        Arm = Object.Instantiate(armPrefab, new Vector3(
         Clone.transform.position.x + (Clone.transform.lossyScale.x + armPrefab.transform.lossyScale.x) / 2,
         0f, z), Quaternion.identity);
        HingeJoint hJoint = Arm.GetComponent(typeof(HingeJoint)) as HingeJoint;
        hJoint.connectedBody = Clone.GetComponent(typeof(Rigidbody)) as Rigidbody;
        hJoint.connectedAnchor = new Vector3(
         (Clone.transform.lossyScale.x + armPrefab.transform.lossyScale.x) / 2,
          armPrefab.transform.lossyScale.y, 0f);
        Arm = Object.Instantiate(armPrefab, new Vector3(
         Clone.transform.position.x - (Clone.transform.lossyScale.x + armPrefab.transform.lossyScale.x) / 2,
         0f, z), Quaternion.identity);
        HingeJoint h1Joint = Arm.GetComponent(typeof(HingeJoint)) as HingeJoint;
        h1Joint.connectedBody = Clone.GetComponent(typeof(Rigidbody)) as Rigidbody;
        h1Joint.connectedAnchor = new Vector3(
         -(Clone.transform.lossyScale.x + armPrefab.transform.lossyScale.x) / 2,
         armPrefab.transform.lossyScale.y, 0f);
    }
}
