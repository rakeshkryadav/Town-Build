using System.Collections.Generic;
using UnityEngine;

public class BuildingList : MonoBehaviour
{
    public List<GameObject> buildingList;

    public void AddBuilding(GameObject building){
        buildingList.Add(building);
    }

    public void RemoveBuilding(GameObject building){
        buildingList.Remove(building);
    }
}
