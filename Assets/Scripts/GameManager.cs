using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class GameManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 mousePos;
    private Vector3 startMousePos;

    [SerializeField] GameObject prefab;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] private LeanTwistRotateAxis leanTwistRotateAxis;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    private Vector3 previousPosition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if(Vector3.Distance(mousePos, startMousePos) > 0.1f)
            {
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
                EnableLine(true);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = new Vector3((lineRenderer.GetPosition(0).x + lineRenderer.GetPosition(1).x) / 2, (lineRenderer.GetPosition(0).y + lineRenderer.GetPosition(1).y) / 2, -0.5f);
            float lengthLine = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude;
            newObject.transform.localScale = new Vector3(prefab.transform.localScale.x, lengthLine * 0.5f, prefab.transform.localScale.z);
            if(lineRenderer.GetPosition(0).x < lineRenderer.GetPosition(1).x)
            {
                newObject.transform.eulerAngles = new Vector3(0, 0, -Vector2.Angle(lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0), new Vector2(0, 1)));
            } else
            {
                newObject.transform.eulerAngles = new Vector3(0, 0, -Vector2.Angle(lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0), new Vector2(0, -1)));
            }
            EnableLine(false);
        }
    }

    private void EnableLine(bool val)
    {
        GetComponent<LineRenderer>().enabled = val;
    }

    public void SelectAxis(string axis)
    {
        switch(axis)
        {
            case "z":
                leanTwistRotateAxis.Axis = new Vector3(0, 0, 1);
                break;
            case "x":
                leanTwistRotateAxis.Axis = new Vector3(1, 0, 0);
                break;
            case "y":
                leanTwistRotateAxis.Axis = new Vector3(0, 1, 0);
                break;
        }
    }

}
