using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public static class DataTableExtension
    {
        private const string DataRowClassPrefixName = "ProjectZGL.DR";
        private static readonly string[] ColumnSplit = new string[] { "\t" };

        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, object userData = null)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string[] splitNames = dataTableName.Split('_');
            if (splitNames.Length > 2)
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string dataRowClassName = DataRowClassPrefixName + splitNames[0];

            Type dataRowType = Type.GetType(dataRowClassName);
            if (dataRowType == null)
            {
                Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
                return;
            }

            string dataTableNameInType = splitNames.Length > 1 ? splitNames[1] : null;
            dataTableComponent.LoadDataTable(dataRowType, dataTableName, dataTableNameInType, AssetUtility.GetDataTableAsset(dataTableName), Constant.AssetPriority.DataTableAsset, userData);
        }

        public static string[] SplitDataRow(string dataRowText)
        {
            return dataRowText.Split(ColumnSplit, StringSplitOptions.None);
        }

        public static List<int> SplitIntList(string stringList){
            
            string[] strArray = stringList.Split('*');

	        List<int> intList = new List<int>();
	        foreach (var str in strArray)
	        {
		        int r;
		        bool t = int.TryParse(str,out r);
		        if (t)
		        {
			        intList.Add(r);
				}
		        else
		        {
					Log.Error("is not null");
			        return null;
		        }
	        }
	        return intList;
        }

//	    public static ArrayList SplitArrayList(string stringList)
//	    {
//
//		    return stringList.Split('*') as ArrayList;
//		    
//	    }
	}
}
