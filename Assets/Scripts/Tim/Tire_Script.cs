using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire_Script : MonoBehaviour
{
    [SerializeField] private Car_Physics Car;

    [SerializeField] private bool PoweredWheel;

    [SerializeField] private bool SteeringWheel;

    [SerializeField] private Transform model;

    // Update is called once per frame
    void FixedUpdate()
    {
        calculateForces();
    }

    void calculateForces()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, Car.raylength))
        {
            //spring system
            Vector3 springdir = transform.up;
            float offset = Car.springrestpos - hit.distance;
            float speed = Vector3.Dot(springdir, Car.rbody.GetPointVelocity(transform.position));
            float force = (offset * Car.springstrength) - (Car.DampForce * speed);
            Car.rbody.AddForceAtPosition(springdir * force * Time.deltaTime, transform.position);

            //friction mechanic
            Vector3 steeringdir = transform.right;
            Vector3 tireworldvel = Car.rbody.GetPointVelocity(transform.position);
            float steeringvel = Vector3.Dot(steeringdir, tireworldvel);
            float desiredvelchange = -steeringvel * Car.friction;
            float desiredAccel = desiredvelchange * Time.fixedDeltaTime;
            Car.rbody.AddForceAtPosition(steeringdir * desiredAccel, transform.position);

            //acceleration mechanic
            if (PoweredWheel)
             Car.rbody.AddForceAtPosition(transform.forward * Car.desiredAcceleration, transform.position);

            //steering mechanic
            if (SteeringWheel)
                transform.localRotation = Quaternion.Euler(new Vector3(0, Car.desiredSteering, 0));

            //model mechanic
            model.position = hit.point;
        }
    }
}
