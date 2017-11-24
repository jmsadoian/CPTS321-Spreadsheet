//Jacob Sadoian 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cpts321;

namespace Spreadsheet_SadoianJ
{
    public partial class Form1 : Form
    {
        private Spreadsheet sheet = new Spreadsheet(50, 26);
        public Form1()
        {
            InitializeComponent();
            
            
        }
        //Datagrid listens to this and calls when editing begins
        void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            SpreadSheet.Rows[row].Cells[column].Value = (sheet.GetCell(row, column)).Text;
        }
        //datagrid listens to this and call it when hitting enter or moving out of the cell
        void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            string text = "";
            Cell cell = sheet.GetCell(row, column); 

            try
            {
                text = SpreadSheet.Rows[row].Cells[column].Value.ToString();
            }
            catch(NullReferenceException)
            {
                text = "";
            }
            cell.Text = text;
            
        }
        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (cell != null && e.PropertyName == "Value")
            {
                SpreadSheet.Rows[cell.RowIndex].Cells[cell.ColIndex].Value = cell.Value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sheet.CellPropertyChanged += OnCellPropertyChanged; //have to subsribe to cell change event
            SpreadSheet.CellBeginEdit += CellBeginEdit;
            SpreadSheet.CellEndEdit += CellEndEdit;
            SpreadSheet.Columns.Clear();
            for(char i = 'A'; i <= 'Z'; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                
                column.Name = i.ToString();
                 
                SpreadSheet.Columns.Add(column);
            }
            SpreadSheet.Rows.Clear();
            SpreadSheet.Rows.Add(50);
            foreach(DataGridViewRow row in SpreadSheet.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
                
        }

        private void DemoButton_Click(object sender, EventArgs e)
        {
            sheet.Demo();
        }
    }
}
