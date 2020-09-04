using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Dynamic;

namespace Carrington_Service.Helpers
{
    public class SubscribeHelper
    {
        public static ListDictionary ConvertToObjectWithoutSystemProperties(DataRow objectToTransform, string objectToCheckSystemColumns, string objectToCheckStandardColumns = null)
        {
            ListDictionary myColumnDict = new ListDictionary();
            objectToCheckSystemColumns = objectToCheckSystemColumns.Replace("'", "");
            objectToCheckStandardColumns = objectToCheckStandardColumns?.Replace("'", "");
            foreach (DataColumn cols in objectToTransform.Table.Columns)
            {
                bool IsSystemColumnsExist = Array.IndexOf(objectToCheckSystemColumns.Split(','), cols.ColumnName.ToLower()) >= 0;
                if (objectToCheckStandardColumns == null)
                {

                    if (!IsSystemColumnsExist)
                    {
                        string value = objectToTransform[cols.ColumnName].ToString();
                        myColumnDict.Add(cols.ColumnName, value);
                    }
                }
                else
                {
                    bool IsStandardColumnsExist = Array.IndexOf(objectToCheckStandardColumns.Split(','), cols.ColumnName.ToLower()) >= 0;
                    if (!IsSystemColumnsExist && !IsStandardColumnsExist)
                    {
                        string value = objectToTransform[cols.ColumnName].ToString();
                        myColumnDict.Add(cols.ColumnName, value);
                    }

                }
            }

            return myColumnDict;
        }
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            IDictionary<string, object> expandoDict = expando;
            if (expandoDict.ContainsKey(propertyName))
            {
                expandoDict[propertyName] = propertyValue;
            }
            else
            {
                expandoDict.Add(propertyName, propertyValue);
            }
        }
    }
}
