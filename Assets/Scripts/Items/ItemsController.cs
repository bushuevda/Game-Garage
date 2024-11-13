using UnityEngine;

namespace Items
{

    public static class ItemsController
    {

        static public bool equip = false; 

        public static void Put(GameObject gameObject, Vector3 beginScale, GameObject player)
        {
                if(!equip)
            {
                gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                Camera camera = player.GetComponentInChildren<Camera>();
                HandPlayer hand = camera.GetComponentInChildren<HandPlayer>();

                gameObject.transform.SetParent(hand.transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                gameObject.transform.localScale = beginScale;
                equip = true;
            }
    
        }

        public static void Toss(GameObject player)
        {
            if (equip)
            {
                Camera camera = player.GetComponentInChildren<Camera>();
                HandPlayer hand = camera.GetComponentInChildren<HandPlayer>();
                Item item = hand.GetComponentInChildren<Item>();
                item.Toss();
                equip = false;
            }


        }


    }
}