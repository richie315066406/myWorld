using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRShop : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public int Level
  {
    get;
    protected set;
  }

  public int GoodType
  {
    get;
    protected set;
  }

  public int OpenTime
  {
    get;
    protected set;
  }

  public int CloseTime
  {
    get;
    protected set;
  }

  public List<int> CommodityList
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
    Level = int.Parse(text[index++]);
    GoodType = int.Parse(text[index++]);
    OpenTime = int.Parse(text[index++]);
    CloseTime = int.Parse(text[index++]);
	CommodityList = DataTableExtension.SplitIntList(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRShop > ();
  }
}
}
