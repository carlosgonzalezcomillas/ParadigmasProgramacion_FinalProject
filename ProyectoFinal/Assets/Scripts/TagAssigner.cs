using UnityEngine;

public class TagAssigner : MonoBehaviour
{
    void Start()
    {
        AssignTagRecursively(transform, "Obstacle");
    }

    private void AssignTagRecursively(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.tag = tag;
            AssignTagRecursively(child, tag); // Recursively assign tag
        }
    }
}
