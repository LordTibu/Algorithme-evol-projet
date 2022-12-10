using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    public GameObject Creature;

    public int NbCreatures = 5;

    public float posXSpread = 0, posYSpread = 1, posZSpread = 1;

    public int TypeSpread = 1;

    void Start()
    {
        for(int i=0 ; i < NbCreatures; i++){
            SpreadCreatures(i);
        }
    }

    void SpreadCreatures(float sep){
        //X spread
        if(TypeSpread == 1){
            Vector3 randPos = new Vector3 (sep*2- (float)NbCreatures/2 + posXSpread , posYSpread, posZSpread)+ transform.position;
            GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
        } else if (TypeSpread == 2){
            // Y Spread
            Vector3 randPos = new Vector3 (posXSpread , sep*2 + posYSpread, posZSpread)+ transform.position;
            GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
        }else if (TypeSpread == 3) {
            //Z Spread
            Vector3 randPos = new Vector3 (posXSpread , posYSpread, sep*2- (float)NbCreatures/2 + posZSpread)+ transform.position;
            GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
        }else if (TypeSpread == 4){
            // XZ Spread (Diagonale)
            Vector3 randPos = new Vector3 (sep*2- (float)NbCreatures/2 + posXSpread , posYSpread, sep*2- (float)NbCreatures/2 + posZSpread)+ transform.position;
            GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
        }else {
            //Licuadora
            Vector3 randPos = new Vector3(posXSpread,posYSpread,posZSpread) +  transform.position;
            GameObject Spawn = Instantiate(Creature,randPos, Quaternion.identity);
        }
    }

    void Update(){
        if(Input.GetKey("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKey("p")) Start();
    }

}
