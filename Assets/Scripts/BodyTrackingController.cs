using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrackingController : MonoBehaviour
{

    public GameObject HeadObj;

    private void Awake()
    {
        if (HeadObj == null)
            throw new System.Exception("A HeadObj must be defined in PaulSceneController");
    }

    private void OnEnable()
    {
        EventManager.OnObjectNewPosition += EventManager_OnObjectNewPosition;
    }

    private void OnDisable()
    {
        EventManager.OnObjectNewPosition -= EventManager_OnObjectNewPosition;
    }

    private void EventManager_OnObjectNewPosition(string objTypeStr, Transform objectTransform)
    {
        TrackObject(objTypeStr, objectTransform);
    }

    private void TrackObject(string objTypeStr, Transform objectTransform)
    {
        string objTrackStr = "type: " + objTypeStr + ", trans: " + objectTransform;

        if (objTypeStr == "head")
        {
            HeadObj.transform.position = objectTransform.position;
            HeadObj.transform.rotation = objectTransform.rotation;

            //RightHandTxt.text = "headPos: " + objectTransform.position;
        }
    }
}
