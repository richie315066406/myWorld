using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace ProjectZGL
{
	/// <summary>
	/// 游戏中所有单位的基类
	/// </summary>
	public abstract class Unit : Entity
	{
		private UnitData m_UnitData = null;

		public UnitData MUnitData
		{
			get { return m_UnitData; }
			set { m_UnitData = value; }
		}
//		public void SetState(UnitState state)
//		{
//			UnitState.MakeTransition(state);
//		}
		
		private static DijkstraPathfinding _pathfinder = new DijkstraPathfinding();
		private static IPathfinding _fallbackPathfinder = new AStarPathfinding();

		/// <summary>
		/// 对象实例化后调用的方法，用于初始化字段等
		/// </summary>
		protected override void OnShow(object userData)
		{
			base.OnShow(userData);

			m_UnitData = (UnitData) userData;

			m_UnitData.Buffs = new List<Buff>();

//			UnitState = new UnitStateNormal(this);

//			TotalHitPoints = HitPoints;
//			TotalMovementPoints = MovementPoints;
//			TotalActionPoints = ActionPoints;
		}

		protected virtual void OnMouseDown()
		{
			GameEntry.Event.Fire(this,new UnitClickedEventArgs(this));
		}
		protected virtual void OnMouseEnter()
		{
			GameEntry.Event.Fire(this, new UnitHighlightedEventArgs(this));
		}
		protected virtual void OnMouseExit()
		{
			GameEntry.Event.Fire(this, new UnitDehighlightedEventArgs(this));
		}

		/// <summary>
		/// 方法在每个回合开始时被调用
		/// </summary>
		public virtual void OnTurnStart()
		{
//			m_UnitData.MovementPoints = m_UnitData.TotalMovementPoints;
//			m_UnitData.ActionPoints = m_UnitData.TotalActionPoints;

//			m_UnitData.SetState(new UnitStateMarkedAsFriendly(this));
		}
		/// <summary>
		/// 方法在每个回合结束时被调用
		/// </summary>
		public virtual void OnTurnEnd()
		{
			m_UnitData.cachedPaths = null;
			m_UnitData.Buffs.FindAll(b => b.Duration == 0).ForEach(b => { b.Undo(this); });
			m_UnitData.Buffs.RemoveAll(b => b.Duration == 0);
			m_UnitData.Buffs.ForEach(b => { b.Duration--; });

//			SetState(new UnitStateNormal(this));
		}
		/// <summary>
		/// 方法，当单位HP低于1时调用
		/// </summary>
		protected virtual void OnDestroyed()
		{
//			Cell.CelData.IsTaken = false;
			MarkAsDestroyed();
			Destroy(gameObject);
		}

		/// <summary>
		/// 方法，当单元被选中时调用
		/// </summary>
		public virtual void OnUnitSelected()
		{
//			SetState(new UnitStateMarkedAsSelected(this));
//			if (UnitSelected != null)
//				UnitSelected.Invoke(this, new EventArgs());
		}
		/// <summary>
		/// 方法在单元取消选择时调用
		/// </summary>
		public virtual void OnUnitDeselected()
		{
//			SetState(new UnitStateMarkedAsFriendly(this));
//			if (UnitDeselected != null)
//				UnitDeselected.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Method indicates if it is possible to attack unit given as parameter, 
		/// from cell given as second parameter.
		/// </summary>
		public virtual bool IsUnitAttackable(Unit other, Cell sourceCell)
		{
//			if (sourceCell.GetDistance(other.Cell) <= AttackRange)
//				return true;

			return false;
		}
		/// <summary>
		/// 方法对作为参数的Unit造成损害
		/// </summary>
		public virtual void DealDamage(Unit other)
		{
			if (m_UnitData.isMoving)
				return;
//			if (ActionPoints == 0)
//				return;
//			if (!IsUnitAttackable(other, Cell))
//				return;
//
//			MarkAsAttacking(other);
//			ActionPoints--;
//			other.Defend(this, AttackFactor);
//
//			if (ActionPoints == 0)
//			{
//				SetState(new UnitStateMarkedAsFinished(this));
//				MovementPoints = 0;
//			}
		}
		/// <summary>
		/// Attacking unit calls Defend method on defending unit. 
		/// </summary>
		protected virtual void Defend(Unit other, int damage)
		{
			MarkAsDefending(other);
			//Damage is calculated by subtracting attack factor of attacker and defence factor of defender. 
			//If result is below 1, it is set to 1. This behaviour can be overridden in derived classes.
			m_UnitData.HitPoints -= Mathf.Clamp(damage - m_UnitData.DefenceFactor, 1, damage);
//			if (m_UnitData.UnitAttacked != null)
//				m_UnitData.UnitAttacked.Invoke(this, new AttackEventArgs(other, this, damage));

			if (m_UnitData.HitPoints <= 0)
			{
//				if (m_UnitData.UnitDestroyed != null)
//					m_UnitData.UnitDestroyed.Invoke(this, new AttackEventArgs(other, this, damage));
				OnDestroyed();
			}
		}

		/// <summary>
		/// Moves the unit to destinationCell along the path.
		/// </summary>
		public virtual void Move(Cell destinationCell, List<Cell> path)
		{
			if (m_UnitData.isMoving)
				return;

//			var totalMovementCost = path.Sum(h => h.MovementCost);
//			if (MovementPoints < totalMovementCost)
//				return;
//
//			MovementPoints -= totalMovementCost;
//
//			Cell.IsTaken = false;
//			Cell = destinationCell;
//			destinationCell.IsTaken = true;
//
//			if (MovementSpeed > 0)
//				StartCoroutine(MovementAnimation(path));
//			else
//				transform.position = Cell.transform.position;
//
//			if (UnitMoved != null)
//				UnitMoved.Invoke(this, new MovementEventArgs(Cell, destinationCell, path));
		}
		protected virtual IEnumerator MovementAnimation(List<Cell> path)
		{
			m_UnitData.isMoving = true;
			path.Reverse();
			foreach (var cell in path)
			{
				Vector3 destination_pos = new Vector3(cell.transform.localPosition.x, transform.localPosition.y, cell.transform.localPosition.z);
				while (transform.localPosition != destination_pos)
				{
					transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination_pos, Time.deltaTime * m_UnitData.MovementSpeed);
					yield return 0;
				}
			}
			m_UnitData.isMoving = false;
		}

		///<summary>
		/// Method indicates if unit is capable of moving to cell given as parameter.
		/// </summary>
		public virtual bool IsCellMovableTo(Cell cell)
		{
//			return !cell.IsTaken;
			return false;
		}
		/// <summary>
		/// Method indicates if unit is capable of moving through cell given as parameter.
		/// </summary>
		public virtual bool IsCellTraversable(Cell cell)
		{
//			return !cell.IsTaken;
			return false;
		}

		/// <summary>
		/// 方法返回unit能够移动到的所有单元格
		/// </summary>
		public HashSet<Cell> GetAvailableDestinations(List<Cell> cells)
		{
//			cachedPaths = new Dictionary<Cell, List<Cell>>();

//			var paths = cachePaths(cells);
//			foreach (var key in paths.Keys)
//			{
//				if (!IsCellMovableTo(key))
//					continue;
//				var path = paths[key];
//
//				var pathCost = path.Sum(c => c.MovementCost);
//				if (pathCost <= MovementPoints)
//				{
//					cachedPaths.Add(key, path);
//				}
//			}
//			return new HashSet<Cell>(cachedPaths.Keys);
			return null;
		}

		private Dictionary<Cell, List<Cell>> cachePaths(List<Cell> cells)
		{
//			var edges = GetGraphEdges(cells);
//			var paths = _pathfinder.findAllPaths(edges, Cell);
//			return paths;
			return null;
		}

		public List<Cell> FindPath(List<Cell> cells, Cell destination)
		{
//			if (cachedPaths != null && cachedPaths.ContainsKey(destination))
//			{
//				return cachedPaths[destination];
//			}
//			else
//			{
//				return _fallbackPathfinder.FindPath(GetGraphEdges(cells), Cell, destination);
//			}
			return null;
		}
		/// <summary>
		/// 方法返回单元格网格的图表示，以进行寻路
		/// </summary>
		protected virtual Dictionary<Cell, Dictionary<Cell, int>> GetGraphEdges(List<Cell> cells)
		{
			Dictionary<Cell, Dictionary<Cell, int>> ret = new Dictionary<Cell, Dictionary<Cell, int>>();
//			foreach (var cell in cells)
//			{
//				if (IsCellTraversable(cell) || cell.Equals(Cell))
//				{
//					ret[cell] = new Dictionary<Cell, int>();
//					foreach (var neighbour in cell.GetNeighbours(cells).FindAll(IsCellTraversable))
//					{
//						ret[cell][neighbour] = neighbour.MovementCost;
//					}
//				}
//			}
			return ret;
		}
		/// <summary>
		/// Gives visual indication that the unit is under attack.
		/// </summary>
		/// <param name="other"></param>
		public abstract void MarkAsDefending(Unit other);
		/// <summary>
		/// Gives visual indication that the unit is attacking.
		/// </summary>
		/// <param name="other"></param>
		public abstract void MarkAsAttacking(Unit other);
		/// <summary>
		/// Gives visual indication that the unit is destroyed. It gets called right before the unit game object is
		/// destroyed, so either instantiate some new object to indicate destruction or redesign Defend method. 
		/// </summary>
		public abstract void MarkAsDestroyed();
		/// <summary>
		/// Method marks unit as current players unit.
		/// </summary>
		public abstract void MarkAsFriendly();
		/// <summary>
		/// Method mark units to indicate user that the unit is in range and can be attacked.
		/// </summary>
		public abstract void MarkAsReachableEnemy();
		/// <summary>
		/// Method marks unit as currently selected, to distinguish it from other units.
		/// </summary>
		public abstract void MarkAsSelected();
		/// <summary>
		/// Method marks unit to indicate user that he can't do anything more with it this turn.
		/// </summary>
		public abstract void MarkAsFinished();
		/// <summary>
		/// Method returns the unit to its base appearance
		/// </summary>
		public abstract void UnMark();
	}
}
