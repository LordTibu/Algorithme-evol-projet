using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{   

    public string textS;
    public Text txt;
    public GameObject manager;
    private CreatureManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = manager.GetComponent<CreatureManager>();
        textS = "Generation: \r\n" + cm.generation +
        "Last generation max fitness:  \r\n" + cm.fitnessMax +
        "Last generation average fitness: " + cm.fitnessSum/cm.NUMBER_OF_CREATURES;
        txt.text = textS;
    }

    // Update is called once per frame
    void Update()
    {
        textS = "Generation: " + cm.generation + "\r\n" +
        "Last generation max fitness: " + cm.fitnessMax + "\r\n" +
        "Last generation average fitness: " + cm.fitnessSum/cm.NUMBER_OF_CREATURES;
        txt.text = textS;
    }
}
