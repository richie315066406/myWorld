using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRItem : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public int Burden
  {
    get;
    protected set;
  }

  public string NameKey
  {
    get;
    protected set;
  }

  public string IntroKey
  {
    get;
    protected set;
  }

  public string PicAssName
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
    Burden = int.Parse(text[index++]);
    NameKey = text[index++];
    IntroKey = text[index++];
    PicAssName = text[index++];
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRItem > ();
  }
}
}
