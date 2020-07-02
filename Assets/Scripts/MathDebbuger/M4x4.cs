using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath
{
    public class M4x4 : MonoBehaviour
    {
        
        public float m00;
        public float m33;
        public float m23;
        public float m13;
        public float m03;
        public float m32;
        public float m22;
        public float m02;
        public float m12;
        public float m21;
        public float m11;
        public float m01;
        public float m30;
        public float m20;
        public float m10;
        public float m31;

        public M4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Creates a rotation matrix.
        //
        // Parameters:
        //   q:
        public static M4x4 Rotate(QuaternionCustom q)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Creates a scaling matrix.
        //
        // Parameters:
        //   vector:
        public static M4x4 Scale(Vec3 vector)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Creates a translation matrix.
        //
        // Parameters:
        //   vector:
        public static M4x4 Translate(Vec3 vector)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Creates a translation, rotation and scaling matrix.
        //
        // Parameters:
        //   pos:
        //
        //   q:
        //
        //   s:
        public static M4x4 TRS(Vec3 pos, QuaternionCustom q, Vec3 s)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(M4x4 lhs, Vector4 vector)
        {
            throw new NotImplementedException();
        }
        public static Matrix4x4 operator *(M4x4 lhs, M4x4 rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(M4x4 lhs, M4x4 rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(M4x4 lhs, M4x4 rhs)
        {
            throw new NotImplementedException();
        }

    }
}
