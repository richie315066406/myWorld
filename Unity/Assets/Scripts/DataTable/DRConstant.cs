using GameFramework.DataTable;
using System.Collections.Generic;
namespace ProjectZGL
{
public class DRConstant : IDataRow
{
  public int Id
  {
    get;
    protected set;
  }

  public string ConfigKey
  {
    get;
    protected set;
  }

  public List<int> IntParameterList
  {
    get;
    protected set;
  }

  public List<string> StringParameterList
  {
    get;
    protected set;
  }

  public List<float> FloatParameterList
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
    ConfigKey = text[index++];
	IntParameterList = DataTableExtension.SplitIntList(text[index++]);
	StringParameterList = new List<string>(text[index++].Split('*'));
//    FloatParameterList = List<float>.Parse(text[index++]);
  }
  private void AvoidJIT()
  {
    new Dictionary<int, DRConstant > ();
  }
}
}
