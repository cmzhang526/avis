using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    float lifetime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 5) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Protester"))
        {
            collision.gameObject.GetComponent<Protester>().Run();
            Destroy(this.gameObject);
        }
    }
}
