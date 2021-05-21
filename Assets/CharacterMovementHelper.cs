using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterMovementHelper : MonoBehaviour
{
    private XRRig _xRRig;
    private CharacterController _characterController;
    private CharacterControllerDriver _driver;
    
    // Start is called before the first frame update
    void Start()
    {
        _xRRig = GetComponent<XRRig>();
        _characterController = GetComponent<CharacterController>();
        _driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
    
    private void UpdateCharacterController()
    {
        if (_xRRig == null || _characterController == null)
            return;

        var height = Mathf.Clamp(_xRRig.cameraInRigSpaceHeight, _driver.minHeight, _driver.maxHeight);

        Vector3 center = _xRRig.cameraInRigSpacePos;
        center.y = height / 2f + _characterController.skinWidth;

        _characterController.height = height;
        _characterController.center = center;
    }
}
