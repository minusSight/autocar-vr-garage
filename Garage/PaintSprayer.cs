using UnityEngine;
using Valve.VR;

public class PaintSprayer : MonoBehaviour
{
    public SteamVR_Action_Boolean sprayAction; // �������� ��� ��������� ������������
    public SteamVR_Input_Sources handType; // ����, � ������� ����� �������������� �����������
    public ParticleSystem paintParticles; // ������� ������ ��� ���������� ������
    public Color paintColor = Color.red; // ���� ������
    public Renderer objectToPaint; // ������ ��� ��������
    public float paintProgress; // �������� ��������
    private float paintRequired = 1.0f; // ����������� ���������� ������ ��� ��������� �����

    void Update()
    {
        // ���������, ������ �� ������ ������������
        if (sprayAction.GetStateDown(handType))
        {
            // ���������� ������� ������
            paintParticles.Play();
        }
        else if (sprayAction.GetStateUp(handType))
        {
            // ������������ ������� ������
            paintParticles.Stop();
        }

        // ���������, ��������� �� ������ � ���� ���������� ������
            if (objectToPaint != null && Vector3.Distance(transform.position, objectToPaint.transform.position) < 5.0f)
            {
                if (paintParticles.isPlaying)
                {
                    // ����������� �������� ��������
                    paintProgress += Time.deltaTime;

                    // ���������, ��������� �� ����������� ��������
                    if (paintProgress >= paintRequired)
                    {
                        // �������� ���� �������
                        for(int j = 0; j < objectToPaint.materials.Length; j++)
                        {
                            objectToPaint.materials[5].color = paintColor;
                        }                     
                    }
                }
            }
    }
}