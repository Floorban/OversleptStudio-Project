using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;
using TMPro;
using Unity.Mathematics;

public class GyroTest : MonoBehaviour
{
    //public TextMeshProUGUI text;
    Rigidbody rb;
    public Vector3 angularVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InputSystem.EnableDevice(Gyroscope.current);
        InputSystem.EnableDevice(Accelerometer.current);
        InputSystem.EnableDevice(AttitudeSensor.current);
        InputSystem.EnableDevice(GravitySensor.current);
    }

    void Update()
    {
        angularVelocity = Gyroscope.current.angularVelocity.ReadValue();
        Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
        Vector3 attitude = AttitudeSensor.current.attitude.ReadValue().eulerAngles; // ReadValue() returns a Quaternion
        Vector3 gravity = GravitySensor.current.gravity.ReadValue();

       // text.text = $"Angular Velocity\nX={angularVelocity.x:#0.0} Y={angularVelocity.y:#0.0} Z={angularVelocity.z:#0.0}\n\n";
                       // $"Acceleration\nX={acceleration.x:#0} Y={acceleration.y:#0} Z={acceleration.z:#0}\n\n" +
                         //   $"Attitude\nX={attitude.x:#0} Y={attitude.y:#0} Z={attitude.z:#0}\n\n" +
                           //  $"Gravity\nX={gravity.x:#0} Y={gravity.y:#0} Z={gravity.z:#0}";

        //rb.AddForce(angularVelocity.z * -5f, angularVelocity.x * 5f, 0);
        //gameObject.transform.position += new Vector3 (angularVelocity.z * -3f, 0, 0) * Time.deltaTime;
    }
}
