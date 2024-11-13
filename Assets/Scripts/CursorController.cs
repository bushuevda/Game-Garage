using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Progress;

public class CursorController : MonoBehaviour
{


    [SerializeField] Texture2D textureBegin;


    [SerializeField] Texture2D textureChange;



    [SerializeField] Camera _camera;

    bool changeTexture = false;


    float posX;
    float posY;
    int size = 46;


    void OnGUI()
    {
        if (!changeTexture)
            GUI.DrawTexture(new Rect(posX, posY, size, size), textureBegin);
        else
            GUI.DrawTexture(new Rect(posX, posY, size, size), textureChange);
    }


    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        posX = _camera.pixelWidth / 2 - size / 4;
        posY = _camera.pixelHeight / 2 - size / 2;
    }

    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject != null && hitObject.GetComponent<Item>() != null)
            {
                changeTexture = true;
                takeItem(hitObject);
            }
            else
            {
                changeTexture = false;
            }

        }

    }


    void takeItem(GameObject hitObject)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
         hitObject.GetComponent<Item>().Put();
        }
    }



}

