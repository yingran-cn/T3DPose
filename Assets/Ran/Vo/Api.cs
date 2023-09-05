/*
作者：Ran
项目：T3DPose
时间：2023年09月04日 星期一 17:30
描述：
*/

namespace Ran.Vo
{
    public static class Api
    {
        /// <summary>
        /// 世界坐标系的全身33个点位置
        /// </summary>
        public const int PoseWorldLandmarks = 0;

        /// <summary>
        /// 基础姿势
        /// </summary>
        public const int PoseBase = 1;
    }

    /// <summary>
    /// 基础姿势
    /// </summary>
    public enum PoseBaseType
    {
        /// <summary>
        /// 左手或右手举起过肩并保持至少一秒
        /// </summary>
        RaiseRightHand,
        RaiseLeftHand,
        /// <summary>
        /// 双手举起过肩并保持至少一秒
        /// </summary>
        Psi,
        /// <summary>
        /// 左手或右手举起来回摆动
        /// </summary>
        Wave,
        /// <summary>
        /// 右手向左挥.
        /// </summary>
        SwipeLeft,
        /// <summary>
        /// 左手向右挥
        /// </summary>
        SwipeRight,
        /// <summary>
        /// 左手或者右手向上/下挥
        /// </summary>
        SwipeUp,
        SwipeDown,
        /// <summary>
        /// 左手或右手在适当的位置停留至少2.5秒
        /// </summary>
        Click,
        /// <summary>
        /// 手肘向下，左右手掌合在一起（求佛的手势），然后慢慢分开.
        /// </summary>
        ZoomOut,
        /// <summary>
        /// 手肘向下，两手掌相聚至少0.7米，然后慢慢合在一起
        /// </summary>
        ZoomIn,
        /// <summary>
        /// 就是ZoomOut/In的手势，只不过在动的时候是前后而非左右
        /// </summary>
        Wheel,
        /// <summary>
        /// 在1.5秒内髋关节中心至少上升10厘米
        /// </summary>
        Jump,
        /// <summary>
        ///  在1.35秒内两腿夹角MaxAngle = 160.0f; MinAngle = 40.0f;
        /// </summary>
        Squat,
        /// <summary>
        /// 在1.5秒内将左手或右手向外推
        /// </summary>
        Push,
        /// <summary>
        /// 在1.5秒内将左手或右手向里拉
        /// </summary>
        Pull
    }
}