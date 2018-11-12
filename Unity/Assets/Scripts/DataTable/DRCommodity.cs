using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRCommodity : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public int ItemID
  {
    get;
    protected set;
  }

  public int Price
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
    ItemID = int.Parse(text[index++]);
    Price = int.Parse(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRCommodity > ();
  }
}
}
