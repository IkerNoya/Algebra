﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CustomMath;

namespace plane
{
    public class Planes : MonoBehaviour
    {

        public Planes(Vector3 inNormal, Vector3 inPoint)
        {
            normal = inNormal.normalized;
            distance = Mathf.Abs(((normal.x * inPoint.x) + (normal.y * inPoint.y) + (normal.z * inPoint.z))) / Vector3.Magnitude(normal);
        }
        
        public Planes(Vector3 a, Vector3 b, Vector3 c)
        {
            Vec3 v= new Vec3(b - a);
            Vec3 u= new Vec3(c - a);
            // ecuacion de plano = A(x-x1) + B(y-y1) + C(z-z1) + D = 0 ------> n(x1,y1,z1) "pista"
            // dis de Po al plano: Ax + Bx + Cx + D = 0 ----------> ABC=Plano y xyz=Po
            //nuevo Vec w = new Vec3(wx-ax, wy-ay, wz-az)
            // vec3.Dot(W,normalAux)
            normal = Vec3.Cross(v, u).normalized;
            distance = Mathf.Abs(((normal.x * a.x) + (normal.y * a.y) + (normal.z * a.z))) / Vector3.Magnitude(normal);
        }

        public Vector3 normal { get; set; }
        public float distance { get; set; }
       
        public Plane flipped { get; }


        public static Plane Translate(Plane plane, Vector3 translation)
        {
            throw new NotImplementedException();
        }
     
        public Vector3 ClosestPointOnPlane(Vector3 point)
        {
            throw new NotImplementedException();
        }
 
        public void Flip()
        {
            normal = -normal;
            distance = -distance;
        }

  
        public float GetDistanceToPoint(Vector3 point)
        { 
                return ((normal.x * point.x) + (normal.y * point.y) + (normal.z * point.z)) + distance / normal.magnitude;
        }
  
        public bool GetSide(Vector3 point)
        {
            float tempDistance = GetDistanceToPoint(point);

            if (tempDistance > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Raycast(Ray ray, out float enter)
        {
            throw new NotImplementedException();
        }
        
        public bool SameSide(Vector3 inPt0, Vector3 inPt1)
        {
            if (GetSide(inPt0)==true && GetSide(inPt1)==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   
        public void Set3Points(Vector3 a, Vector3 b, Vector3 c)
        {
            Vec3 v = new Vec3(b - a);
            Vec3 u = new Vec3(c - a);
            normal = Vec3.Cross(v, u).normalized;
            distance = Mathf.Abs(((normal.x * a.x) + (normal.y * a.y) + (normal.z * a.z))) / Vector3.Magnitude(normal);
        }
  
        public void SetNormalAndPosition(Vector3 inNormal, Vector3 inPoint)
        {
            normal = inNormal.normalized;
            distance = Mathf.Abs(((inNormal.x * inPoint.x) + (inNormal.y * inPoint.y) + (inNormal.z * inPoint.z))) / Vector3.Magnitude(inNormal);

        }
        public override string ToString()
        {
            return "(normal: " + normal.ToString() + " distance: " + distance.ToString() + ")";
        }
        public string ToString(string format)
        {
            throw new NotImplementedException();
        }
      
        public void Translate(Vector3 translation)
        {
            throw new NotImplementedException();
        }
    }
}
