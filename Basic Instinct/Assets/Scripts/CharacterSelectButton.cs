using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterSelectButton : MonoBehaviour
{
    public Transform centerStore;
    public Transform storeContainer;
    public void OnClickChar()
    {
        float dis = centerStore.position.x - transform.position.x;
        ScrollScript.newPose = new Vector3(storeContainer.position.x + dis, storeContainer.position.y, storeContainer.position.z);
        ScrollScript.SelectMove = true;
    }
}