namespace ProjectZGL
{
    /// <summary>
    /// 流程基类
    /// </summary>
    public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase
    {
        public abstract bool UseNativeDialog
        {
            get;
        }
    }
}
