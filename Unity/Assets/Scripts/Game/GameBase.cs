using System.Collections.Generic;
using System.Linq;
using GameFramework;
using GameFramework.DataNode;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;


namespace ProjectZGL
{
    public abstract class GameBase
    {
        public abstract GameMode GameMode { get; }
        private IDataNode m_GameData = null;
        private IDataNode m_PlayerData = null;
        private IDataNode m_SiteList = null;
        private Dictionary<DataType,DataLogicBase> m_DataLogics = new Dictionary<DataType, DataLogicBase>();

        private GameStateType m_GameState = GameStateType.ActionBegin;

        public bool GameOver { get; protected set; }

        private bool m_isNewGame = false;
        public void NewGame()
        {
            m_isNewGame = true;
        }
	    public int NumberOfPlayers { get; private set; }

	    public Player CurrentPlayer
	    {
		    get { return Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)); }
	    }
	    public int CurrentPlayerNumber { get; private set; }


		/// <summary>
		/// GameObject that holds player objects.
		/// </summary>
		public Transform PlayersParent;

	    public List<Player> Players { get; private set; }
	    public List<Cell> Cells { get; private set; }
	    public List<Unit> Units { get; private set; }

		//游戏初始化
		public virtual void Initialize()
        {

	        GameEntry.Entity.CreateCellGrid(new MyHexagonData(2,3){}, 10, 10, GridGeneratorType.RectangularHexGrid);
			Cells = new List<Cell>((Cell[])GameEntry.Entity.GetEntityGroup("Cell").GetAllEntities());

			GameEntry.Event.Fire(this,new LevelLoadingDoneEventArgs());
		}

	    /// <summary>
	    /// 方法在游戏开始时被调用一次
	    /// </summary>
	    public virtual void StartGame()
	    {
//		    if (GameStarted != null)
//			    GameStarted.Invoke(this, new EventArgs());

//		    Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnStart(); });
//		    Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)).Play(this);
	    }

	    /// <summary>
	    /// 回合转换，在他的回合结束时由player调用
	    /// </summary>
	    public void EndTurn()
	    {
			GameEntry.Event.Fire(this,new TurnEndedEventArgs());
//		    if (Units.Select(u => u.PlayerNumber).Distinct().Count() == 1)
//		    {
//			    return;
//		    }
//		    CellGridState = new CellGridStateTurnChanging(this);
//
//		    Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnEnd(); });
//
//		    CurrentPlayerNumber = (CurrentPlayerNumber + 1) % NumberOfPlayers;
//		    while (Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).Count == 0)
//		    {
//			    CurrentPlayerNumber = (CurrentPlayerNumber + 1) % NumberOfPlayers;
//		    }//Skipping players that are defeated.
//
//		    if (TurnEnded != null)
//			    TurnEnded.Invoke(this, new EventArgs());
//
//		    Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnStart(); });
//		    Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)).Play(this);
	    }
	}
}
