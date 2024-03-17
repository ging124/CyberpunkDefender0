using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform subject;

    private Vector2 startPosition;
    private float startZ;

    private Vector2 travel => (Vector2)cam.transform.position - startPosition;
    private float distanceFromSubject => transform.position.z - subject.position.z;
    private float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane: cam.nearClipPlane));
    private float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    private void Awake()
    {
        this.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        this.subject = PlayerController.instance.player.transform;
    
        this.startPosition = transform.position;
        this.startZ = transform.position.z;
    }

    private void Update()
    {
        if (subject == null) return;

        Vector2 newPos = this.startPosition + this.travel * this.parallaxFactor * 2;
        transform.position = new Vector3(newPos.x, transform.position.y, this.startZ);
    }
}
