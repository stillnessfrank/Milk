using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.Record;
using System.Data;

namespace BIMFM.Controllers.SignalR
{
    /// <summary>
    /// 检验员绩效导出
    /// 工具类支持：1，在不使用模板情况下，导出数据为.xls和.xlsx文件。
    /// 2，使用xls模板，导出xls文件。
    /// 工具类目前不支持：使用.xlsx的模板导出数据，因为背景颜色会丢失。
    /// 建议：如果使用模板，请使用.xls的文件作为模板。
    /// </summary>
    public class ExcelReportUtil
    {

        public static IWorkbook ExportExcel(object[] list)
        {
            string[] Headers = {"资产编号", "房间名称", "资产规格编号", "资产规格名称", "楼层" };
            //生成Excel
            IWorkbook book = BuildWorkbook(list, Headers);
            return book;
        }

        //高版本
        public static XSSFWorkbook BuildWorkbook(object[] list, string[] Headers)
        {
            int count = list.Length;
            var book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("Sheet1");
            DataTable dt = GetDataTable(list, Headers);
            //Data Rows
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow drow = sheet.CreateRow(i);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = drow.CreateCell(j, CellType.String);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //自动列宽
                for (int i = 0; i <= Headers.Length; i++)
                    sheet.AutoSizeColumn(i, true);
            }

            return book;
        }

        private static DataTable GetDataTable(object[] list, string[] Headers)
        {
            DataTable dt = new DataTable();
            if (Headers != null && Headers.Length > 0)
            {
                for (int i = 0; i < Headers.Length; i++)
                {
                    dt.Columns.Add(Headers[i]);
                }
                DataRow dr = dt.NewRow();
                for (int i = 0; i < Headers.Length; i++)
                {
                    dr[i] = Headers[i];
                }
                dt.Rows.Add(dr);
            }
            //格式化列表
            if (list != null && list.Length > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    object[] itemList = (object[])list[i];
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < Headers.Length; j++)
                    {
                        dr[j] = itemList[j] == null ? "" : itemList[j].ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

    }
}
