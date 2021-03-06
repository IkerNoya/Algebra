﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace CustomMath
{
    public class QuaternionCustom : IEquatable<QuaternionCustom>
    {
        public const float kEpsilon = 1E-06F;
        public float x;
        public float y;
        public float z;
        public float w;

        public QuaternionCustom(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public QuaternionCustom()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.w = 0;
        }
        public QuaternionCustom(Quaternion q)
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        public float this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public static implicit operator Quaternion(QuaternionCustom q)
        {
            return new Quaternion(q.x, q.y, q.z, q.w);
        }
        public static implicit operator QuaternionCustom(Quaternion q)
        {
            return new QuaternionCustom(q.x, q.y, q.z, q.w);
        }

        //
        // Summary:
        //     The identity rotation (Read Only).
        public static QuaternionCustom identity { get { return new QuaternionCustom(0,0,0,1); } }
        //
        //Summary:
        //     Returns or sets the euler angle representation of the rotation.
        public Vec3 eulerAngles
        {
            //heading = y  attitude = z  bank = x
            get
            {
                Vec3 a = Vec3.Zero;
                a.y = Mathf.Atan2((2 * y * w) - (2 * x * z), 1 - (2 * (y * y)) - 2 * (z * z)) * Mathf.Rad2Deg;
                a.z = Mathf.Asin(2 * x * y + 2 * z * w) * Mathf.Rad2Deg;
                a.x = Mathf.Atan2(2 * x * w - 2 * y * z, 1 - 2 * (x * x) - 2 * (z * z)) * Mathf.Rad2Deg;
                return a;
            }
            set
            {
                QuaternionCustom q = QuaternionCustom.Euler(value);
                x = q.x;
                y = q.y;
                z = q.z;
                w = q.w;
            }
        }

        // Summary:
        //     Returns this quaternion with a magnitude of 1 (Read Only).
        public QuaternionCustom normalized { get { return Normalize(this); } }

        //
        // Summary:
        //     Returns the angle in degrees between two rotations a and b.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static float Angle(QuaternionCustom a, QuaternionCustom b) 
        {
            QuaternionCustom inv = QuaternionCustom.Inverse(a);
            QuaternionCustom result = b * inv;
            float angle = Mathf.Acos(result.w) * 2.0f * Mathf.Rad2Deg;
            return angle;
        }
        //
        // Summary:
        //     Creates a rotation which rotates angle degrees around axis.
        //
        // Parameters:
        //   angle:
        //
        //   axis:
        public static QuaternionCustom AngleAxis(float angle, Vec3 axis)
        {
            angle *= Mathf.Deg2Rad;
            axis.Normalize();
            QuaternionCustom result = new QuaternionCustom
            {
                x = axis.x * Mathf.Sin(angle * 0.5f),
                y = axis.y * Mathf.Sin(angle * 0.5f),
                z = axis.z * Mathf.Sin(angle * 0.5f),
                w = Mathf.Cos(angle * 0.5f)
            };
            result.Normalize();

            return result;
        }
        //
        // Summary:
        //     The dot product between two rotations.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static float Dot(QuaternionCustom a, QuaternionCustom b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
        }
        //
        // Summary:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parameters:
        //   euler:
        public static QuaternionCustom Euler(Vector3 euler)
        {
            float rad = Mathf.Deg2Rad;
            euler *= rad;
            QuaternionCustom q = new QuaternionCustom();
            q.x = Mathf.Sin(euler.x * 0.5f);
            q.y = Mathf.Sin(euler.y * 0.5f);
            q.z = Mathf.Sin(euler.z * 0.5f);
            q.w = Mathf.Cos(euler.x * 0.5f) * Mathf.Cos(euler.y * 0.5f) * Mathf.Cos(euler.z * 0.5f) - Mathf.Sin(euler.x * 0.5f) * Mathf.Sin(euler.y * 0.5f) * Mathf.Sin(euler.z * 0.5f); // buscar por que esta formula es asi
            q.Normalize();
            return q;
        }
        //
        // Summary:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parameters:
        //   x:
        //
        //   y:
        //
        //   z:
        public static QuaternionCustom Euler(float x, float y, float z)
        {
            float rad = Mathf.Deg2Rad;
            x *= rad;
            y *= rad;
            z *= rad;
            QuaternionCustom q = new QuaternionCustom();
            q.x = Mathf.Sin(x * 0.5f);
            q.y = Mathf.Sin(y * 0.5f);
            q.z = Mathf.Sin(z * 0.5f);
            q.w = Mathf.Cos(x * 0.5f) * Mathf.Cos(y * 0.5f) * Mathf.Cos(z * 0.5f) - Mathf.Sin(x * 0.5f) * Mathf.Sin(y * 0.5f) * Mathf.Sin(z * 0.5f);
            q.Normalize();
            return q;
        }
        //
        // Summary:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parameters:
        //   fromDirection:
        //
        //   toDirection:
        public static QuaternionCustom FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Vec3 cross = Vec3.Cross(fromDirection, toDirection);
            QuaternionCustom result = QuaternionCustom.identity;
            result.x = cross.x;
            result.y = cross.y;
            result.z = cross.z;
            result.w = Mathf.Sqrt(fromDirection.magnitude * fromDirection.magnitude) * Mathf.Sqrt(toDirection.magnitude * toDirection.magnitude) + Vec3.Dot(fromDirection, toDirection);
            result.Normalize();
            return result;
        }
        //
        // Summary:
        //     Returns the Inverse of rotation.
        //
        // Parameters:
        //   rotation:
        public static QuaternionCustom Inverse(QuaternionCustom rotation)
        {
            QuaternionCustom inv = new QuaternionCustom(-rotation.x, -rotation.y, -rotation.z, rotation.w);
            return inv;
        }
        //
        // Summary:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is clamped to the range [0, 1].
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        public static QuaternionCustom Lerp(QuaternionCustom a, QuaternionCustom b, float t)
        {
            QuaternionCustom q = new QuaternionCustom();
            if (t < 1)
            {
                q.x = ((b.x-a.x)*t+a.x);
                q.y = ((b.y-a.y)*t+a.y);
                q.z = ((b.z-a.z)*t+a.z);
                q.w = ((b.w-a.w)*t+a.w);
            }
            else
            {
                t = 1.0f;
            }
            q.Normalize();
            return q;
        }
        //
        // Summary:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        public static QuaternionCustom LerpUnclamped(QuaternionCustom a, QuaternionCustom b, float t)
        {
            QuaternionCustom q = new QuaternionCustom();
            q.x = ((b.x - a.x) * t + a.x);
            q.y = ((b.y - a.y) * t + a.y);
            q.z = ((b.z - a.z) * t + a.z);
            q.w = ((b.w - a.w) * t + a.w);
            q.Normalize();
            return q;
        }
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static QuaternionCustom LookRotation(Vec3 forward) //se puede tomar euler
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static QuaternionCustom LookRotation(Vec3 forward, Vec3 upwards) // la rotacion tomando en cuenta a lo que estas mirando y cual es su arriba
        {
            QuaternionCustom result;
            if(forward == Vec3.Zero)
            {
                result = QuaternionCustom.identity;
                return result;
            }
            if (upwards != forward)
            {
                upwards.Normalize();
                Vec3 a = forward + upwards * -Vec3.Dot(forward, upwards);                   // No funciona
                QuaternionCustom q = QuaternionCustom.FromToRotation(Vec3.Forward, a);
                return QuaternionCustom.FromToRotation(a, forward) * q;
            }
            else
            {
                return QuaternionCustom.FromToRotation(Vec3.Forward, forward);
            }
        }

        //
        // Summary:
        //     Converts this quaternion to one with the same orientation but with a magnitude
        //     of 1.
        //
        // Parameters:
        //   q:
        public static QuaternionCustom Normalize(QuaternionCustom q)
        {
            float magnitude = Mathf.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w);
            q.x /= magnitude;
            q.y /= magnitude;
            q.z /= magnitude;
            q.w /= magnitude;
            return q;
        }
        //
        // Summary:
        //     Rotates a rotation from towards to.
        //
        // Parameters:
        //   from:
        //
        //   to:
        //
        //   maxDegreesDelta:
        public static QuaternionCustom RotateTowards(QuaternionCustom from, QuaternionCustom to, float maxDegreesDelta)
        {
         throw new NotImplementedException();
        }
        //
        // Summary:
        //     Spherically interpolates between a and b by t. The parameter t is clamped to
        //     the range [0, 1].
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        public static QuaternionCustom Slerp(QuaternionCustom a, QuaternionCustom b, float t) // No funciona
        {
            QuaternionCustom q = QuaternionCustom.identity;
            a.Normalize();
            b.Normalize();
            float dot = Quaternion.Dot(a, b);
            if (dot < 0)
            {
                a = QuaternionCustom.Inverse(a);
                dot = -dot;
            }
            float max = 0.9995f;
            if (dot > max)
            {
                QuaternionCustom result = QuaternionCustom.Lerp(a, b, t);
                result.Normalize();
                return result;
            }
            // si esta dentro del rango (0 a 1 0 0.99995)
            float angleT_0 = Mathf.Acos(dot);
            float angleT = angleT_0 * t;
            float sinT = Mathf.Sin(angleT);
            float sinT_0 = Mathf.Sin(angleT_0);

            float sin0 = Mathf.Cos(angleT) - dot * sinT / sinT_0;
            float sin1 = sinT / sinT_0;
            QuaternionCustom res = QuaternionCustom.identity;
            res.x = (a.x * sin0) + (b.x * sin1); 
            res.y = (a.y * sin0) + (b.y * sin1);
            res.z = (a.z * sin0) + (b.z * sin1);
            res.w = (a.w * sin0) + (b.w * sin1);
            return res;
        }
        //
        // Summary:
        //     Spherically interpolates between a and b by t. The parameter t is not clamped.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        public static QuaternionCustom SlerpUnclamped(QuaternionCustom a, QuaternionCustom b, float t)
        { 
            QuaternionCustom q = QuaternionCustom.identity;
            a.Normalize();
            b.Normalize();
            float dot = Quaternion.Dot(a, b);

            float angleT_0 = Mathf.Acos(dot);
            float angleT = angleT_0 * t;
            float sinT = Mathf.Sin(angleT);
            float sinT_0 = Mathf.Sin(angleT_0);

            float sin0 = Mathf.Cos(angleT) - dot * sinT / sinT_0;
            float sin1 = sinT / sinT_0;
            QuaternionCustom res = QuaternionCustom.identity;
            res.x = (a.x * sin0) + (b.x * sin1);
            res.y = (a.y * sin0) + (b.y * sin1);
            res.z = (a.z * sin0) + (b.z * sin1);
            res.w = (a.w * sin0) + (b.w * sin1);
            return res;
        }
        public bool Equals(QuaternionCustom other)
        {
            return this == other; 
        }
        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode() 
        { 
            throw new NotImplementedException(); 
        }
        public void Normalize()
        {
            float magnitude = Mathf.Sqrt(x * x + y * y + z * z + w * w);
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
            w /= magnitude;
        }
        //
        // Summary:
        //     Set x, y, z and w components of an existing Quaternion.
        //
        // Parameters:      
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        //
        //   newW:
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }
        //
        // Summary:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parameters:
        //   fromDirection:
        //
        //   toDirection:
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            QuaternionCustom q = QuaternionCustom.identity;
             q = FromToRotation(fromDirection, toDirection);
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view, Vec3 up)
        {
            QuaternionCustom q = QuaternionCustom.identity;
            q = LookRotation(view, up);
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }
        //
        // Summary:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parameters:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view)
        {
            throw new NotImplementedException();
        }
        public void ToAngleAxis(out float angle, out Vec3 axis)
        {
            throw new NotImplementedException(); // No
        }
        //
        // Summary:
        //     Returns a nicely formatted string of the Quaternion.
        //
        // Parameters:
        //   format:
        public string ToString(string format)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Returns a nicely formatted string of the Quaternion.
        //
        // Parameters:
        //   format:
        public override string ToString()
        {
            return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ", " + w.ToString() + ")";
        }

        public static Vec3 operator *(QuaternionCustom rotation, Vec3 point)
        {
            throw new NotImplementedException();
        }
        public static QuaternionCustom operator *(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            //return new QuaternionCustom(lhs.x*rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w); 2D
            return new QuaternionCustom((lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z + lhs.z * rhs.y), // i/x
                                        (lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x), // j/y    3D
                                        (lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w), // k/z
                                        (lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z));//   w
        }
        public static QuaternionCustom operator *(QuaternionCustom lhs, Quaternion rhs)
        {
            //return new QuaternionCustom(lhs.x*rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w); 2D
            return new QuaternionCustom((lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z + lhs.z * rhs.y), // i/x
                                        (lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x), // j/y    3D
                                        (lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w), // k/z
                                        (lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z));//   w
        }
        public static QuaternionCustom operator *(Quaternion lhs, QuaternionCustom rhs)
        {
            //return new QuaternionCustom(lhs.x*rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w); 2D
            return new QuaternionCustom((lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z + lhs.z * rhs.y), // i/x
                                        (lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x), // j/y    3D
                                        (lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w), // k/z
                                        (lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z));//   w
        }
        public static bool operator ==(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }
        public static bool operator !=(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w);
        }
    }
}
