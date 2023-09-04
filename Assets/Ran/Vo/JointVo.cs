/*
作者：Ran
项目：T3DPose
时间：2023年09月04日 星期一 14:50
描述：
*/

using MemoryPack;

namespace Ran.Vo
{
    [MemoryPackable]
    public partial class JointVo
    {
        public float X, Y, Z;
        /// <summary>
        /// 可信度
        /// </summary>
        public float Presence;
    }
}