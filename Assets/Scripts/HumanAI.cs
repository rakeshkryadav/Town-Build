using UnityEngine;
using UnityEngine.AI;

public class HumanAI : MonoBehaviour
{
    [SerializeField] private GameTime gameTime;
    [SerializeField] private BuildingList buildings;
    [SerializeField] private NavMeshAgent human;
    [SerializeField] private GameObject homePlace;
    [SerializeField] private GameObject workPlace;
    [SerializeField] private GameObject shopPlace;
    [SerializeField] private string gender;
    
    void Start()
    {
        string[] genderList = {"Male", "Female"};
        gender = genderList[Random.Range(0, genderList.Length)];


        buildings = GameObject.Find("Building List").GetComponent<BuildingList>();
        gameTime = GameObject.Find("Time Manager").GetComponent<GameTime>();
        homePlace = buildings.buildingList[buildings.buildingList.Count - 1];

        if(gender == "Male"){
            SelectWorkPlace();
        }
        else{
            SelectShopPlace();
        }
    }

    void Update()
    {
        

        if(gender == "Male"){
            if(gameTime.currentTime >= 7 && gameTime.currentTime <= 17){
                human.SetDestination(workPlace.transform.position);
            }
            else{
                human.SetDestination(homePlace.transform.position);
            }
        }
        else{
            if(gameTime.currentTime >= 11 && gameTime.currentTime <= 17){
                human.SetDestination(shopPlace.transform.position);
            }
            else{
                human.SetDestination(homePlace.transform.position);
            }
        }
    }

    void SelectWorkPlace(){
        workPlace = buildings.buildingList[Random.Range(0, buildings.buildingList.Count)];

        BuildingInfo selectedtWorkPlace = workPlace.GetComponent<BuildingInfo>();

        if(selectedtWorkPlace.currentWorker < selectedtWorkPlace.workPlace){
            selectedtWorkPlace.currentWorker++;
        }
        else{
            SelectWorkPlace();
        }
    }

    void SelectShopPlace(){
        shopPlace = buildings.buildingList[Random.Range(0, buildings.buildingList.Count)];

        if(!shopPlace.name.Contains("Shop")){
            Debug.Log(shopPlace);
            SelectShopPlace();
        }
    }
}
