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
            //   0                    1                  2               3
            //   x                    y                  z               w
            m00 = column0.x; m10 = column0.y; m20 = column0.z; m30 = column0.w;//0
            m01 = column1.x; m11 = column1.y; m21 = column1.z; m31 = column1.w;//1
            m02 = column2.x; m12 = column2.y; m22 = column2.z; m32 = column2.w;//2
            m03 = column3.x; m13 = column3.y; m23 = column3.z; m33 = column3.w;//3
        }
        public static M4x4 zero 
        {
            get
            {
                return new M4x4(new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
            } 
        }
        //
        // Summary:
        //     Returns the identity matrix (Read Only).
        public static M4x4 identity
        {
            get
            {
                return new M4x4(new Vector4(1, 0, 0, 0), new Vector4(0, 1, 0, 0), new Vector4(0, 0, 1, 0), new Vector4(0, 0, 0, 1));
            }
        }
        //
        // Summary:
        //     Creates a rotation matrix.
        //
        // Parameters:
        //   q:
        public static M4x4 Rotate(QuaternionCustom q)
        {
            M4x4 mat = M4x4.identity;
            mat.m00 = 1 - 2 * q.y * q.y - 2 * q.z * q.z;
            mat.m10 = 2 - q.x * q.y - 2 * q.z * q.w;        // x
            mat.m20 = 1 - 2 * q.y * q.y - 2 * q.z * q.z;

            mat.m01 = 2 * q.x * q.y + 2 * q.z * q.w;
            mat.m01 = 1 - 2 * q.x * q.x - 2 * q.z * q.z;        //y
            mat.m01 = 2 * q.y * q.z - 2 * q.x * q.w;

            mat.m01 = 2 * q.x * q.z - 2 * q.y * q.w;
            mat.m01 = 2 * q.y * q.z + 2 * q.x * q.w;        //z
            mat.m01 = 1 - 2 * q.x * q.x - 2 * q.y * q.y;

            return mat;
        }
        //
        // Summary:
        //     Creates a scaling matrix.
        //
        // Parameters:
        //   vector:
        public static M4x4 Scale(Vec3 vector)
        {
            M4x4 mat = M4x4.identity;
            mat.m00 = vector.x;
            mat.m11 = vector.x;
            mat.m22 = vector.x;
            mat.m33 = 1;
            return mat;
        }
        //
        // Summary:
        //     Creates a translation matrix.
        //
        // Parameters:
        //   vector:
        public static M4x4 Translate(Vec3 vector)
        {
            M4x4 mat = M4x4.identity;
            mat.m30 = vector.x;
            mat.m31 = vector.y;
            mat.m32 = vector.z;
            mat.m33 = 1;
            return mat;
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
            M4x4 trs = M4x4.zero;
            trs = M4x4.Translate(pos) * M4x4.Rotate(q) *  M4x4.Scale(s);
            return trs;
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
        public static M4x4 operator *(M4x4 lhs, M4x4 rhs)
        {
            M4x4 m = new M4x4(Vector4.zero, Vector4.zero, Vector4.zero,Vector4.zero);
            m.m00 = (lhs.m00 * rhs.m00) + (lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02) + (lhs.m30 * rhs.m03);
            m.m10 = (lhs.m00 * rhs.m10) + (lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12) + (lhs.m30 * rhs.m13);
            m.m20 = (lhs.m00 * rhs.m20) + (lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22) + (lhs.m30 * rhs.m23);
            m.m30 = (lhs.m00 * rhs.m30) + (lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32) + (lhs.m30 * rhs.m33);

            m.m01 = (lhs.m01 * rhs.m00) + (lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02) + (lhs.m31 * rhs.m03);
            m.m11 = (lhs.m01 * rhs.m10) + (lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12) + (lhs.m31 * rhs.m13);
            m.m21 = (lhs.m01 * rhs.m20) + (lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22) + (lhs.m31 * rhs.m23);
            m.m31 = (lhs.m01 * rhs.m30) + (lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32) + (lhs.m31 * rhs.m33);

            m.m02 = (lhs.m02 * rhs.m00) + (lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02) + (lhs.m32 * rhs.m03);
            m.m12 = (lhs.m02 * rhs.m10) + (lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12) + (lhs.m32 * rhs.m13);
            m.m22 = (lhs.m02 * rhs.m20) + (lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22) + (lhs.m32 * rhs.m23);
            m.m32 = (lhs.m02 * rhs.m30) + (lhs.m12 * rhs.m31) + (lhs.m22 * rhs.m32) + (lhs.m32 * rhs.m33);

            m.m03 = (lhs.m03 * rhs.m00) + (lhs.m13 * rhs.m01) + (lhs.m23 * rhs.m02) + (lhs.m33 * rhs.m03);
            m.m13 = (lhs.m03 * rhs.m10) + (lhs.m13 * rhs.m11) + (lhs.m23 * rhs.m12) + (lhs.m33 * rhs.m13);
            m.m23 = (lhs.m03 * rhs.m20) + (lhs.m13 * rhs.m21) + (lhs.m23 * rhs.m22) + (lhs.m33 * rhs.m23);
            m.m33 = (lhs.m03 * rhs.m30) + (lhs.m13 * rhs.m31) + (lhs.m23 * rhs.m32) + (lhs.m33 * rhs.m33);

            return m;
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
    }
}
