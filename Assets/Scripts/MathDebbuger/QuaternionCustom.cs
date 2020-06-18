using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System.Security.Cryptography;

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
        public static QuaternionCustom identity { get; }
        //
        // Summary:
        //     Returns or sets the euler angle representation of the rotation.
        public Vector3 eulerAngles { get; set; }
        //
        // Summary:
        //     Returns this quaternion with a magnitude of 1 (Read Only).
        public QuaternionCustom normalized { get; }

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
            Debug.Log(inv);
            QuaternionCustom result = b * inv;
            float ej = Mathf.Acos(result.w) * 2.0f * Mathf.Rad2Deg;
            return 360 - ej;
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
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees")]
        public static QuaternionCustom AxisAngle(Vec3 axis, float angle)
        {
            throw new NotImplementedException();
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
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static QuaternionCustom EulerAngles(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static QuaternionCustom EulerAngles(Vec3 euler)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static QuaternionCustom EulerRotation(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static QuaternionCustom EulerRotation(Vector3 euler)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public static QuaternionCustom LookRotation(Vec3 forward)
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
        public static QuaternionCustom LookRotation(Vec3 forward, Vec3 upwards)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public static QuaternionCustom Slerp(QuaternionCustom a, QuaternionCustom b, float t)
        {
            float diff = 1 - t;
            QuaternionCustom q = new QuaternionCustom(); // buscar bien como funciona la formula
            if (t < 1)
            {
                float dot = Mathf.Acos(QuaternionCustom.Dot(a, b));
                float sin = Mathf.Sqrt(1 - dot * dot);
                float dotDiv1 = Mathf.Sin(diff * dot) / sin;
                float dotDiv2 = Mathf.Sin(t * dot) / sin;
                q.x = dotDiv1 * q.x + dotDiv2 * q.x;
                q.y = dotDiv1 * q.y + dotDiv2 * q.y;
                q.z = dotDiv1 * q.z + dotDiv2 * q.z;
                q.w = dotDiv1 * q.w + dotDiv2 * q.w;
            }
            else
            {
                t = 1.0f;
            }
            q.Normalize();
            Debug.Log("Prueba Q: " + q);
            return q;
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
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Vec3 ToEulerAngles(QuaternionCustom rotation)
        {
            throw new NotImplementedException();
        }
        public bool Equals(QuaternionCustom other)
        {
            throw new NotImplementedException();
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
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetAxisAngle(Vector3 axis, float angle)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(Vec3 euler)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(Vec3 euler)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.ToAngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void ToAxisAngle(out Vec3 axis, out float angle)
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vec3 ToEuler()
        {
            throw new NotImplementedException();
        }
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vec3 ToEulerAngles()
        {
            throw new NotImplementedException();
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
            return "X: " + x.ToString() + " Y: " + y.ToString() + " Z: " + z.ToString() + " W: " + w.ToString();
        }

        public static Vec3 operator *(QuaternionCustom rotation, Vec3 point)
        {
            throw new NotImplementedException();
        }
        public static QuaternionCustom operator *(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            return new QuaternionCustom(lhs.x*rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        }
        public static bool operator ==(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w)
                return true;
            else
                return false;
        }
        public static bool operator !=(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            if (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w)
                return true;
            else
                return false;
        }
    }
}
