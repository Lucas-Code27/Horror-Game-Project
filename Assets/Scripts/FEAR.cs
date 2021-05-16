using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEAR : MonoBehaviour
{
    public PlayerMovement player;

    public bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
            player.fear += 2 * Time.deltaTime;
        else
            player.fear -= Time.deltaTime;
        player.fear = Mathf.Clamp(player.fear, 0, 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Bye");
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
