using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject Torus;

    public GameObject Particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnDestroy()

    {

        if (Torus.gameObject == null)
        { 

            Instantiate(Particle);
            {
            }
        }
    }
}
