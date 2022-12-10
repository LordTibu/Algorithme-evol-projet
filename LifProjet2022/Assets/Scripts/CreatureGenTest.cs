using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;

public class CreatureGenTest : MonoBehaviour
{  
    public GameObject creaturePrefab;
    public GameObject [] torsoPrefab;
    public GameObject [] limbPrefab;
    GameObject creature, currentTorso, newTorso, currentLimb, newLimb, creaturesIN;
    Vector3 [] tabpos;
    CreatureDNA adn;
    private bool armL= false, armR= false, armT= false, armB= false, armRZ= false, armLZ = false;

    void addArmLeft(){
        armL = true;
        newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0.5f,0,0);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        Debug.Log("added a limb to main torso left");
    }

    void addArmRight() {
        armR = true;
        newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(-0.5f,0,0);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }
        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        
        Debug.Log("added a limb to main torso right");
    }

    void addArmRightZ() {
        armRZ =true;
        newLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0,0,-0.5f);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }
        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        
        Debug.Log("added a limb to main torso rightZZZ");
    }

    void addArmLeftZ() {
        armLZ = true;
        newLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0,0,0.5f);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }
        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        
        Debug.Log("added a limb to main torso leftZZZ");
    }

    void addArmTop () {
        armT=true;
        newLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0, -0.8f,0);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }
        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        Debug.Log("added a limb to main torso TOP");
    }

    void addArmBottom() {armB= true;
        newLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
        ConfigurableJoint fJoint = newLimb.GetComponent<ConfigurableJoint>();
        fJoint.anchor = new Vector3(0,0.8f,0);
        int randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularXMotion= ConfigurableJointMotion.Free;        
        }
        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularYMotion= ConfigurableJointMotion.Free;        
        }

        randL = Random.Range(0,2);
        if (randL == 0)
        {
            fJoint.angularZMotion= ConfigurableJointMotion.Free;       
        }

        Vector3 Vel= new Vector3 (Random.Range(0f,21f),Random.Range(0f,21f),Random.Range(0f,21f));
        fJoint.targetAngularVelocity = Vel;
        JointDrive drive = fJoint.slerpDrive;
        JointDrive drive2 = fJoint.slerpDrive;
        drive.positionSpring = Random.Range(0,9);
        drive.positionDamper = Random.Range(0,5);
        drive2.positionSpring = Random.Range(0,9);
        drive2.positionDamper = Random.Range(0,5);
        fJoint.angularYZDrive= drive;
        fJoint.angularXDrive= drive2;
        fJoint.connectedBody = currentTorso.GetComponent<Rigidbody>();
        
        Debug.Log("added a limb to main torso DOWN");
    }

    void addRandLim () {
        int randL = Random.Range(0,6);
                    switch(randL){
                        case 0: if(!armT){
                                    addArmTop();
                                }else {
                                    addRandLim (); 
                                    }
                                    break;
                                
                        case 1: if(!armB){
                                    addArmBottom();
                                }else {
                                    addRandLim () ;
                                    }
                                    break;
                        case 2: if(!armL){
                                    addArmLeft();
                                }else {
                                    addRandLim () ;
                                    }
                                    break;
                        case 3: if(!armR){
                                    addArmRight();
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                        case 4: if(!armRZ){
                                    addArmRightZ();
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                        case 5: if(!armLZ){
                                    addArmLeftZ();
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                    }
    }

    void Start()
    {    
        //On cree une creature (empty object avec script qui contient des info)
        creature = Object.Instantiate(creaturePrefab, transform.position, Quaternion.identity);
        //On recupéré les données (qui sont crées aléatoirement en appelant la function .create() )
        adn = creature.GetComponent<CreatureDNA>();
        adn.create();
        //On crée un torso; fils de creature
        currentTorso = Object.Instantiate(torsoPrefab[0], transform.position, Quaternion.identity, creature.transform);
        int rand;
        if(adn.limbNumb > 0 && adn.limbNumb < 7){ //Dependiendo del numero de limbs que alla  (min 0, max 6) pone aleatoriamente un numero exacto de miembros 
            for(int i = 0; i< adn.limbNumb; i ++)
            {
                addRandLim();
            }
        } else {
            rand = Random.Range(1, 7); // Si queremos aleatoriedad solo toca poner el numero de limbs diferente a  1;6 
                                        // para que genere una creatura con miembros aleatorios
            for(int i = 0; i< rand; i ++)
            {
                addRandLim();
            }
        }
        
    }

    void Update(){
        if(Input.GetKey("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
