using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshPro blackBoardText;

    private Detail workDetail;
    private int workType = -1;

    public Transform detailSpawner;

    void Start()
    {
        RandomizeWork();
    }

    void RandomizeWork()
    {
        workDetail = DetailManager.instance.details[1];
        workType = Random.Range(1, 2);

        switch(workType)
        {
            case 0:
                {
                    GameObject obj = Instantiate(workDetail.detail, detailSpawner);
                    obj.GetComponent<Rigidbody>().isKinematic = false;

                    //blackBoardText.text = $"�������� ������ {workDetail.name} �� �����!";
                    break;
                }
            case 1:
                {
                    GameObject obj = Instantiate(workDetail.detail, detailSpawner);
                    obj.GetComponentInChildren<PlaceDetector>().onCar = false;
                    obj.GetComponent<Rigidbody>().isKinematic = false;

                    //workDetail.detail.SetActive(false);
                    for (int i = 1; i < obj.transform.childCount; i++)
                    {
                        obj.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    blackBoardText.text = $"���������� ������ {workDetail.name}!\n������ �������� ��������, ��������� �����!\n������������� ����� ���������� ���������";
                    break;
                }
            case 2:
                {
                    //blackBoardText.text = $"��������� ������ {workDetail.name}!";
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
