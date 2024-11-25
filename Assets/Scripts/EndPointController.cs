using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour
{
    [SerializeField] GameObject scoreController;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
           scoreController.GetComponent<ScoreController>().ReachEndPoint(gameObject);
        }
    }
}
