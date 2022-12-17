using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Door : MonoBehaviour
{
    [SerializeField] private List<Material> materials;

    private Material randomMaterial;
    private void OnCollisionEnter(Collision collision)
    {
        var co = collision.gameObject;
        var itemList = co.GetComponent<CollectableStack>().StackedItems;

        foreach (var item in itemList)
        {
            item.GetComponent<Renderer>().material = randomMaterial;
            co.GetComponent<CollectableStack>().CurrentMaterial = randomMaterial;
        }

        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomMaterial = materials[Random.Range(0, materials.Count-1)];
        GetComponent<Renderer>().material = randomMaterial;
    }
}
