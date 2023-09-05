using System.Collections.Generic;
using Mediapipe;
using Mediapipe.Unity.PoseTracking;
using MemoryPack;
using Ran.Pose;
using Ran.Vo;
using UnityEngine;
using JointVo = Ran.Vo.JointVo;

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
                List<JointVo> joints = new List<JointVo>();
     
                foreach (var t in PoseTrackingSolution.poseWorldLandmarks.Landmark)
                {
                    joints.Add(new JointVo()
                    {
                        X = t.X,
                        Y = t.Y,    
                        Z = t.Z,
                        Presence = t.Presence
                    });
                }
                var msgBaseVo = new MsgBaseVo<List<JointVo>>();
                msgBaseVo.Data = joints;
                msgBaseVo.Type = Api.PoseWorldLandmarks;
                // FM all joints
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
