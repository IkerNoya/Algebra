﻿using UnityEngine;
using System;
namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { return (x * x + y * y + z * z); } }
        public Vector3 normalized { get { return new Vec3(x / magnitude, y / magnitude, z / magnitude); } }
        public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }  // longitud del vector
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            bool equalsX = left.x == right.x;
            bool equalsY = left.y == right.y;
            bool equalsZ = left.z == right.z;
            return (equalsX && equalsY && equalsZ);
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - rightV3.x, leftV3.y - rightV3.y, leftV3.z - rightV3.z);
        }

        public static Vec3 operator -(Vec3 v3)
        {
            return new Vec3(-v3.x, -v3.y, -v3.z);
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }
        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return new Vec3(scalar * v3.x, scalar * v3.y, scalar * v3.z);
        }
        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x / scalar, v3.y / scalar, v3.z / scalar);
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            float result = (from.x * to.x) + (from.y * to.y) + (from.z * to.z);
            float a = Mathf.Sqrt(from.x + from.y + from.z);
            float b = Mathf.Sqrt(to.x + to.y + to.z);
            return Mathf.Acos(result / (a * b));
        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {
            throw new NotImplementedException();
        }
        public static float Magnitude(Vec3 vector)
        {
            return vector.magnitude;
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            return new Vec3((a.y * b.z) - (b.y * a.z), (a.z * b.x) - (b.z * a.x), (a.x * b.y) - (b.x * a.y));
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
            return (((b.x - a.x) * (b.x - a.x)) + ((b.y - a.y) * (b.x - a.x)) + ((b.z - a.z) * (b.x - a.x))) / 2;
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            return (a.x*b.x)+(a.y*b.y)+(a.z*b.z);
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {
            Vec3 newVec = Vec3.One;
            if (t < 1)
            {
                newVec = new Vec3(((b-a)*t+a));
            }
            else
            {
                t = 1.0f;
            }
            return newVec;
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            Vec3 newVec = Vec3.One;
            newVec = new Vec3(((b - a) * t + a));
            return newVec;
        }
        public static Vec3 Max(Vec3 a, Vec3 b)
        {
            Vec3 c;
            if (a.x > b.x) c.x = a.x;
            else c.x = b.x;
            if (a.y > b.y) c.y = a.y;
            else c.y = b.y;
            if (a.z > b.z) c.z = a.z;
            else c.z = b.z;
            return c;
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            Vec3 c;
            if (a.x < b.x) c.x = a.x;
            else c.x = b.x;
            if (a.y < b.y) c.y = a.y;
            else c.y = b.y;
            if (a.z < b.z) c.z = a.z;
            else c.z = b.z;
            return c;
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return vector.sqrMagnitude;
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal)
        {
            return (Vec3.Dot(vector, onNormal)/Vec3.Dot(vector, vector)) * vector;
        }
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal)
        {
            Vec3 normal = new Vec3(inNormal.normalized);
            return inDirection - 2 * (Vec3.Dot(inDirection, normal)) * normal;
        }
        public void Set(float newX, float newY, float newZ) //hacer
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public void Scale(Vec3 scale) // hacer
        {
            x = x * scale.x;
            y = y * scale.y;
            z = z * scale.z;
        }
        public void Normalize() // hacer
        {
            x = x / magnitude;
            y = y / magnitude;
            z = z/ magnitude;
        }
        public static void Normalize(Vec3 value) // hacer
        {
            value.x = value.x / value.magnitude;
            value.y = value.y / value.magnitude;
            value.z = value.z / value.magnitude;
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}