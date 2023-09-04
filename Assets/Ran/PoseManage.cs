using System;
using Mediapipe;
using Mediapipe.Unity.PoseTracking;
using Ran.Pose;
using UnityEngine;
/*
作者：Ran
项目：PoseSend
时间：2023年09月04日 星期一 09:52
描述：
*/
namespace Ran
{
    public class PoseManage : MonoBehaviour
    {
        private void OnEnable()
        {
            GlobalPoseEvent.PoseWorldLandmarksOutputEvent += GlobalPoseEventOnPoseWorldLandmarksOutputEvent;
        }

        private void GlobalPoseEventOnPoseWorldLandmarksOutputEvent(LandmarkList obj)
        {
            if (PoseTrackingSolution.poseWorldLandmarks == null)
            {
                Debug.Log("null pose track !!!!!!!!");
            }
            else
            {
                foreach (var landmark in PoseTrackingSolution.poseWorldLandmarks.Landmark)
                {
                    Debug.Log("Presence" + landmark.Presence);
                    Debug.Log("X:" + landmark.X + "y:" + landmark.Y + "Z:" + landmark.Z);
                }
            }
        }

        private void OnDisable()
        {
            GlobalPoseEvent.PoseWorldLandmarksOutputEvent -= GlobalPoseEventOnPoseWorldLandmarksOutputEvent;
        }
    }
}
