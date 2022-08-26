using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    //for fire arrow
    public Arrow arrow;
    public Transform gunPoint;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoint;
    Vector2 dir;
    PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        ////bow trajectory
        //points = new GameObject[numberOfPoints];
        //for (int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i] = Instantiate(point, gunPoint.position, Quaternion.identity);
        //}
    }
    private void Update()
    {
        Vector2 bowPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - bowPos) * Mathf.Sign(player.transform.localScale.x);
        transform.right = dir;

        //for (int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i].transform.position = PointPos(i * spaceBetweenPoint);
        //}
    }

    //Vector2 PointPos(float t)
    //{
    //    //cong thuc tinh quang duong
    //    Vector2 pos = (Vector2)gunPoint.position + (dir.normalized * arrow.arrowSpeed * t)
    //        + 0.5f * Physics2D.gravity * (t * t);
    //    return pos;
    //}
}
