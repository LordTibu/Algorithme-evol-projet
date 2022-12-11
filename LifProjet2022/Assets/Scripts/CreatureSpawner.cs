using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    public GameObject Creature;

    public int NbCreatures = 5;

    public float posXSpread = 0, posYSpread = 3, posZSpread = 1;

    public int TypeSpread = 1;

    void Start()
    {
        
        for(int i=0 ; i < NbCreatures; i++){
            SpreadCreatures(i);
        }
    }

    void SpreadCreatures(float sep){
        //X spread
        Vector3 randPos;
        if(TypeSpread == 1){
            randPos = new Vector3 (sep*2- (float)NbCreatures/2 + posXSpread , posYSpread, posZSpread)+ transform.position;
            
        } else if (TypeSpread == 2){
            // Y Spread
            randPos = new Vector3 (posXSpread , sep*2 + posYSpread, posZSpread)+ transform.position;
            
        }else if (TypeSpread == 3) {
            //Z Spread
            randPos = new Vector3 (posXSpread , posYSpread, sep*2- (float)NbCreatures/2 + posZSpread)+ transform.position;
            
        }else if (TypeSpread == 4){
            // XZ Spread (Diagonale)
            randPos = new Vector3 (sep*2- (float)NbCreatures/2 + posXSpread , posYSpread, sep*2- (float)NbCreatures/2 + posZSpread)+ transform.position;
            
        }else {
            //Licuadora
             randPos = new Vector3(posXSpread,posYSpread,posZSpread) +  transform.position;
            
        }
        GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
    }

    void Update(){
        if(Input.GetKey("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKey("p")) Start();
    }

}
