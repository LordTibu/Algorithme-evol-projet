using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    public GameObject Creature;
    GameObject creature;
    public GameObject creaturePrefab;

    public int NbCreatures = 5;

    public float posXSpread = 0, posYSpread = 1, posZSpread = 1;

    public int TypeSpread = 1;

    void Start()
    {
        for(int i=0 ; i < NbCreatures; i++){
            mierdas();
        }
    }

    void SpreadCreatures(float sep){
        //X spread
        /*if(TypeSpread == 1){
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
        }*/
    }

    void mierdas()
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
        if(Input.GetKey("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKey("p")) Start();
    }
}
