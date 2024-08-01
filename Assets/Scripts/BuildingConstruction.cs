using UnityEngine;
using TMPro;

public class BuildingConstruction : MonoBehaviour
{
    [SerializeField] private BuildingList buildingList;
    [SerializeField] private PathNavigation pathNavigation;
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject human;
    private GameObject human1, human2, human3, human4;
    private int[] buildingCount = {0, 0, 0, 0};
    private int index;
    private GameObject selectedBuilding;
    [SerializeField] private float gridSize = 1f;
    private Vector3 pos;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    [Header("User Interface")]
    [SerializeField] private TMP_Text money;
    [SerializeField] private TMP_Text population;
    [SerializeField] private GameObject messagePanel;

    void Start(){
        messagePanel.SetActive(false);
    }

    void Update(){
        if(BuildingInfo.hitTag == "Building"){
            messagePanel.SetActive(true);
        }
        else{
            messagePanel.SetActive(false);
        }

        if(selectedBuilding != null){
            selectedBuilding.transform.position = new Vector3(GridArea(pos.x), GridArea(pos.y), GridArea(pos.z));

            if(Input.GetMouseButtonDown(0) && !messagePanel.activeSelf){
                PlaceBuilding();

                if(index != 0){
                    buildingList.AddBuilding(selectedBuilding);
                }

                if(index == 1){
                    human1 = Instantiate(human, selectedBuilding.transform.position, selectedBuilding.transform.rotation, selectedBuilding.transform);
                    human2 = Instantiate(human, selectedBuilding.transform.position, selectedBuilding.transform.rotation, selectedBuilding.transform);
                    human3 = Instantiate(human, selectedBuilding.transform.position, selectedBuilding.transform.rotation, selectedBuilding.transform);
                    human4 = Instantiate(human, selectedBuilding.transform.position, selectedBuilding.transform.rotation, selectedBuilding.transform);
                }
                selectedBuilding = null;
            }
            if(Input.GetKey(KeyCode.Escape)){
                Destroy(selectedBuilding);
                selectedBuilding = null;
            }
            if(Input.GetKeyDown(KeyCode.R)){
                BuildingRotation();
            }
        }
    }

    void PlaceBuilding(){
        int constructionCost = selectedBuilding.GetComponent<BuildingInfo>().cost;
        int newPopulation = selectedBuilding.GetComponent<BuildingInfo>().resident;

        int totalMoney = Money(money.text);
        int totalPopulation = Population(population.text);

        if(totalMoney > constructionCost){
            totalMoney -= constructionCost;
            totalPopulation += newPopulation;

            buildingCount[index]++;
            selectedBuilding.name = selectedBuilding.name.Replace("(Clone)", " " + buildingCount[index]);
        }

        money.text = "$ " + totalMoney.ToString("n0");
        population.text = totalPopulation.ToString("n0");
        
        pathNavigation.GeneratePath();
    }

    int Money(string money){
        money = money.Replace("$ ", "");
        money = money.Replace(",", "");
        return int.Parse(money);
    }

    int Population(string population){
        population = population.Replace(",", "");
        return int.Parse(population);
    }

    void FixedUpdate(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask)){
            pos = hit.point;
        }
    }

    public void SelectBuilding(int index){
        this.index = index;
        selectedBuilding = Instantiate(buildings[index], pos, transform.rotation);
    }

    float GridArea(float pos){
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff >= (gridSize / 2)){
            pos += gridSize;
        }
        return pos;
    }

    public void BuildingRotation(){
        selectedBuilding.transform.Rotate(Vector3.up, 90);
    }
}
