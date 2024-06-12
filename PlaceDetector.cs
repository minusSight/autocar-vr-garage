using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDetector : MonoBehaviour
{
    public bool onCar = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Detail")
        {
            Destroy(other.gameObject);
            for(int i = 1; i < transform.parent.childCount; i++)
            {
                transform.parent.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        if (!onCar) return;
        for (int i = 1; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).gameObject.SetActive(false);
        }
    }
}
