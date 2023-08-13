﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class TodoMatrix
    {
        private readonly Dictionary<string, TodoQuarter> TodoQuarters;

        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>()
            {
                {"IU",new TodoQuarter()},
                {"IN",new TodoQuarter()},
                {"NU",new TodoQuarter()},
                {"NN",new TodoQuarter()},
            };

        }
        private Dictionary<string, TodoQuarter> GetTodoQuarters() { return TodoQuarters; }

        public TodoQuarter GetTodoQuarter(string status)
        {
            return TodoQuarters[status];
        }
        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            string status;
            DateTime startDate = DateTime.Now;
            double days = (deadline - startDate).TotalDays;
            if (isImportant)
            {
                status = days > 3 ? "IN" : "IU";
            }
            else
            {
                status = days > 3 ? "NN" : "NU";

            }
            TodoQuarter quarter = GetTodoQuarter(status);
            quarter.AddItem(title, deadline);
        }
        public void AddItem(string title, DateTime deadline)
        {
            string status;
            DateTime startDate = DateTime.Now;
            double days = (deadline - startDate).TotalDays;
            status = days > 3 ? "NN" : "NU";
            TodoQuarter quarter = GetTodoQuarter(status);
            quarter.AddItem(title, deadline);

        }

        public void ArchiveItems()
        {
            foreach (string key in TodoQuarters.Keys)
            {
                GetTodoQuarter(key).ArchiveItems();
            }
        }

        public override string ToString()
        {

            string iuList = GetTodoQuarter("IU").ToString();
            string inList = GetTodoQuarter("IN").ToString();
            string nuList = GetTodoQuarter("NU").ToString();
            string nnList = GetTodoQuarter("NN").ToString();

            string[] iuLines = iuList.Split('\n');
            string[] inLines = inList.Split('\n');
            string[] nuLines = nuList.Split('\n');
            string[] nnLines = nnList.Split('\n');

            int maxLines = Math.Max(
                iuLines.Length, Math.Max(inLines.Length, Math.Max(nuLines.Length, nnLines.Length)));

            StringBuilder matrixBuilder = new StringBuilder();

            matrixBuilder.AppendLine(
                "    |            URGENT              |           NOT URGENT           |  ");
            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            for (int i = 0; i < maxLines; i++)
            {
                matrixBuilder.Append("    | ");

                if (i < iuLines.Length)
                    matrixBuilder.Append(iuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                                ");

                matrixBuilder.Append("| ");

                if (i < inLines.Length)
                    matrixBuilder.Append(inLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                                ");

                matrixBuilder.AppendLine("|");

                if (i == 1 || i == iuLines.Length - 1)
                {
                    matrixBuilder.AppendLine(
                        "  I |--------------------------------|--------------------------------|  ");
                }
            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            for (int i = 0; i < maxLines; i++)
            {
                matrixBuilder.Append("    | ");

                if (i < nuLines.Length)
                    matrixBuilder.Append(nuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                                ");

                matrixBuilder.Append("| ");

                if (i < nnLines.Length)
                    matrixBuilder.Append(nnLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                                ");

                matrixBuilder.AppendLine("|");
            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            return matrixBuilder.ToString();
        }
    }
}