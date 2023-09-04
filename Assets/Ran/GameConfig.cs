/*
作者：Ran
项目：PoseSend
时间：2023年09月04日 星期一 10:16
描述：
*/

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ran
{
    public class GameConfig: MonoBehaviour
    {
        public int targetFrame = 30;
        private void Awake()
        {
            Application.targetFrameRate = targetFrame;
        }
    }
}