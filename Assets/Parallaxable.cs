using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxable : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _subject;

    [Header("Config")]
    [SerializeField] private bool _lockX = false;
    [SerializeField] private bool _lockY = false;

    // Starting Position
    private Vector3 _startingPos;

    // Travel Calc
    private float travelX => this._camera.transform.position.x - this._startingPos.x;
    private float travelY => this._camera.transform.position.y - this._startingPos.y;

    // Calculating Parallax Factor
    private float distanceFromSubject => this.transform.position.z - this._subject.transform.position.z;
    private float clipPlaneCalc => this._camera.transform.position.z + this._camera.farClipPlane;
    private float parallaxFactor => Mathf.Abs(this.distanceFromSubject) / this.clipPlaneCalc;

    // Generating new Position
    private float newX => this._lockX ? this._startingPos.x : this._startingPos.x + this.travelX * this.parallaxFactor;
    private float newY => this._lockY ? this._startingPos.y : this._startingPos.y + this.travelY * this.parallaxFactor;

    private void Start()
    {
        this._startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(this.newX, this.newY, this._startingPos.z);
    }
}
