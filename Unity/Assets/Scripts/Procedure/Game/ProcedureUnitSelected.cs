using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
	public class ProcedureUnitSelected : ProcedureMain
    {
	    private Unit _unit;
//	    private HashSet<Cell> _pathsInRange;
//	    private List<Unit> _unitsInRange;
//
//	    private Cell _unitCell;
//
//	    private List<Cell> _currentPath;

		public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

			GameEntry.Event.Subscribe(UnitClickedEventArgs.EventId,OnUnitClikedEventArgs);
//	        _unit.OnUnitSelected();
//	        _unitCell = _unit.Cell;
//
//	        _pathsInRange = _unit.GetAvailableDestinations(CellGridComponent.Cells);
//	        var cellsNotInRange = CellGridComponent.Cells.Except(_pathsInRange);
//
//	        foreach (var cell in cellsNotInRange)
//	        {
//		        cell.UnMark();
//	        }
//	        foreach (var cell in _pathsInRange)
//	        {
//		        cell.MarkAsReachable();
//	        }
//
//	        if (_unit.ActionPoints <= 0) return;
//
//	        foreach (var currentUnit in CellGridComponent.Units)
//	        {
//		        if (currentUnit.PlayerNumber.Equals(_unit.PlayerNumber))
//			        continue;
//
//		        if (_unit.IsUnitAttackable(currentUnit, _unit.Cell))
//		        {
//			        currentUnit.SetState(new UnitStateMarkedAsReachableEnemy(currentUnit));
//			        _unitsInRange.Add(currentUnit);
//		        }
//	        }
//
//	        if (_unitCell.GetNeighbours(CellGridComponent.Cells).FindAll(c => c.MovementCost <= _unit.MovementPoints).Count == 0
//	            && _unitsInRange.Count == 0)
//		        _unit.SetState(new UnitStateMarkedAsFinished(_unit));
		}

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
			base.OnLeave(procedureOwner, isShutdown);
//	        _unit.OnUnitDeselected();
//	        foreach (var unit in _unitsInRange)
//	        {
//		        if (unit == null) continue;
//		        unit.SetState(new UnitStateNormal(unit));
//	        }
//	        foreach (var cell in CellGridComponent.Cells)
//	        {
//		        cell.UnMark();
//	        }
		}

	    protected override void OnDestroy(ProcedureOwner procedureOwner)
	    {
		    base.OnDestroy(procedureOwner);
	    }

//	    public CellGridStateUnitSelected(CellGridComponent cellGridComponent, Unit unit) : base(cellGridComponent)
//	    {
//		    _unit = unit;
//		    _pathsInRange = new HashSet<Cell>();
//		    _currentPath = new List<Cell>();
//		    _unitsInRange = new List<Unit>();
//	    }

	    public void OnUnitClikedEventArgs(object sender, GameEventArgs e)
	    {
		    UnitClickedEventArgs ne = (UnitClickedEventArgs)e;
		    _unit = ne.Unit;
			//		    _pathsInRange = new HashSet<Cell>();
			//		    _currentPath = new List<Cell>();
			//		    _unitsInRange = new List<Unit>();

//			if (unit.Equals(_unit) || _unit.isMoving)
//			    return;
//
//		    if (_unitsInRange.Contains(unit) && _unit.ActionPoints > 0)
//		    {
//			    _unit.DealDamage(unit);
//			    CellGridComponent.CellGridState = new CellGridStateUnitSelected(CellGridComponent, _unit);
//		    }
//
//		    if (unit.PlayerNumber.Equals(_unit.PlayerNumber))
//		    {
//			    CellGridComponent.CellGridState = new CellGridStateUnitSelected(CellGridComponent, unit);
//		    }
		}

	    protected override void OnCellClicked(object sender, GameEventArgs e)
	    {
//		    if (_unit.isMoving)
//			    return;
//		    if (cell.IsTaken || !_pathsInRange.Contains(cell))
//		    {
//			    CellGridComponent.CellGridState = new CellGridStateWaitingForInput(CellGridComponent);
//			    return;
//		    }
//
//		    var path = _unit.FindPath(CellGridComponent.Cells, cell);
//		    _unit.Move(cell, path);
//		    CellGridComponent.CellGridState = new CellGridStateUnitSelected(CellGridComponent, _unit);
		}

	    protected override void OnCellDeselected(object sender, GameEventArgs e)
	    {
//		    foreach (var _cell in _currentPath)
//		    {
//			    if (_pathsInRange.Contains(_cell))
//				    _cell.MarkAsReachable();
//			    else
//				    _cell.UnMark();
//		    }
		}

	    protected override void OnCellSelected(object sender, GameEventArgs e)
	    {
//		    if (!_pathsInRange.Contains(cell)) return;
//
//		    _currentPath = _unit.FindPath(CellGridComponent.Cells, cell);
//		    foreach (var _cell in _currentPath)
//		    {
//			    _cell.MarkAsPath();
//		    }
		}
	}
}
