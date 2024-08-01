using UnityEngine;
using TMPro;

public class BuildingSelection : MonoBehaviour
{
    [SerializeField] private BuildingList buildingList;
    [SerializeField] private GameObject buildingInfoPanel;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text buildingType;
    [SerializeField] private TMP_Text populationLabel;
    [SerializeField] private TMP_Text population;
    [SerializeField] private TMP_Text upkeepingLabel;
    [SerializeField] private TMP_Text upkeeping;
    private GameObject building;
    private BuildingInfo buildingInfo;

    void Start(){
        buildingInfoPanel.SetActive(false);
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000)){
                if(hit.collider.gameObject.CompareTag("Building")){
                    building = hit.collider.gameObject;
                    ShowBuildingInfo();
                }
            }
        }
    }

    void ShowBuildingInfo(){
        populationLabel.gameObject.SetActive(false);
        population.gameObject.SetActive(false);
        upkeepingLabel.gameObject.SetActive(false);
        upkeeping.gameObject.SetActive(false);

        buildingInfo = building.GetComponent<BuildingInfo>();

        title.text = buildingInfo.name;
        buildingType.text = buildingInfo.buildingType.ToString();
        
        if(buildingType.text == "Factory"){
            populationLabel.text = "Work Place";
            populationLabel.gameObject.SetActive(true);

            population.text = buildingInfo.currentWorker.ToString() + "/" + buildingInfo.workPlace.ToString();
            population.gameObject.SetActive(true);

            upkeepingLabel.text = "Wage";
            upkeepingLabel.gameObject.SetActive(true);

            upkeeping.text = "$ " + buildingInfo.wage.ToString();
            upkeeping.gameObject.SetActive(true);
        }
        else if(buildingType.text == "House"){
            populationLabel.text = "Resident";
            populationLabel.gameObject.SetActive(true);

            population.text = buildingInfo.resident.ToString();
            population.gameObject.SetActive(true);
        }
        else if(buildingType.text == "Shop"){
            populationLabel.text = "Work Place";
            populationLabel.gameObject.SetActive(true);

            population.text = buildingInfo.currentWorker.ToString() + "/" + buildingInfo.workPlace.ToString();
            population.gameObject.SetActive(true);

            upkeepingLabel.text = "Wage";
            upkeepingLabel.gameObject.SetActive(true);

            upkeeping.text = "$ " + buildingInfo.wage.ToString();
            upkeeping.gameObject.SetActive(true);
        }
        
        buildingInfoPanel.SetActive(true);
    }

    public void HideBuildingInfo(){
        buildingInfoPanel.SetActive(false);
    }

    public void DemolishBuilding(){
        buildingList.RemoveBuilding(building);
        Destroy(building);
        HideBuildingInfo();
    }
}
