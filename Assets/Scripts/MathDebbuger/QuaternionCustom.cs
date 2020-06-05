using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
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

        public float this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

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
            throw new NotImplementedException(); 
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            return "X:" + x.ToString() + " Y:" + y.ToString() + " Z" + z.ToString() + " W:" + w.ToString();
        }

        public static Vec3 operator *(QuaternionCustom rotation, Vec3 point)
        {
            throw new NotImplementedException();
        }
        public static QuaternionCustom operator *(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(QuaternionCustom lhs, QuaternionCustom rhs)
        {
            throw new NotImplementedException();
        }
    }
}
