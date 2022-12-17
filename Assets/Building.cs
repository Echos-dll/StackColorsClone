using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();
    
    private int needAmount;
    private Material needMaterial;
    void Start()
    {
        needAmount = Random.Range(2, 5);
        needMaterial = _materials[Random.Range(0, _materials.Count - 1)];
        GetComponent<Renderer>().material = needMaterial;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var co = collision.gameObject;
        if (co.CompareTag("Player") && co.GetComponent<CollectableStack>().CurrentMaterial == needMaterial)
        {
            for (int i = 0; i < needAmount; i++)
            {
                co.GetComponent<CollectableStack>().UseItem();
            }
            Destroy(gameObject);
        }

    }
}
