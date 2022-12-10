using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class Movement : MonoBehaviour
{
 public float movespeed;
 public Transform orientation;
 Rigidbody rb;
 private float horizontalInput;
 private float verticalInput;
 Camera cam;

 private Vector3 moveDirection;

 void Start()
 {
  rb = GetComponent<Rigidbody>();
  rb.freezeRotation = true;
 }

 private void myInput()
 {
  horizontalInput = Input.GetAxis("Horizontal");
  verticalInput = Input.GetAxis("Vertical");


 }

 private void FixedUpdate()
 {
  MovePlayer();
 }

 void Update()
 {
  myInput();

  
 }

 private void MovePlayer()
 {
  moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
  rb.AddForce(moveDirection.normalized * movespeed * 10f, ForceMode.Force);
 }
 
 
}
