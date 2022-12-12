using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureManager : MonoBehaviour
{
    public GameObject Eve = null;// The creature used to create new creatures
    public int NUMBER_OF_CREATURES = 48;
    //Number of individuals per generation
    public float PARENT_THRESHOLD = 0.5f;
    //Percentage of the best individuals who can become parents
    //Ex. 0.5f => The better half of the current generation can become parents
    private List<CreatureController> creatures;
    //List holding all of the individuals in a given generation

    //public static float MUTATION_RATE = 0.02f;
    public static int SPACE_BETWEEN = 18;
    //Physical space between creatures in the grid when creating a generation

    public static float TIME_LIMIT = 300;
    //Time before creating a new generation (in seconds)
    private float timeLeft = TIME_LIMIT;
    //Timer used for the countdown
    public int generation = 0;
    //Counts the number of generations
    void Start()
    {
        if(PARENT_THRESHOLD > 1) PARENT_THRESHOLD = 0.5f;
        if(!Eve){
            Debug.Log("Not initialised a prefab");
            this.enabled = false; //Disable script
        }
        creatures = new List<CreatureController>();
        initCreatures();
    }

    void initCreatures(){
        Vector3 position = Eve.transform.position;
        int sqr = (int)Mathf.Sqrt((float) NUMBER_OF_CREATURES);
        int x = 0, z = 0;
        for(int i = 0; i < NUMBER_OF_CREATURES; i++){
            //Creating the first generation
            position[0] = x * SPACE_BETWEEN;
            position[2] = z * SPACE_BETWEEN;
            GameObject currentIndividual = Instantiate(Eve, position, Quaternion.identity);
            CreatureController copy = currentIndividual.GetComponent<CreatureController>();
            //Naming the objects
            copy.gameObject.name = "Individual: " + i;
            creatures.Add(copy);
            copy.init();
            //updating the positions so they are organized in a (mostly) square grid
            if(x < sqr) {x += 1;}
            else{x = 0; z += 1;}
        }
    }

    public void makeNewGeneration(){
        generation += 1;
        List<CreatureController>newCreatures = new List<CreatureController>();
        GameObject randParent1, randParent2;
        GameObject newChild;
        CreatureController newCont;
        int rand1, rand2;
        Vector3 position = Vector3.zero;
        calculateFitness();
        
        //On preserve le meilleur 10% des creatures
        int ten = (int)(0.1 * NUMBER_OF_CREATURES);
        int ninety = (int)(0.9 * NUMBER_OF_CREATURES);
        int sqr = (int)Mathf.Sqrt((float) NUMBER_OF_CREATURES);
        int x = 0, z = 0;
        if(ten + ninety < NUMBER_OF_CREATURES) ten += 1;
        for(int i = 0; i < ten; i++){
            position[0] = x * SPACE_BETWEEN;
            position[2] = z * SPACE_BETWEEN;
            newChild = Instantiate(creatures[i].gameObject, position, Quaternion.identity);
            newChild.name = creatures[i].name;
            newCreatures.Add(newChild.GetComponent<CreatureController>());
            if(x < sqr) {x += 1;}
            else{x = 0; z += 1;}
        }

        for(int j = ten; j < NUMBER_OF_CREATURES; j++){
            position[0] = x * SPACE_BETWEEN;
            position[2] = z * SPACE_BETWEEN;
            //On ajoute le reste des new creatures dans le tab.
            //1. Select two random parents between the PARENT_THRESHOLD% best individuals
            rand1 = (int) Random.Range(0, PARENT_THRESHOLD * NUMBER_OF_CREATURES);
            rand2 = (int) Random.Range(0, PARENT_THRESHOLD * NUMBER_OF_CREATURES);
            while(rand1 == rand2) rand2 = (int) Random.Range(0, PARENT_THRESHOLD * NUMBER_OF_CREATURES);
            randParent1 = creatures[rand1].gameObject;
            randParent2 = creatures[rand2].gameObject;
            if(randParent1 && randParent2){
                newChild = Instantiate(Eve, position, Quaternion.identity);
                //2. Crossover their genes
                newCont = newChild.GetComponent<CreatureController>();
                newCont.gameObject.name = "gen: " + generation + " Individual: " + j;
                newCont.crossover(randParent1, randParent2);
                //3. Mutate those genes a little bit
                //newCont.mutate();
                //4. Add new child individual to new tab
                newCreatures.Add(newCont);
            }
            if(x < sqr) {x += 1;}
            else{x = 0; z += 1;}
        }
        //Kill last generation
        killCurrentGen(0);
        creatures = new List<CreatureController>(newCreatures);
    }

    public void calculateFitness(){
        //Calculate fitness of each individual and sorting the list in order of most to less fit
        //Ex. Creatures[0] should have the higger fitness at the end
        for(int i = 0; i < NUMBER_OF_CREATURES; i++){
            creatures[i].calculateFitness();
        }
        for(int i = 1; i < NUMBER_OF_CREATURES; i++)
        {
            for(int j = i; j > 0; j--)
            {
                if(creatures[j].fitnessScore > creatures[j-1].fitnessScore)
                {
                    CreatureController tmp = creatures[j];
                    creatures[j] = creatures[j - 1];
                    creatures[j - 1] = tmp;
                }
            }
        }
    }

    public void killCurrentGen(int startPoint){
        for(int i = startPoint; i < NUMBER_OF_CREATURES; i++){
            creatures[i].kill();
        }
        creatures.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //Restart the whole experiment (Solo usar para tests)
        if(Input.GetKey("r")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKey("f")) calculateFitness();
        if(Input.GetKey("k")) killCurrentGen(0);

        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0){
            makeNewGeneration();
            Debug.Log(TIME_LIMIT + " seconds have passed");
            timeLeft = TIME_LIMIT;
        }
    }
}
