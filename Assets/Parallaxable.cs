using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxable : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _subject;

    [Header("Config")]
    [SerializeField] private bool lockY = false;
    [SerializeField] private bool lockX = false;
    [SerializeField] [Range(0.1f, 2f)] private float _smoothingFactor;

    private Vector3 _startingPos;

    private float travelX => this._camera.transform.position.x - this._startingPos.x;
    private float travelY => this._camera.transform.position.y - this._startingPos.y;

    // Parallax Factor

    private float distanceFromSubject => this._startingPos.z - this._subject.transform.position.z;
    private float clipPlane => this._camera.transform.position.z + (this.distanceFromSubject > 0 ? this._camera.farClipPlane : -this._camera.nearClipPlane);
    private float parallaxFactor => Mathf.Abs(this.distanceFromSubject) / this.clipPlane;

    private float newX => this.lockX ? this._startingPos.x : this._startingPos.x + (this.travelX * this.parallaxFactor * this._smoothingFactor);
    private float newY => this.lockY ? this._startingPos.y : this._startingPos.y + (this.travelY * this.parallaxFactor * this._smoothingFactor);


    private void Start()
    {
        this._startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(this.newX, this.newY, this._startingPos.z);
    }
}
