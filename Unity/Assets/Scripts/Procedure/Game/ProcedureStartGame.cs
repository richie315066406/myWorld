using System.Collections.Generic;
using GameFramework.DataNode;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
    //动态数据初始化的地方：生成Game、Player和Site相关的DataNode
    public class ProcedureStartGame : ProcedureBase
    {
        private readonly Dictionary<GameMode, GameBase> m_Games = new Dictionary<GameMode, GameBase>();
	    private readonly Dictionary<GameMode, ICellGridGenerator> m_CellGridGenerators = new Dictionary<GameMode, ICellGridGenerator>();

		private GameBase m_CurrentGame = null;
	    private RectangularHexGridGenerator m_CellGridGenerator = null;
	    public List<Cell> Cells { get; private set; }

	    private bool IsLevelLoadingDone = false;

		public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

	    public void LevelLoadingDone()
	    {
		    IsLevelLoadingDone = true;
	    }


		protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            //添加游戏模式
//            m_Games.Add(GameMode.Normal, new NormalGame());
//			m_CellGridGenerators.Add(GameMode.Normal,new RectangularHexGridGenerator());
        }

		//进入流程，根据规则生成地图
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
	        base.OnEnter(procedureOwner);
	        IsLevelLoadingDone = false;

			GameEntry.Event.Subscribe(LevelLoadingDoneEventArgs.EventId, OnLeaveLoadingDone);

			GameMode gameMode = (GameMode)procedureOwner.GetData<VarInt>(Constant.ProcedureData.GameMode).Value;
			//            m_CurrentGame = m_Games[gameMode];
			//			m_CurrentGame.Initialize();

			//TODO 根据规则生成地图，暂时写死为生成六边形地图
			//			GameEntry.Entity.CreateCellGrid(, GridGeneratorType.RectangularHexGrid);
			//	        Cells = new List<Cell>((Cell[])GameEntry.Entity.GetEntityGroup("Cell").GetAllEntities());
	        CreateCellGrid(new MyHexagonData(3, 3) { }, 10, 10);

			GameEntry.Event.Fire(this, new LevelLoadingDoneEventArgs());
		}

		protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
	    {
		    base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
		    if (IsLevelLoadingDone)
		    {
			    ChangeState<ProcedureWaitingForInput>(procedureOwner);
			}
		}

		protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            m_Games.Clear();
            base.OnLeave(procedureOwner, isShutdown);
        }

	    public void OnLeaveLoadingDone(object sender, GameEventArgs e)
	    {
		    if (sender!=this)
		    {
			    return;
		    }
			//		    LevelLoadingDoneEventArgs ne = (LevelLoadingDoneEventArgs) e;
		    LevelLoadingDone();
	    }

	    public void CreateCellGrid(MyHexagonData myHexagonData,int weight, int height)
	    {
		    HexGridType hexGridType = weight % 2 == 0 ? HexGridType.even_q : HexGridType.odd_q;
//		    List<Cell> hexagons = new List<Cell>();

		    for (int i = 0; i < height; i++)
		    {
			    for (int j = 0; j < weight; j++)
			    {
					//TODO 待完成
//				    GameEntry.Entity.ShowMyHexagon();

//					GameObject hexagon = Instantiate(HexagonPrefab);
//				    var hexSize = hexagon.GetComponent<Cell>().GetCellDimensions();
//
//				    hexagon.transform.position = new Vector3((j * hexSize.x * 0.75f), 0, (i * hexSize.z) + (j % 2 == 0 ? 0 : hexSize.z * 0.5f));
//					 hexagon.GetComponent<Hexagon>().OffsetCoord = new Vector2(Width - j - 1, Height - i - 1);
//					 hexagon.GetComponent<Hexagon>().HexGridType = hexGridType;
//					 hexagon.GetComponent<Hexagon>().MovementCost = 1;
////				    hexagons.Add(hexagon.GetComponent<Cell>());
//
//				    hexagon.transform.parent = CellsParent;
			    }
		    }
//		    return hexagons;
		}
	}
}