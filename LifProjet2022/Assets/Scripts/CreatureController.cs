using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public GameObject [] limbPrefab;
    private GameObject creature, currentTorso, newTorso, currentLimb, newLimb, creaturesIN , newRefLimb ,connection;
    private int armL= 0, armR= 0, armT= 0, armB= 0, armRZ= 0, armLZ = 0;
    public int limbNumb;
    public int limbNumbSelf;
    public float fitnessScore;
    public Vector3 startPosition;
    void Start()
    {
        currentTorso = this.gameObject;
        startPosition = this.transform.position;
    }

    public void init(){
        //Por mi santa madre no borres esta linea, se q deberia ser redundante pero no lo es,
        //y no entiendo pq, pero NO la borres
        currentTorso = this.gameObject;
        int rand = Random.Range(1, 7);
        limbNumb = rand;

        for(int i = 0 ; i < rand; i++){
            addRandLim();
        }
        //addRandLimTest(rand);
        Debug.Log("L  "+armL+" R  "+ armR+" T  "+ armT+" B  "+ armB+" RZ  "+ armRZ+" LZ  "+ armLZ);
    }

    // Update is called once per frame
    void addArm(int n) {
        ConfigurableJoint fJoint = null;
        switch(n){ // 0 top, 1 Bottom, 2 left, 3 right, 4 rightz, 5 leftz
            case 0 :armT ++; 
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.25f,1.25f,0.25f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0, 0.2f - currentTorso.transform.localScale.y,0);
                    break;
            case 1 :armB ++;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.25f,1.25f,0.25f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0,currentTorso.transform.localScale.y - 0.2f,0);
                    break;
            case 2 :armL ++;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(1.41f,0.23f,0.23f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(currentTorso.transform.localScale.x - 0.2f,0,0);
                    break;
            case 3 :armR ++;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(1.41f,0.23f,0.23f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>(); 
                    fJoint.anchor = new Vector3(0.2f - currentTorso.transform.localScale.x,0,0);
                    break;
            case 4 :armRZ ++;
                    newLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, currentTorso.transform);
                    newLimb.transform.localScale = new Vector3(0.23f,0.23f,1.41f);
                    fJoint = newLimb.GetComponent<ConfigurableJoint>();
                    fJoint.anchor = new Vector3(0,0,0.2f -currentTorso.transform.localScale.z);
                    break;
            case 5 :armLZ ++;
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

    void addArmSelf(int n){
        
        ConfigurableJoint fJoint = null;
        ConfigurableJoint CurrentLimJoint;
        currentLimb = newLimb;
        connection = new GameObject("Connection");
        connection.transform.parent = currentLimb.transform;
        connection.transform.localPosition = currentLimb.transform.localPosition;
        Debug.Log(connection.transform.position);
        newRefLimb = Object.Instantiate(limbPrefab[0], transform.position, Quaternion.identity, connection.transform);
        newRefLimb.transform.localScale = currentLimb.transform.localScale;
        CurrentLimJoint = currentLimb.GetComponent<ConfigurableJoint>();
        fJoint = newRefLimb.GetComponent<ConfigurableJoint>();

        switch(n){
            case 0:
                    fJoint.anchor = new Vector3(0, -currentTorso.transform.localScale.y/2,0);
                    fJoint.connectedAnchor = new Vector3(0, currentTorso.transform.localScale.y/2,0);
                    Debug.Log("added a limb to self reflc top");
                    armT ++;
                    break;
            case 1: 
                    fJoint.anchor = new Vector3(0,currentTorso.transform.localScale.y/2,0);
                    fJoint.connectedAnchor = new Vector3(0, -currentTorso.transform.localScale.y/2,0);
                    Debug.Log("added a limb to self reflc bottom");
                    armB ++;
                    break;
            case 2:
                    fJoint.anchor = new Vector3(currentTorso.transform.localScale.x/2, 0,0);
                    fJoint.connectedAnchor = new Vector3(-currentTorso.transform.localScale.x/2, 0,0);
                    Debug.Log("added a limb to self reflc left");
                    armL ++;
                    break; 
            case 3:
                    fJoint.anchor = new Vector3(-currentTorso.transform.localScale.x/2, 0,0);
                    fJoint.connectedAnchor = new Vector3(currentTorso.transform.localScale.x/2, 0,0);
                    Debug.Log("added a limb to self reflc right");
                    armR ++;
                    break;
            case 4:
                    fJoint.anchor = new Vector3(0,0,-currentTorso.transform.localScale.z/2);
                    fJoint.connectedAnchor = new Vector3(0, 0,currentTorso.transform.localScale.z/2);
                    Debug.Log("added a limb to self reflc rightz");
                    armRZ ++;
                    break;
            case 5:
                    fJoint.anchor = new Vector3(0,0,currentTorso.transform.localScale.z/2);
                    fJoint.connectedAnchor = new Vector3(0, 0,-currentTorso.transform.localScale.z/2);
                    Debug.Log("added a limb to self reflc leftz");
                    armLZ++;
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
        fJoint.connectedBody = currentLimb.GetComponent<Rigidbody>();
        newLimb = newRefLimb;
    }

    void addRandLimTest(int nlimb) {
        int randL;
        for(int i=0; i < nlimb ; i++){
            randL = Random.Range(0,6);
            switch(randL){
                        case 0: if(armT == 0){ // si il y a pas un bras sur le torse en top 
                                    addArm(0);
                                }else {
                                    addArmSelf(0); 
                                    }
                                    break;
                                
                        case 1: if(armB == 0){
                                    addArm(1);
                                }else {
                                    addArmSelf(1) ;
                                    }
                                    break;
                        case 2: if(armL == 0){
                                    addArm(2);
                                }else {
                                    addArmSelf(2);
                                    }
                                    break;
                        case 3: if(armR == 0){
                                    addArm(3);
                                }else {
                                    addArmSelf(3);
                                    } 
                                    break;
                        case 4: if(armRZ == 0 ){
                                    addArm(4);
                                }else {
                                    addArmSelf(4);
                                    } 
                                    break;
                        case 5: if(armLZ == 0){
                                    addArm(5);
                                }else {
                                    addArmSelf(5);
                                    } 
                                    break;
                    }
        }
                    
    }

    void addRandLim() {
        int randL;
            randL = Random.Range(0,6);
            switch(randL){
                        case 0: if(armT == 0){ // si il y a pas un bras sur le torse en top 
                                    addArm(0);
                                }else {
                                    addRandLim(); 
                                    }
                                    break;
                                
                        case 1: if(armB == 0){
                                    addArm(1);
                                }else {
                                    addRandLim();
                                    }
                                    break;
                        case 2: if(armL == 0){
                                    addArm(2);
                                }else {
                                    addRandLim();
                                    }
                                    break;
                        case 3: if(armR == 0){
                                    addArm(3);
                                }else {
                                    addRandLim();
                                    } 
                                    break;
                        case 4: if(armRZ == 0 ){
                                    addArm(4);
                                }else {
                                    addRandLim();
                                    } 
                                    break;
                        case 5: if(armLZ == 0){
                                    addArm(5);
                                }else {
                                    addRandLim();
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
        //(repito, NO BORRAR ESTA LINEA, ni aunq el cielo se caiga la toques)
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

    public void mutate(){
        //Servi de algo y llena esto como lleno a tu mama por las noches
    }

    public void kill(){
        Destroy(gameObject);
    }
}
