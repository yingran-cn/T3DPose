/*
作者：Ran
项目：T3DPose
时间：2023年09月05日 星期二 11:28
描述：
*/

using System;
using Mediapipe;
using Mediapipe.Unity.PoseTracking;
using MemoryPack;
using Ran.Vo;
using UnityEngine;

namespace Ran.Pose
{
    public class PoseSquatTrack : MonoBehaviour
    {
        const float MaxAngle = 160.0f;
        const float MinAngle = 90.0f;
        bool _isDecreasing = false;
        //int _repCount = 0;

        private void OnEnable()
        {
            GlobalPoseEvent.PoseWorldLandmarksOutputEvent += GlobalPoseEventOnPoseWorldLandmarksOutputEvent;
        }

        private void GlobalPoseEventOnPoseWorldLandmarksOutputEvent(LandmarkList obj)
        {
            if (obj == null)
            {
                return;
            }
            var angle = PoseMathTool.Angle(
                PoseMathTool.LandmarkToVector3(obj.Landmark[24]),
                PoseMathTool.LandmarkToVector3(obj.Landmark[26]),
                PoseMathTool.LandmarkToVector3(obj.Landmark[28])
            );
            Debug.Log(angle);
            if (angle > MaxAngle && !_isDecreasing)
            {
                _isDecreasing = true;
            }
            else if (angle < MinAngle && _isDecreasing)
            {
                _isDecreasing = false;
                //发送姿势
                var msgBaseVo = new MsgBaseVo<PoseBaseType>();
                msgBaseVo.Type = Api.PoseBase;
                msgBaseVo.Data = PoseBaseType.Squat;
                var bin = MemoryPackSerializer.Serialize(msgBaseVo);
                FMNetworkManager.instance.SendToServer(bin);
            }
        }

        private void OnDisable()
        {
            GlobalPoseEvent.PoseWorldLandmarksOutputEvent -= GlobalPoseEventOnPoseWorldLandmarksOutputEvent;
        }
    }
}