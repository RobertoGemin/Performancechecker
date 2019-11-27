using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class showObjectsUpdate : MonoBehaviour
{
    public getInfoMesh addGameManager;
    public GameObject[] childObjects;
    public childCount[] childObjectsScript;

    int activeObject;
    void Awake(){
        activeObject = 0;
        childObjects = new GameObject[this.transform.childCount];
        childObjectsScript= new childCount[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++){
            childObjects[i] = this.gameObject.transform.GetChild(i).gameObject;
            if (this.gameObject.transform.GetChild(i).gameObject.GetComponent<childCount>() == null) {
                childCount add = this.gameObject.transform.GetChild(i).gameObject.AddComponent<childCount>() as childCount;
            }
            childObjectsScript[i] = this.gameObject.transform.GetChild(i).gameObject.GetComponent<childCount>();
        }   
    }
    void SetOffActive(){
        for (int i = 0; i < this.transform.childCount; i++){
            childObjectsScript[i].setNotActive();
        }

    }
    void sendData(){
        if (this.GetComponent<Renderer>().enabled){
            childObjectsScript[activeObject].setActive();
        }
        else{
            childObjectsScript[activeObject].setNotActive();
        }
    }

    // Update is called once per frame
    void Update(){
        SetOffActive();
        activeObject = addGameManager.select;
        sendData();
    }
}
