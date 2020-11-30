using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using System.Collections.ObjectModel;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;
            this.sfDataGrid1.CellRenderers["CheckBox"] = new CustomCheckBoxCellRenderer();
        }
    }

    public class CustomCheckBoxCellRenderer : GridCheckBoxCellRenderer
    {
        protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            if (column.GridColumn.MappingName == "IsClosed")
            {
                DataRowBase dataRow = (DataRowBase)column.GetType().GetProperty("DataRow", System.Reflection.BindingFlags.Instance | 
                    System.Reflection.BindingFlags.NonPublic).GetValue(column);

                if ((dataRow.RowData as OrderInfo).Quantity > 50)
                    paint.FillRectangle(new SolidBrush(style.BackColor), cellRect);
                else
                    base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
            }
        }
    }
}
