using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
namespace ClobDM_Mvc.Common
{
    public class Excel2003Result<T> : ExcelBaseResult<T> where T : new()
    {
        public Excel2003Result(IList<T> entity, string fileName, bool showTitle, string title)
            : base(entity, fileName, showTitle, title)
        {
            ContentType = "application/vnd.ms-excel";
            ExtName = ".xls";
        }

        public override MemoryStream GetExcelStream()
        {
            MemoryStream ms = new MemoryStream();
            //获取实体属性
            PropertyInfo[] propertys = typeof(T).GetProperties();
            if (propertys.Count() == 0)
            {
                return ms;
            }
            //创建Excel对象
            IWorkbook book = new HSSFWorkbook();
            //添加一个sheet
            ISheet sheet1 = book.CreateSheet("Sheet1");

            var index = ShowTitle ? 1 : 0;


            //样式设置
            IFont cellfont = book.CreateFont();
            cellfont.FontHeightInPoints = 11;
            cellfont.FontName = "宋体";
            ICellStyle cellStyle = book.CreateCellStyle();
            cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
            cellStyle.Alignment = HorizontalAlignment.CENTER;
            cellStyle.SetFont(cellfont);
            IRow rowColumnHead = sheet1.CreateRow(index);
            IDataFormat format = book.CreateDataFormat();
            ushort firstColumn = ushort.MaxValue, lastColumn = ushort.MinValue;  //第一列下标和最后一列下标
            //添加列头
            for (int j = 0; j < propertys.Count(); j++)
            {
                ExcelDataOptionAttribute dataOption = propertys[j].GetCustomAttribute<ExcelDataOptionAttribute>();
                if (dataOption == null)
                {
                    continue;
                }
                IFont font = book.CreateFont();
                font.FontHeightInPoints = 11;
                font.FontName = "宋体";
                ICellStyle style = book.CreateCellStyle();
                style.VerticalAlignment = VerticalAlignment.CENTER;
                style.Alignment = HorizontalAlignment.CENTER;
                style.SetFont(font);
                if (!string.IsNullOrWhiteSpace(dataOption.Formater))
                {
                    style.DataFormat = format.GetFormat(dataOption.Formater);
                }

                sheet1.SetDefaultColumnStyle(dataOption.ColumnIndex, style);

                ICell cell = rowColumnHead.CreateCell(dataOption.ColumnIndex);
                cell.SetCellValue(dataOption.DisplayName);



                firstColumn = firstColumn < dataOption.ColumnIndex ? firstColumn : dataOption.ColumnIndex;
                lastColumn = lastColumn > dataOption.ColumnIndex ? lastColumn : dataOption.ColumnIndex;

            }

            index = ShowTitle ? 2 : 1;

            //将各行数据显示出来
            for (int i = 0; i < Entity.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + index);

                //循环各属性，添加列
                for (int j = 0; j < propertys.Count(); j++)
                {
                    ExcelDataOptionAttribute dataOption = propertys[j].GetCustomAttribute<ExcelDataOptionAttribute>();
                    if (dataOption == null)
                    {
                        continue;
                    }

                    ICell cell = row.CreateCell(dataOption.ColumnIndex);

                    //样式设置
                    //cell.CellStyle = cellStyle;
                    if (dataOption.ColumnWidth != 0)
                    {
                        sheet1.SetColumnWidth(dataOption.ColumnIndex, dataOption.ColumnWidth * 256);
                    }

                    //根据数据类型判断显示格式
                    if (propertys[j].PropertyType == typeof(int))
                    {
                        cell.SetCellValue((int)propertys[j].GetValue(Entity[i]));
                    }
                    else if (propertys[j].PropertyType == typeof(decimal) || propertys[j].PropertyType == typeof(double) || propertys[j].PropertyType == typeof(float))
                    {
                        cell.SetCellValue(Convert.ToDouble(propertys[j].GetValue(Entity[i])));
                    }
                    else
                    {
                        cell.SetCellValue(propertys[j].GetValue(Entity[i]).ToString());
                    }
                }
            }


            //将标题合并
            if (ShowTitle)
            {
                IRow rowHead = sheet1.CreateRow(0);
                ICell cellHead = rowHead.CreateCell(firstColumn);
                cellHead.SetCellValue(Title);

                //样式设置
                IFont font = book.CreateFont();
                font.FontHeightInPoints = 14;
                //font.IsBold = true;

                ICellStyle style = book.CreateCellStyle();
                style.VerticalAlignment = VerticalAlignment.CENTER;
                style.Alignment = HorizontalAlignment.CENTER;
                style.SetFont(font);
                cellHead.CellStyle = style;

                rowHead.HeightInPoints = 20.25f;

                sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, firstColumn, lastColumn));
            }


            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            return ms;
        }
    }
}