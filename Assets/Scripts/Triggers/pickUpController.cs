using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    [SerializeField] GameObject trigger_pick_up;
    [SerializeField] GameObject paticle_system;
    [SerializeField] Text text;
    const string tagPlayer = "Player";
    int count_toss;

    void Start()
    {
        gameObject.SetActive(false);
        count_toss = 0;
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == tagPlayer && ItemsController.equip)
        {
            ItemsController.Toss(other.gameObject);
            count_toss ++;

        }
        if (count_toss == 3)
        {
            text.text = "Задача выполнена";
            paticle_system.SetActive(false);
            trigger_pick_up.SetActive(false);
        }
    }
}
