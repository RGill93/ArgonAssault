using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-Throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
     
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }        
    }

    // Called by string reference
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    /*
     * Processes the spaceship movement and making sure it doesn't go of the screen
     */
    private void ProcessTranslation()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffSet = xThrow * controlSpeed * Time.deltaTime;
        float yOffSet = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    /*
     * processes the spaceships rotation(pitch, yaw, roll)
     */
    private void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    /*
     * Three below functions handle the weapon fire
     * from an array of guns
     */ 
    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);            
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach(GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }        
    }    
}
