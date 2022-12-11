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
    GameObject creature, currentTorso, newTorso, currentLimb, newLimb, creaturesIN , newRefLimb;
    Vector3 [] tabpos;
    CreatureDNA adn;
    private bool armL= false, armR= false, armT= false, armB= false, armRZ= false, armLZ = false;

    void addArm(int n) {
        ConfigurableJoint fJoint = null;
        switch(n){ // 0 top, 1 Bottom, 2 left, 3 right, 4 rightz, 5 leftz
            case 0 :armT = true; 
                    newLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0, 0.2f - currentTorso.transform.localScale.y,0);
                    break;
            case 1 :armB = true;
                    newLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0,currentTorso.transform.localScale.y - 0.2f,0);
                    break;
            case 2 :armL = true;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(currentTorso.transform.localScale.x - 0.2f,0,0);
                    break;
            case 3 :armR = true;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>(); 
                    fJoint.anchor = new Vector3(0.2f - currentTorso.transform.localScale.x,0,0);
                    break;
            case 4 :armRZ = true;
                    newLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>(); 
                    fJoint.anchor = new Vector3(0,0,0.2f -currentTorso.transform.localScale.z);
                    break;
            case 5 :armLZ = true;
                    newLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();  
                    fJoint.anchor = new Vector3(0,0,currentTorso.transform.localScale.z - 0.2f);
                    break;
        }
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
        
        Debug.Log("added a limb to main torso");
    }

    void addArmSelf(int n) {
        ConfigurableJoint fJoint = null;
        switch(n){ // 0 top, 1 Bottom, 2 left, 3 right, 4 rightz, 5 leftz
            case 0 : if(armT){
                        newRefLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>();
                        fJoint.anchor = new Vector3(0, -0.5f,0);
                        fJoint.connectedAnchor = new Vector3(0, 0.5f,0);
                        
                    }
                    break;
            case 1 :if(armB){
                        newRefLimb = Object.Instantiate(limbPrefab[1], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>();
                        fJoint.anchor = new Vector3(0, 0.5f,0);
                        fJoint.connectedAnchor = new Vector3(0, -0.5f,0);
                    
                    }
                    break;
            case 2 :if(armL){
                        newRefLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>();
                        fJoint.anchor = new Vector3(0.5f, 0,0);
                        fJoint.connectedAnchor = new Vector3(-0.5f, 0,0);
                    }
                    break;
            case 3 :if(armR){
                        newRefLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>(); 
                        fJoint.anchor = new Vector3(-0.5f, 0,0);
                        fJoint.connectedAnchor = new Vector3(0.5f, 0,0);
                    }
                    break;
            case 4 :if(armRZ){
                        newRefLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>(); 
                        fJoint.anchor = new Vector3(0,0,-0.5f);
                        fJoint.connectedAnchor = new Vector3(0, 0,0.5f);
                    }
                    break;
            case 5 :if(armLZ){
                        newRefLimb = Object.Instantiate(limbPrefab[2], transform.position, Quaternion.identity, currentTorso.transform);
                        fJoint = newRefLimb.GetComponent<ConfigurableJoint>();  
                        fJoint.anchor = new Vector3(0,0,0.5f);
                        fJoint.connectedAnchor = new Vector3(0, 0,-0.5f);
                    }
                    break;
        }
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
        fJoint.connectedBody = newLimb.GetComponent<Rigidbody>();
        
        Debug.Log("added a limb to self reflc");
    }


    void addRandLim() {
        int randL = Random.Range(0,6);
        int randLL = Random.Range(0, 2);
                    switch(randL){
                        case 0: if(!armT){ // si il y a pas un bras sur le torse en top 
                                    addArm(0);
                                }else {
                                    //addArmSelf(0);
                                    addRandLim(); 
                                    }
                                    break;
                                
                        case 1: if(!armB){
                                    addArm(1);
                                }else {
                                    //addArmSelf(1);
                                    addRandLim () ;
                                    }
                                    break;
                        case 2: if(!armL){
                                    addArm(2);
                                }else {
                                    //addArmSelf(2);
                                    addRandLim () ;
                                    }
                                    break;
                        case 3: if(!armR){
                                    addArm(3);
                                }else {
                                    //addArmSelf(3);
                                    addRandLim () ;
                                    } 
                                    break;
                        case 4: if(!armRZ){
                                    addArm(4);
                                }else {
                                    //addArmSelf(4);
                                    addRandLim () ;
                                    } 
                                    break;
                        case 5: if(!armLZ){
                                    addArm(5);
                                }else {
                                    //addArmSelf(5);
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
