using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public GameObject manager;
    private CreatureManager cm;
    public Transform following;
    public float speed = 0.125f;
    public Vector3 offset = new Vector3(0, 5, -10);
    private int x = 0;
    private string txtS;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        if(speed > 1) speed = 0.125f;
        cm = manager.GetComponent<CreatureManager>();
        txtS = "Currently expectating individual: 0";
        txt.text = txtS;
    }

    // Update is called once per frame
    void Update()
    {
        txtS = "Currently expectating individual: " + x;
        txt.text = txtS;
    }

    void FixedUpdate(){
        if(Input.GetKey("a")){
            x--;
            if(x < 0) x = cm.NUMBER_OF_CREATURES - 1;
        }
        if(Input.GetKey("e")){
            x++;
            if(x > cm.NUMBER_OF_CREATURES - 1) x = 0;
        }
        following = cm.creatures[x].transform;
        Vector3 desiredPos = following.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, speed);
        transform.position = smoothPos;
        transform.LookAt(following);
    }
}
