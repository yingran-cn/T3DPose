/*
作者：Ran
项目：PoseSend
时间：2023年09月04日 星期一 11:13
描述：
*/

using System;
using Mediapipe;

namespace Ran.Pose
{
    public static class GlobalPoseEvent
    {
        public static event Action<LandmarkList> PoseWorldLandmarksOutputEvent;

        public static void OnPoseWorldLandmarksOutputEvent(LandmarkList obj)
        {
            PoseWorldLandmarksOutputEvent?.Invoke(obj);
        }
    }
}