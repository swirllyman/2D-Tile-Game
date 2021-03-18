using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    public GameObject openDoorObject;
    public GameObject closedDoorObject;
    public bool locked;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!locked)
        {
            ToggleDoor(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ToggleDoor(false);
    }

    void ToggleDoor(bool open)
    {
        openDoorObject.SetActive(open);
        closedDoorObject.SetActive(!open);

        //
    }
}
