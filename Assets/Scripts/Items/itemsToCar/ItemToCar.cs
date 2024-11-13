using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToCar : MonoBehaviour, Item
{
    Vector3 beginScale;
    [SerializeField] private GameObject player;

    void Start()
    {

        beginScale = transform.localScale;
    }
  

    public void Put()
    {
        ItemsController.Put(transform.gameObject, beginScale, player);
    }

    public void Toss()
    {
        gameObject.SetActive(false);
    }


}
