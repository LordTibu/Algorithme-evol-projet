using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;

public class CreatureGenTest : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject torsoPrefab;
    public GameObject limbPrefab;
    GameObject creature, currentTorso, newTorso, currentLimb, newLimb;
    CreatureDNA adn;
    float randX = 0, randY = 0, randZ = 0;
    void Start()
    {   
        //On cree une creature (empty object avec script qui contient des info)
        creature = Object.Instantiate(creaturePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //On recupéré les données (qui sont crées aléatoirement en appelant la function .create() )
        adn = creature.GetComponent<CreatureDNA>();
        adn.create();
        //On crée un torso; fils de creature
        currentTorso = Object.Instantiate(torsoPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity, creature.transform);
        //On ajoute les "bras" ou Limbs avec des rotations, positions et dimensions aleatoires (toujours en contact avec torso)
        for(int i = 0; i < adn.limbNumb; i++){
            Debug.Log("added a limb to main torso");
            newLimb = Object.Instantiate(limbPrefab, new Vector3(0f, 0f, 0f), Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            ), currentTorso.transform);
            Vector3 limbScale = newLimb.transform.localScale;
            newLimb.transform.localScale = new Vector3(
                limbScale.x * Random.Range(0.1f, 0.8f),
                limbScale.y * Random.Range(0.1f, 0.8f),
                limbScale.z * Random.Range(0.1f, 0.8f));
            randX = Random.Range((currentTorso.transform.localScale.x / 2 + newLimb.transform.localScale.x / 2) * -1f,
             currentTorso.transform.localScale.x / 2 + newLimb.transform.localScale.x / 2);
            randY = Random.Range(newLimb.transform.localScale.y / 2 + 
             (currentTorso.transform.localScale.y / 2 + newLimb.transform.localScale.y) * 0f,
             currentTorso.transform.localScale.y / 2 + newLimb.transform.localScale.y / 2);
            randZ = Random.Range((currentTorso.transform.localScale.z / 2 + newLimb.transform.localScale.z / 2) * -1f,
             currentTorso.transform.localScale.z / 2 + newLimb.transform.localScale.z / 2);
            newLimb.transform.position = new Vector3(randX, randY, randZ);
            //On ajoute une fixedJoint pour rattacher les limbs au torso
            FixedJoint fJoint = newLimb.GetComponent<FixedJoint>();
            fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        }
        /*for(int i = 0; i < adn.torsoSelfReflec; i++){
            newTorso = Object.Instantiate(torsoPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity, creature.transform);
            for(int y = 0; y < adn.limbNumb; y++){
                newLimb = Object.Instantiate(limbPrefab, new Vector3(0f, 2f, 0f), Quaternion.identity, currentTorso.transform);
            }
            currentTorso = newTorso;
        }*/
        
    }

    void Update(){
        if(Input.GetKey("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
