namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HTMLRenderer.Contracts;

    public class Table : Element, ITable
    {
        private const string TableName = "table";
        private readonly IElement[,] tableData;

        private int rows;
        private int cols;

        public Table(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.tableData = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                Validate.LessThan<int>(value, 0, "Rows");
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                Validate.LessThan<int>(value, 0, "Cols");
                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.tableData[row, col];
            }

            set
            {
                this.tableData[row, col] = value;
            }
        }

        public override string TextContent
        {
            get
            {
                return null;
            }
            set
            {
                throw new ArgumentNullException("Table couldn't have content");
            }
        }

        public override void AddElement(IElement element)
        {
            throw new ArgumentException("Table couldn't have elemts");
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>");

            for (int r = 0; r < this.Rows; r++)
            {
                output.Append("<tr>");
                for (int c = 0; c < this.Cols; c++)
                {
                    output.Append("<td>");
                    this.tableData[r, c].Render(output);
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }

            output.Append("</table>");
        }
    }
}
