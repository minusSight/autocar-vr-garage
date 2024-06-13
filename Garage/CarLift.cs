using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLift : MonoBehaviour
{
    public GameObject lift;
    public float speed;
    public float moveSpeed = 1f;
    public bool isUp;
    public bool isEnabled;
    public void Up()
    {
        isEnabled = true;
        isUp = true;
    }
    public void Down()
    {
        isEnabled = false;
        isUp = false;
    }

    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(moveSpeed);
        isEnabled = false;
    }

    private void Update()
    {
        if (!isEnabled) return;
        if(isUp)
        {
            Vector3 pos = lift.transform.position;
            pos.y += speed * Time.deltaTime;
            lift.transform.position = pos;
        }
        else
        {
            Vector3 pos = lift.transform.position;
            pos.y -= speed * Time.deltaTime;
            lift.transform.position = pos;
        }
    }
}
