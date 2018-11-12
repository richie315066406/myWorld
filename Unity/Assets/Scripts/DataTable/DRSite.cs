using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRSite : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public int SiteType
  {
    get;
    protected set;
  }

  public string SiteName
  {
    get;
    protected set;
  }

  public int PositionX
  {
    get;
    protected set;
  }

  public int PositionY
  {
    get;
    protected set;
  }

  public string BGAssName
  {
    get;
    protected set;
  }

  public int LevelID
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

  public List<int> FunctionList
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
    SiteType = int.Parse(text[index++]);
    SiteName = text[index++];
    PositionX = int.Parse(text[index++]);
    PositionY = int.Parse(text[index++]);
    BGAssName = text[index++];
    LevelID = int.Parse(text[index++]);
    OpenTime = int.Parse(text[index++]);
    CloseTime = int.Parse(text[index++]);
	FunctionList = DataTableExtension.SplitIntList(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRSite > ();
  }
}
}
