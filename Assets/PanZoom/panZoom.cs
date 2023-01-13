using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credits to @AsToldByWaldo
public class panZoom : MonoBehaviour
{

    private bool AllowedToMove = false;
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    private readonly float minX = -3f, minY = -6f, maxX = 3f, maxY = 6f;
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("a"))
        {
            AllowedToMove = !AllowedToMove;
        }
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2 && AllowedToMove){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0) && AllowedToMove){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment){
        if(AllowedToMove) Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}