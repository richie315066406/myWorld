using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DREntity : IDataRow
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

  public void ParseDataRow(string dataRowText)
  {
    string[] text = DataTableExtension.SplitDataRow(dataRowText);
    int index = 0;
    index++;
    Id = int.Parse(text[index++]);
    index++;
    AssetName = text[index++];
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DREntity > ();
  }
}
}
