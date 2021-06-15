using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    //[SerializeField] private GameObject handGameObject;
    
    private ActionBasedController _actionBasedController;
    private Animator _handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _actionBasedController = GetComponentInParent<ActionBasedController>();
        _handAnimator = GetComponent<Animator>();
    }

    void UpdateHandAnimation()
    {
        if (_actionBasedController.activateAction.action.enabled)
        {
           var triggerValue =  _actionBasedController.activateAction.action.ReadValue<float>();
           _handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
        
        if (_actionBasedController.selectAction.action.enabled)
        {
            var gripValue =  _actionBasedController.selectAction.action.ReadValue<float>();
            _handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimation();
    }
}
