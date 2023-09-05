/*
作者：Ran
项目：T3DPose
时间：2023年09月05日 星期二 10:10
描述：
*/

using System;
using Mediapipe;
using UnityEngine;

namespace Ran.Pose
{
    public static class PoseMathTool
    {
        /// <summary>
        /// 计算三点之间的夹角
        /// </summary>
        /// <param name="start"></param>
        /// <param name="middle"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double Angle(Vector3 start, Vector3 middle, Vector3 end)
        {
            double ab = Math.Sqrt(
                Math.Pow(start.x - middle.x, 2) +
                Math.Pow(start.y - middle.y, 2) +
                Math.Pow(start.z - middle.z, 2));
            double cb = Math.Sqrt(
                Math.Pow(end.x - middle.x, 2) +
                Math.Pow(end.y - middle.y, 2) +
                Math.Pow(end.z - middle.z, 2));
            double ca = Math.Sqrt(
                Math.Pow(end.x - start.x, 2) +
                Math.Pow(end.y - start.y, 2) +
                Math.Pow(end.z - start.z, 2));
            if (ab == 0.0 || cb == 0.0) return 0.0;
            double angle = Math.Acos(
                (ab * ab + cb * cb - ca * ca) /
                (2 * ab * cb));
            return angle * 180.0 / Math.PI;
        }

        public static Vector3 LandmarkToVector3(Landmark landmark)
        {
            return new Vector3(landmark.X, landmark.Y, landmark.Z);
        }
    }
}