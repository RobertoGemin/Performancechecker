using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveImageToPhone : MonoBehaviour
{

    [HideInInspector]
    public getInfoMesh switchMeshScript;

    // Start is called before the first frame update
    void Start()
    {
        switchMeshScript = this.transform.GetComponent<getInfoMesh>();


    }


    void takesVideo() {

    }
    
    // Update is called once per frame
   public void takescreenshot()
    {


                // Take a screenshot and save it to Gallery/Photos
                StartCoroutine(TakeScreenshotAndSave());
          
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
     

        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", switchMeshScript.showModelChild.name.ToString()+ " My img {0}.png"));
        Destroy(ss);
    }
}
