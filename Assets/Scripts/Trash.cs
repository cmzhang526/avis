using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    int postersInTrash = 0;
    public GameObject victoryMenuUI;
    public GameObject powerslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(postersInTrash >= 2)
        {
            StartCoroutine(Victory());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poster")
        {
            if (!other.gameObject.GetComponent<Poster>().thrownAway && !other.gameObject.GetComponent<Poster>().pickedUp)
            {
                Debug.Log("Eating Posters");
                postersInTrash++;
                other.gameObject.GetComponent<Poster>().thrownAway = true;
            }
        }
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(3.0f);
        victoryMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        powerslider.SetActive(false);
    }
}
