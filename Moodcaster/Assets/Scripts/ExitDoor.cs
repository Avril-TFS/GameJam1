using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (playerController.CheckHasRelicOne() && playerController.CheckHasRelicTwo() && playerController.CheckHasRelicThree())
            {

                Destroy(gameObject);
            }
        }
    }
}
