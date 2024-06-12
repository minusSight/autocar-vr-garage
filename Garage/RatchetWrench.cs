using UnityEngine;
using Valve.VR;

public class RatchetWrench : MonoBehaviour
{
    public SteamVR_Action_Vector2 ratchetAction;
    public AudioClip ratchetSound;
    private AudioSource audioSource;
    private GameObject targetBolt; // Текущий откручиваемый болт
    private float rotationThreshold = 30.0f;
    private float lastRotation;
    private float totalRotation = 0.0f;
    private float requiredRotation = 360.0f; // Необходимый угол для откручивания болта

    void Start()
    {
        InitializeAudio();
    }

    void Update()
    {
        if (targetBolt != null)
        {
            RotateRatchet();
        }
    }

    private void InitializeAudio()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = ratchetSound;
        lastRotation = transform.localEulerAngles.y;
    }

    private void RotateRatchet()
    {
        float rotationDelta = Mathf.DeltaAngle(lastRotation, transform.localEulerAngles.y);
        if (Mathf.Abs(rotationDelta) >= rotationThreshold)
        {
            if (IsRatchetActionActive())
            {
                PlayRatchetSound();
                UpdateRotation(rotationDelta);
                CheckBoltUnscrewed();
            }
            lastRotation = transform.localEulerAngles.y;
        }
    }

    private bool IsRatchetActionActive()
    {
        return ratchetAction.axis.x > 0.1f || ratchetAction.axis.x < -0.1f;
    }

    private void PlayRatchetSound()
    {
        audioSource.Play();
    }

    private void UpdateRotation(float rotationDelta)
    {
        totalRotation += Mathf.Abs(rotationDelta);
    }

    private void CheckBoltUnscrewed()
    {
        if (totalRotation >= requiredRotation)
        {
            RemoveBolt();
        }
    }

    private void RemoveBolt()
    {
        Destroy(targetBolt);
        targetBolt = null;
        totalRotation = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            targetBolt = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetBolt)
        {
            ResetUnscrewingProgress();
        }
    }

    private void ResetUnscrewingProgress()
    {
        targetBolt = null;
        totalRotation = 0.0f;
    }
}