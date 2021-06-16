using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPositionOption : MonoBehaviour
{
    public enum POINT_TYPE
    {
        Forwards,
        Up
    }
    
    [SerializeField] private POINT_TYPE pointingType = POINT_TYPE.Forwards;
    public POINT_TYPE PointingType => pointingType;
    
    [SerializeField] private float gunUpXRotation = 65f;
    [SerializeField] private Vector3 gunUpPos = new Vector3(0, -0.08f, 0.06f);

    
    // Start is called before the first frame update
    void Start()
    {
        if (pointingType == POINT_TYPE.Up)
        {
            var trans = this.gameObject.GetComponent<Transform>();
            var rotation = trans.rotation.eulerAngles;
            rotation.x = gunUpXRotation;
            trans.rotation = Quaternion.Euler(rotation);
            
            trans.position = gunUpPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
