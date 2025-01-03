using UnityEngine;

public class RoadLayerAssigner : MonoBehaviour
{
    void Start()
    {
        AssignRoadLayerRecursively(transform);
    }

    private void AssignRoadLayerRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Comprobar si el nombre del objeto coincide con el patrón deseado
            if (child.name.StartsWith("sptp_road_segment_"))
            {
                child.gameObject.layer = LayerMask.NameToLayer("Road");
            }
            AssignRoadLayerRecursively(child); // Recursivamente asignar capa
        }
    }
}
