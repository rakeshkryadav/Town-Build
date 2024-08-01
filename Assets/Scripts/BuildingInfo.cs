using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public BuildingType buildingType;
    public int cost;
    public int resident;
    public int workPlace;
    public int currentWorker;
    public int wage;

    public static string hitTag;

    void OnTriggerEnter(Collider collider){
        hitTag = collider.tag;
    }

    void OnTriggerExit(Collider collider){
        hitTag = null;
    }

    public enum BuildingType{
        Factory,
        House,
        Road,
        Shop
    };
}