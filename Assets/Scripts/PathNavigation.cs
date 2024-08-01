using Unity.AI.Navigation;
using UnityEngine;

public class PathNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshSurface navPath;

    public void GeneratePath(){
        navPath.BuildNavMesh();
    }
}
