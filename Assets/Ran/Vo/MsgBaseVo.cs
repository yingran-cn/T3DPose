/*
作者：Ran
项目：T3DPose
时间：2023年09月04日 星期一 17:16
描述：
*/
using MemoryPack;
namespace Ran.Vo
{
    [MemoryPackable]
    public partial class MsgBaseVo<T>
    {
        public int Type;
        public T Data;
    }
}
