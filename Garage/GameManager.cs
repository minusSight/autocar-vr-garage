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
        workDetail = Random.Range(0, DetailManager.instance.details.Length);
        workType = Random.Range(0, 3);

        switch(workType)
        {
            case 0:
                {
                    GameObject obj = Instantiate(workDetail.detail, detailSpawner);
                    obj.GetComponent<Rigidbody>().isKinematic = false;

                    blackBoardText.text = $"Çàìåíèòå äåòàëü {workDetail.name} íà íîâóþ!";
                    break;
                }
            case 1:
                {
                    GameObject obj = Instantiate(workDetail.detail, detailSpawner);
                    obj.GetComponentInChildren<PlaceDetector>().onCar = false;
                    obj.GetComponent<Rigidbody>().isKinematic = false;

                    workDetail.detail.SetActive(false);
                    for (int i = 1; i < obj.transform.childCount; i++)
                    {
                        obj.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    blackBoardText.text = $"Óñòàíîâèòå äåòàëü {workDetail.name}!\nÑòó÷èò ïåðåäíÿÿ ïîäâåñêà, ïðîòÿíèòå áîëòû!\nÓñòàíîâëåííóþ äâåðü íåîáõîäèìî ïîêðàñèòü";
                    break;
                }
            case 2:
                {
                    blackBoardText.text = $"Ïîêðàñüòå äåòàëü {workDetail.name}!";
                    break;
                }
        }
    }
}
