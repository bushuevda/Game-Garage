using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openGarage : MonoBehaviour
{
    [SerializeField] GameObject triger_garage;
    [SerializeField] GameObject particle_system;
    [SerializeField] GameObject door;
    [SerializeField] GameObject particle_system_pickup;
    [SerializeField] GameObject trigger_pickup;
    [SerializeField] Text text;
    const string tagPlayer = "Player";

     void Start()
    {
        text.text = "Откройте гараж";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagPlayer)
        {
            text.text = "Cоберите предметы";

            door.GetComponent<DoorController>().Operate();
            Destroy(triger_garage);
            Destroy(particle_system);
            particle_system_pickup.SetActive(true);
            trigger_pickup.SetActive(true);
        }
    }

}
