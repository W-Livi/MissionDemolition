using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    // a static field accessible by code anywhere
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other) {
        // When the trigger is hit by something
        // Check to see if it's a Projectile
        if (other.gameObject.tag == "Projectile") {
            // If so, set goalMet to true
            Goal.goalMet = true;
            // Also set the alpha of the color to higher opacity
            //Color c = renderer.material.color;
            Renderer r = GetComponent<Renderer>();
            Color c = r.material.color;
            c.a = 1;
            r.material.color = c;
        }
    }


}
