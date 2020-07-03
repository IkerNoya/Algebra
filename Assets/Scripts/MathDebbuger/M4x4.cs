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
            m00 = column0.x; m01 = column0.y; m02 = column0.z; m03 = column0.w;
            m10 = column1.x; m11 = column1.y; m12 = column1.z; m13 = column1.w;
            m20 = column2.x; m21 = column2.y; m22 = column2.z; m23 = column2.w;
            m30 = column3.x; m31 = column3.y; m32 = column3.z; m33 = column3.w;
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
            Vector4 vec;
            vec.x = (lhs.m00 * vector.x) + (lhs.m01 * vector.y) + (lhs.m02 * vector.z) + (lhs.m03 * vector.w);
            vec.y = (lhs.m10 * vector.x) + (lhs.m11 * vector.y) + (lhs.m12 * vector.z) + (lhs.m13 * vector.w);
            vec.z = (lhs.m20 * vector.x) + (lhs.m21 * vector.y) + (lhs.m22 * vector.z) + (lhs.m23 * vector.w);
            vec.w = (lhs.m30 * vector.x) + (lhs.m31 * vector.y) + (lhs.m32 * vector.z) + (lhs.m33 * vector.w);
            return vec;
        }
        public static Matrix4x4 operator *(M4x4 lhs, M4x4 rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(M4x4 lhs, M4x4 rhs)
        {
            if (lhs.m00 == rhs.m00 && lhs.m01 == rhs.m01 && lhs.m02 == rhs.m02 && lhs.m03 == rhs.m03
             && lhs.m10 == rhs.m10 && lhs.m11 == rhs.m11 && lhs.m12 == rhs.m12 && lhs.m13 == rhs.m13
             && lhs.m20 == rhs.m20 && lhs.m21 == rhs.m21 && lhs.m22 == rhs.m22 && lhs.m23 == rhs.m23
             && lhs.m30 == rhs.m30 && lhs.m31 == rhs.m31 && lhs.m32 == rhs.m32 && lhs.m33 == rhs.m33) return true;
            else return false;
        }
        public static bool operator !=(M4x4 lhs, M4x4 rhs)
        {
            if (lhs.m00 != rhs.m00 || lhs.m01 != rhs.m01 || lhs.m02 != rhs.m02 || lhs.m03 != rhs.m03 
             || lhs.m10 != rhs.m10 || lhs.m11 != rhs.m11 || lhs.m12 != rhs.m12 || lhs.m13 != rhs.m13
             || lhs.m20 != rhs.m20 || lhs.m21 != rhs.m21 || lhs.m22 != rhs.m22 || lhs.m23 != rhs.m23
             || lhs.m30 != rhs.m30 || lhs.m31 != rhs.m31 || lhs.m32 != rhs.m32 || lhs.m33 != rhs.m33) return true;
            else return false;
        }

        //Bibliografia:
        //Khal Ragnar AKA: Julian Bega
    }
}
