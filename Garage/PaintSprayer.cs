using UnityEngine;
using Valve.VR;

public class PaintSprayer : MonoBehaviour
{
    public SteamVR_Action_Boolean sprayAction; // Действие для активации краскопульта
    public SteamVR_Input_Sources handType; // Рука, с которой будет использоваться краскопульт
    public ParticleSystem paintParticles; // Система частиц для распыления краски
    public Color paintColor = Color.red; // Цвет краски
    public Renderer objectToPaint; // Объект для покраски
    public float paintProgress; // Прогресс покраски
    private float paintRequired = 1.0f; // Необходимое количество краски для изменения цвета

    void Update()
    {
        // Проверяем, нажата ли кнопка краскопульта
        if (sprayAction.GetStateDown(handType))
        {
            // Активируем систему частиц
            paintParticles.Play();
        }
        else if (sprayAction.GetStateUp(handType))
        {
            // Деактивируем систему частиц
            paintParticles.Stop();
        }

        // Проверяем, находится ли объект в зоне распыления краски
            if (objectToPaint != null && Vector3.Distance(transform.position, objectToPaint.transform.position) < 5.0f)
            {
                if (paintParticles.isPlaying)
                {
                    // Увеличиваем прогресс покраски
                    paintProgress += Time.deltaTime;

                    // Проверяем, достигнут ли необходимый прогресс
                    if (paintProgress >= paintRequired)
                    {
                        // Изменяем цвет объекта
                        for(int j = 0; j < objectToPaint.materials.Length; j++)
                        {
                            objectToPaint.materials[5].color = paintColor;
                        }                     
                    }
                }
            }
    }
}