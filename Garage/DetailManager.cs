using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Detail
{
    public string name;
    public GameObject detail;
}
public class DetailManager : MonoBehaviour
{
    public static DetailManager instance;
    public Detail[] details;

    private void Awake()
    {
        instance = this;
    }
}
