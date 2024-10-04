using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public enum CollectibleType { RelicOne, RelicTwo, RelicThree, health }
    public CollectibleType collectibleType;

    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (collectibleType == CollectibleType.RelicOne)
            {
                col.GetComponent<PlayerController>().HasRelicOne();
            }
            if (collectibleType == CollectibleType.RelicTwo)
            {
                col.GetComponent<PlayerController>().HasRelicTwo();
            }
            if (collectibleType == CollectibleType.RelicThree)
            {
                col.GetComponent<PlayerController>().HasRelicThree();
            }
        }
    }
}
