using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRUIForm : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public string AssetName
  {
    get;
    protected set;
  }

  public string UIGroupName
  {
    get;
    protected set;
  }

  public bool AllowMultiInstance
  {
    get;
    protected set;
  }

  public bool PauseCoveredUIForm
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
    AssetName = text[index++];
    UIGroupName = text[index++];
    AllowMultiInstance = bool.Parse(text[index++]);
    PauseCoveredUIForm = bool.Parse(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRUIForm > ();
  }
}
}
