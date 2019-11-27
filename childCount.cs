using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class childCount : MonoBehaviour
{
    public Renderer[] childRender;
    public MeshFilter[] childMesh;
    public Transform[] childObjects;
    public string verticesCount;
    public string textureCount;
    public string materialcount;
    public string materialUniqueCount;
     public List<string> materialNames;
    public List<string> uniqueMaterialNames;



    // Start is called before the first frame update
    void Start(){
        childRender = gameObject.GetComponentsInChildren<Renderer>(); 
        childMesh = gameObject.GetComponentsInChildren<MeshFilter>();
        getMaterial();
        verticesCount = getVerticesCount();
   


    }
    public void setActive()
    {
      
        for (int i = 0; i < childRender.Length; i++)
        {
            if (childRender[i] != null)
            {
                childRender[i].enabled =true;
            
            }
        }
    }

   
  public void setNotActive()
    {
       
        for (int i = 0; i < childRender.Length; i++)
        {

           childRender[i].enabled =false;
          

        }
    }
    public string getVerticesCount()
    {

        int tempCount = 0;
        for (int i = 0; i < childMesh.Length; i++)
        {
        
            if (childMesh[i] != null)
            {

                tempCount = tempCount + childMesh[i].mesh.vertexCount;

            }
          

        }
       
        return tempCount.ToString("#,#").Replace(',', '.'); ;
    }

    public void getMaterial()
    {
        int tempCount = 0;
        for (int i = 0; i < childRender.Length; i++)
        {


            int intMaterials = childRender[i].materials.Length;

            for (int x = 0; x < intMaterials; x++)
            {
                materialNames.Add(childRender[i].materials[x].name);
                if (childRender[i].materials[x].mainTexture != null)
                {
                    tempCount++;
                }
            }
        }
     
        materialcount = materialNames.Count.ToString("#,#").Replace(',', '.');
        materialUniqueCount = materialNames.Distinct().ToList().Count.ToString("#,#").Replace(',', '.');
        if (tempCount == 0)
        {
            textureCount = 0.ToString();
        }
        else
        {
            textureCount = tempCount.ToString("#,#").Replace(',', '.');
        }

    }



}
