using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour {

    public float frequency;
    public bool record = true;

    public Stack<Vector3> pointsOverTime = new Stack<Vector3>();

    private void Start()
    {
        StartCoroutine("recordPer");
    }

    private void Update()
    {
        Vector3[] points = pointsOverTime.ToArray();

        for(int i = 0; i < points.Length; i++)
        {
            if(i != 0 && i != points.Length)
            {
                Debug.DrawLine(points[i-1], points[i]);
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            record = false;
            StopAllCoroutines();

            StartCoroutine("reverse");
        }
    }

    IEnumerator reverse()
    {
        GetComponent<characterController>().enabled = false;

        foreach(Vector3 v in pointsOverTime)
        {
            transform.position = v;
            yield return null;
        }

        pointsOverTime = new Stack<Vector3>();

        record = true;
        GetComponent<characterController>().enabled = true;

        StartCoroutine("recordPer");
    }

    IEnumerator recordPer()
    {
        while(record == true)
        {
            pointsOverTime.Push(transform.position);
            yield return new WaitForSeconds(frequency);
        }
    }
}
