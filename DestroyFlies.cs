using UnityEngine;
using System.Collections;

public class DestroyFlies : MonoBehaviour
{ //in the project tab of Unity, make a new "C# Script" called "DestroyCollision"

    public string tagName = "fly"; //this will show up as an input box for the component, which can be given a tag of your choice.  assign the 

    void OnCollisionEnter(Collision myCol)
    { //run the following whenever a collision happens to the object attached with this script
        Debug.Log("Collision with " + myCol.gameObject);
        if (myCol.gameObject.tag == "fly")
        { //does the object collided with have the tag in question?
            Destroy(myCol.gameObject); //if so, destroy that object!
        }

    }
}
