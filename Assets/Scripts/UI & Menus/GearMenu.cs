using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMenu : MonoBehaviour
{
    public Material Material003;
    public Material Material004;
    public Material Material005;
    public Material Material006;
    public Material Material007;
    public Material Material008;
    public Material Material009;
    public Material Material10;
    public Material Material11;
    public Material Material12;
    public Material Material20;
    public Material[] mats;
    public Material blueMaterial;
    public Material orangeMaterial;
    public Material greenMaterial;
    public Material blackMaterial;
    public Material yellowMaterial;

    public GameObject bikeObject;

    // Start is called before the first frame update
    void Start()
    {
        mats = bikeObject.GetComponent<MeshRenderer>().materials;

        mats[0] = Material003;
        mats[1] = Material004;
        mats[2] = Material005;
        mats[3] = Material006;
        mats[4] = Material007;
        mats[5] = Material008;
        mats[6] = Material009;
        mats[7] = Material10;
        mats[8] = Material11;
        mats[9] = Material12;
        mats[10] = Material20;

        bikeObject.GetComponent<Renderer>().materials = mats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToRed()
    {
    
    }

    public void ChangeToYellow()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = yellowMaterial;    // alter mats to add new material
        }

        bikeObject.GetComponent<MeshRenderer>().materials = mats;    // apply new mats onto renderer
    }

    public void ChangeToBlack()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = blackMaterial;    // alter mats to add new material
        }

        bikeObject.GetComponent<MeshRenderer>().materials = mats;    // apply new mats onto renderer
    }

    public void ChangeToBlue()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = blueMaterial;    // alter mats to add new material
        }

        bikeObject.GetComponent<MeshRenderer>().materials = mats;    // apply new mats onto renderer
    }

    public void ChangeToGreen()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = greenMaterial;    // alter mats to add new material
        }

        bikeObject.GetComponent<MeshRenderer>().materials = mats;    // apply new mats onto renderer
    }

    public void ChangeToOrange()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = orangeMaterial;    // alter mats to add new material
        }

        bikeObject.GetComponent<MeshRenderer>().materials = mats;    // apply new mats onto renderer
    }
}
