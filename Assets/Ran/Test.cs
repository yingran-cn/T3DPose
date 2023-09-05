/*
作者：Ran
项目：PoseSend
时间：2023年09月04日 星期一 13:47
描述：
*/

using System;
using Mediapipe;
using Mediapipe.Unity.PoseTracking;
using Ran.Pose;
using UnityEngine;

namespace Ran
{
    public class Test : MonoBehaviour
    {
        private void OnEnable()
        {
            GlobalPoseEvent.PoseWorldLandmarksOutputEvent += GlobalPoseEventOnPoseWorldLandmarksOutputEvent;
        }

        private void GlobalPoseEventOnPoseWorldLandmarksOutputEvent(LandmarkList obj)
        {
            if (PoseTrackingSolution.poseWorldLandmarks == null)
            {
                Debug.LogWarning("poseWorldLandmarks null !!!!!");
            }
            else
            {
                //
                var angle = PoseMathTool.Angle(
                    PoseMathTool.LandmarkToVector3(PoseTrackingSolution.poseWorldLandmarks.Landmark[14]),
                    PoseMathTool.LandmarkToVector3(PoseTrackingSolution.poseWorldLandmarks.Landmark[11]),
                    PoseMathTool.LandmarkToVector3(PoseTrackingSolution.poseWorldLandmarks.Landmark[24])
                );
                Debug.Log("angle" + angle);
            }
        }

        private void Update()
        {
            /*if (PoseTrackingSolution.poseWorldLandmarks == null)
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
            }*/
        }
    }
}