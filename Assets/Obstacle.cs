using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        if (canMove)
        {
            var pos = transform.position;
            transform.position = new Vector3(-5, pos.y, pos.z);
            transform.DOMoveX(5, 3).SetLoops(-1, LoopType.Yoyo);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var co = collision.gameObject;
        if (co.CompareTag("Player"))
        {
            for (int i = 0; i < 5; i++)
            {
                collision.gameObject.GetComponent<CollectableStack>().DropItem();
                GetComponent<Collider>().enabled = false;
            }
        }
       
    }
}
