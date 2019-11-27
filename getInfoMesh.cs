using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class getInfoMesh : MonoBehaviour {
    public Text meshname;
    public Text subModelcount;
    public Text verticesCount;
    public Text imageCount;
    public Text materialCount;
    public Text materialUniqueCount;
    public GameObject showModel;
    [HideInInspector]
    public GameObject showModelChild;
    public int select;

    // public Text meshMaterial;
    public bool showMaterial;
    public bool showText;

    Scene scene;

    void Start()
    {
       // showModel = GameObject.Find("ShowObject");
        showModelChild = showModel.transform.GetChild(0).gameObject;


        StartCoroutine(playGame());
        showTextEnable();
        enableText();
    }


    IEnumerator playGame()
    {
        yield return new WaitForSeconds(1);

        ActiveMesh();
        showTextEnable();

    }


    public void enableText()
    {
        showText = !showText;
        if (showText)
        {
            meshname.enabled = true;
            subModelcount.enabled = true;
            verticesCount.enabled = true;
            imageCount.enabled = true;
            materialCount.enabled = true;
            materialUniqueCount.enabled = true;

            showTextEnable();
        }
        else
        {
            meshname.enabled = false;
            subModelcount.enabled = false;
            verticesCount.enabled = false;
            imageCount.enabled = false;
            materialCount.enabled = false;
            materialUniqueCount.enabled = false;


        }

    }


    public void showTextEnable()
    {

        meshname.text = "Naam 3D-model: " + showModelChild.name.ToString();
        // first sub model is the parent :)

        subModelcount.text = "Aantal (sub) 3D-modelen: " + showModelChild.GetComponent<childCount>().childRender.Length.ToString("#,#").Replace(',', '.');

        verticesCount.text = "Aantal vertex: " + showModelChild.GetComponent<childCount>().verticesCount;
        imageCount.text = "Aantal afbeeldingen: " + showModelChild.GetComponent<childCount>().textureCount;

        materialCount.text = "Aantal materialen: " + showModelChild.GetComponent<childCount>().materialcount;
        materialUniqueCount.text = "Aantal unieke materialen: " + showModelChild.GetComponent<childCount>().materialUniqueCount;


    }

    void Update()
    {
        ActiveMesh();
    }

    void ActiveMesh()
    {
        if (showModel.GetComponent<MeshRenderer>().enabled)
        {
            showModelChild.SetActive(true);

        }
    }
}
