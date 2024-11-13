using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool modeDoor;
    // Start is called before the first frame update
    void Start()
    {
        modeDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Operate()
    {
        StartCoroutine(ControllModeDoor());
    }

     IEnumerator ControllModeDoor()
    {

        if(! modeDoor)
        {
            int angle = Mathf.FloorToInt(transform.eulerAngles.y);
            int angle_end = Mathf.FloorToInt(transform.eulerAngles.y) - 90;


            while (angle > angle_end)
            {
                angle--;
                Vector3 rotate = transform.eulerAngles;
                rotate.y = angle;
                transform.rotation = Quaternion.Euler(rotate);
                yield return new WaitForSeconds(.01f);
            }
            modeDoor = true;
        }



    }

}
