using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class CreatureGenTest : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject torsoPrefab;
    public GameObject limbPrefab;
    GameObject creature, currentTorso, newTorso, currentLimb, newLimb;
    CreatureDNA adn;
    void Start()
    {
        creature = Object.Instantiate(creaturePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        currentTorso = Object.Instantiate(torsoPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity, creature.transform);
        adn = creature.GetComponent<CreatureDNA>();
        for(int i = 0; i < adn.torsoSelfReflec; i++){

        }
    }
}
