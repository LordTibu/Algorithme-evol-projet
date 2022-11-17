using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class CreatureGenTest : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject [] torsoPrefab;
    public GameObject [] limbPrefab;
    GameObject creature, currentTorso, newTorso, currentLimb, newLimb;
    Vector3 [] tabpos;
    CreatureDNA adn;
    void Start()
    {   
        //On cree une creature (empty object avec script qui contient des info)
        creature = Object.Instantiate(creaturePrefab, transform.position, Quaternion.identity);
        //On recupéré les données (qui sont crées aléatoirement en appelant la function .create() )
        adn = creature.GetComponent<CreatureDNA>();
        adn.create();
        int randIndexTorso = Random.Range(0, torsoPrefab.Length);
        int randIndexLimb = Random.Range(0, limbPrefab.Length);


        //On crée un torso; fils de creature
        currentTorso = Object.Instantiate(torsoPrefab[randIndexTorso], transform.position, Quaternion.identity, creature.transform);
        //On ajoute les "bras" ou Limbs avec des rotations, positions et dimensions aleatoires (toujours en contact avec torso)

        
        Debug.Log("added a limb to main torso right");
        newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0.5f,0,0);
        int rand = Random.Range(0,2);
        if (rand == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        rand = Random.Range(0,2);
        if (rand == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (0,Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,8);
        drive.positionDamper = Random.Range(0,4);
        fJoint.angularYZDrive= drive;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();

        Debug.Log("added a limb to main torso left");
        newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint CJoint = newLimb.GetComponent<ConfigurableJoint>();
        CJoint.anchor = new Vector3(-0.5f,0,0);
        rand = Random.Range(0,2);
        if (rand == 0)
        {
            CJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }
        rand = Random.Range(0,2);
        if (rand == 0)
        {
            CJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }
        
        Vel= new Vector3 (0,Random.Range(0f,21f),Random.Range(0f,21f));
        CJoint.targetAngularVelocity = Vel;
        drive = CJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,8);
        drive.positionDamper = Random.Range(0,4);
        CJoint.angularYZDrive= drive;
        CJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();

        
        /*/for(int i = 0; i < 2; i++){
            Debug.Log("added a limb to main torso");
            newLimb = Object.Instantiate(limbPrefab[randIndexLimb], transform.position, Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            ), currentTorso.transform);
        */

            //On ajoute une ConfigurableJoint pour rattacher les limbs au torso
            //ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
            //fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        //}
        /*for(int i = 0; i < adn.torsoSelfReflec; i++){
            newTorso = Object.Instantiate(torsoPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity, creature.transform);
            for(int y = 0; y < adn.limbNumb; y++){
                newLimb = Object.Instantiate(limbPrefab, new Vector3(0f, 2f, 0f), Quaternion.identity, currentTorso.transform);
            }
            currentTorso = newTorso;
        }*/
        
    }
}
