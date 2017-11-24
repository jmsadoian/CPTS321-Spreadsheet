using System;
using System.ComponentModel;
namespace Cpts321
{
    public abstract class Cell : INotifyPropertyChanged
    {
        protected int rowIndex;
        protected int columnIndex;
        protected string text;
        protected string value;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Cell()
        {

        }

        public int RowIndex { get { return this.rowIndex; } protected set { this.rowIndex = value; } }
        public int ColIndex { get { return this.columnIndex; } protected set { this.columnIndex = value; } }
            

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value == text)
                {
                    return;
                }
                else
                {
                    text = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        public string Value
        {
            get { return this.value; }
            protected internal set
            {
                if (value == this.value)
                    return;
                else
                {
                    this.value = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }


        /*protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }*/




    }
    public class CellImp : Cell
    {
        public CellImp(int rows, int col, string text)
        {
            rowIndex = rows;
            columnIndex = col;
            this.text = text;
            value = text;

        }
    } 
    public class Spreadsheet
    {
        private int rowCount, columnCount;
        protected Cell[,] spreadsheet;
        public event PropertyChangedEventHandler CellPropertyChanged;

        public Spreadsheet(int rows, int col)
        {
            this.rowCount = rows;
            this.columnCount = col;
            spreadsheet = new Cell[rows, col];

            for (int r = 0; r < rows; r++) //to allocate each row
            {
                for (int c = 0; c < col; c++) //to allocate each column in each row
                {
                    spreadsheet[r, c] = new CellImp(r, c, "");
                    spreadsheet[r, c].PropertyChanged += OnPropertyChanged;
                }
            }

        }
        public Cell GetCell(int rIn, int cIn)
        {
            
            if (rIn > spreadsheet.GetLength(0) || cIn > spreadsheet.GetLength(1))
                return null;
            else
                return spreadsheet[rIn, cIn];
        }
        public int CoulumnCount
        {
            get
            {
                return rowCount;
            }

        }
        public int RowCount
        {
            get
            {
                return columnCount;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Text")
            {
                if(!((Cell)sender).Text.StartsWith("="))
                {
                    ((Cell)sender).Value = ((Cell)sender).Text;
                    
                }
                else
                {
                   
                    string formula = ((Cell)sender).Text.Substring(1);
                    int column = Convert.ToInt16(formula[0]) - 'A';
                    int row = Convert.ToInt16(formula.Substring(1)) - 1;
                    ((Cell)sender).Value = (GetCell(row, column)).Value;
                }

            }
            CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
        }

        public void Demo()
        {
            int i = 0;
            Random rand = new Random();

            while(i<50)
            {
                int randomCol = rand.Next(0, 25);
                int randomRow = rand.Next(0, 49);

                Cell toFill = GetCell(randomRow, randomCol);
                toFill.Text = "Hi there!";
                this.spreadsheet[randomRow, randomCol] = toFill;
                i++;
            }
            for(i = 0; i < 50; i++)
            {
                this.spreadsheet[i, 1].Text = "This is cell B" + (i + 1);
            }
            for(i = 0; i < 50; i++)
            {
                this.spreadsheet[i, 0].Text = "=B" + (i + 1);
            }

        }

    }

}
