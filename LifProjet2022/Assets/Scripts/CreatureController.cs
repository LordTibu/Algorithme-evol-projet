using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public GameObject [] limbPrefab;
    private GameObject creature, currentTorso, newTorso, currentLimb, newLimb, creaturesIN , newRefLimb;
    private bool armL= false, armR= false, armT= false, armB= false, armRZ= false, armLZ = false;
    public int limbNumb;
    public float fitnessScore;
    public Vector3 startPosition;
    void Start()
    {
        currentTorso = this.gameObject;
        startPosition = this.transform.position;
    }

    public void init(){
        currentTorso = this.gameObject;
        int rand = Random.Range(1, 7);
        limbNumb = rand;
        for(int i = 0; i< rand; i ++)
        {
            addRandLim();
        }
    }

    // Update is called once per frame
    void addArm(int n) {
        ConfigurableJoint fJoint = null;
        switch(n){ // 0 top, 1 Bottom, 2 left, 3 right, 4 rightz, 5 leftz
            case 0 :armT = true; 
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.25f,1.25f,0.25f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0, 0.2f - currentTorso.transform.localScale.y,0);
                    break;
            case 1 :armB = true;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.25f,1.25f,0.25f);
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
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.23f,0.23f,1.41f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0,0,0.2f -currentTorso.transform.localScale.z);
                    break;
            case 5 :armLZ = true;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.23f,0.23f,1.41f);
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
        
        //Debug.Log("added a limb to main torso");
    }

    void addRandLim() {
        int randL = Random.Range(0,6);
                    switch(randL){
                        case 0: if(!armT){ // si il y a pas un bras sur le torse en top 
                                    addArm(0);
                                }else {
                                    addRandLim(); 
                                    }
                                    break;
                                
                        case 1: if(!armB){
                                    addArm(1);
                                }else {
                                    addRandLim () ;
                                    }
                                    break;
                        case 2: if(!armL){
                                    addArm(2);
                                }else {
                                    addRandLim () ;
                                    }
                                    break;
                        case 3: if(!armR){
                                    addArm(3);
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                        case 4: if(!armRZ){
                                    addArm(4);
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                        case 5: if(!armLZ){
                                    addArm(5);
                                }else {
                                    addRandLim () ;
                                    } 
                                    break;
                    }
    }

    public void calculateFitness(){
        startPosition[1] = 0;
        Vector3 currentPos = this.transform.position;
        currentPos[1] = 0;
        fitnessScore = Vector3.Distance(currentPos, startPosition);
    }

    public void reSpawn(){
        this.transform.position = startPosition;
    }

    public void crossover(GameObject parent1, GameObject parent2){
        // Sexo 
        currentTorso = this.gameObject;
        if(parent1 != null && parent2 != null){
            GameObject nino;
            int childs1 = parent1.transform.childCount;
            int childs2 = parent2.transform.childCount;
            int r = 0, pmin, pmax;
            GameObject maxParent;
            if(childs1 <= childs2){pmin = childs1; pmax = childs2; maxParent = parent2;}
            else{pmin = childs2; pmax = childs1; maxParent = parent1;}
            for(int i = 0; i < pmin; i++){
                r = Random.Range(0, 2);
                if(r == 0){
                    nino = Instantiate(parent1.transform.GetChild(i).gameObject, this.transform);
                    nino.GetComponent<ConfigurableJoint>().connectedBody = currentTorso.GetComponent<Rigidbody>();
                }
                else {
                    nino = Instantiate(parent2.transform.GetChild(i).gameObject, this.transform);
                    nino.GetComponent<ConfigurableJoint>().connectedBody = currentTorso.GetComponent<Rigidbody>();
                }
            }
            for(int i = pmin; i < pmax; i++){
                r = Random.Range(0, 2);
                if(r == 0){
                    nino = Instantiate(maxParent.transform.GetChild(i).gameObject, this.transform);
                    nino.GetComponent<ConfigurableJoint>().connectedBody = currentTorso.GetComponent<Rigidbody>();
                }
            }
        }
    }

    public void mutate(GameObject limb){
        int r = 1;
        r = Random.Range(0,10);
        if(r == 0){
            //mutate new limb
        }
        else{
            //mutate controllers inside limb
        }
    }

    public void kill(){
        Destroy(gameObject);
    }
}
