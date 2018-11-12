namespace ProjectZGL
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }

//        public static HPBarComponent HPBar
//        {
//            get;
//            private set;
//        }

//	    public static CellGridComponent CellGrid
//	    {
//		    get;
//		    private set;
//	    }

        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
			//            HPBar = UnityGameFramework.Runtime.GameEntry.GetComponent<HPBarComponent>();
//	        CellGrid = UnityGameFramework.Runtime.GameEntry.GetComponent<CellGridComponent>();
        }
    }
}
