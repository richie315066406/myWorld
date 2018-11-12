using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRFunction : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public string ButtonName
  {
    get;
    protected set;
  }

  public int FunctionType
  {
    get;
    protected set;
  }

  public List<int> ParameterList
  {
    get;
    protected set;
  }

  public void ParseDataRow(string dataRowText)
  {
    string[] text = DataTableExtension.SplitDataRow(dataRowText);
    int index = 0;
    index++;
    Id = int.Parse(text[index++]);
    index++;
    ButtonName = text[index++];
    FunctionType = int.Parse(text[index++]);
	ParameterList = DataTableExtension.SplitIntList(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRFunction > ();
  }
}
}
