using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSensor : MonoBehaviour
{
    private GameManager gameManager;

    public enum RotationRange
    {
        M1,
        M2,
        M3
    }

    [SerializeField]
    private RotationRange allowedRotation = RotationRange.M1;

    private void Awake()
    {
        gameManager = GameObject.Find("XRStudioSystemManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Avatar"))
        {
            if (IsRotationWithinRange(other.gameObject.transform))
            {
                gameManager.isCharacterInExactPlace = true;
            }
            else
            {
                gameManager.isCharacterInExactPlace = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Avatar"))
        {
            gameManager.isCharacterInExactPlace = false;
        }
    }

    private bool IsRotationWithinRange(Transform avatarTransform)
    {
        float rotationY = avatarTransform.localRotation.y;

        switch (allowedRotation)
        {
            case RotationRange.M1:
                return (rotationY >= -90f && rotationY <= 0f); 
            case RotationRange.M2:
                return (rotationY >= -15f && rotationY <= 15f); 
            case RotationRange.M3:
                return (rotationY >= 0f && rotationY <= 45f); 
        }

        return false; 
    }
}
