﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenhowerMain.Enums;

namespace EisenhowerMain
{
    internal class TodoMatrix
    {
        private readonly Dictionary<string, TodoQuarter> TodoQuarters;
        public QuartersName ActiveQuarterName = QuartersName.IU;


        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>();
            foreach (QuartersName quarter in Enum.GetValues(typeof(QuartersName)))
            {
                TodoQuarters.Add(quarter.ToString(), new TodoQuarter());
            }


        }
        private Dictionary<string, TodoQuarter> GetTodoQuarters() { return TodoQuarters; }

        public TodoQuarter GetTodoQuarter(string status)
        {
            return TodoQuarters[status];
        }
        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            string status;
            double days = (deadline - DateTime.Now).TotalDays;
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
            double days = (deadline - DateTime.Now).TotalDays;
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

        public void ChangeActiveQuarter()
        {
            if ((int)ActiveQuarterName < 3)
            {
                ActiveQuarterName++;
            }
            else
            {
                ActiveQuarterName = 0;
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
                matrixBuilder.Append("I   | ");

                if (i < iuLines.Length)
                    matrixBuilder.Append(iuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                             ");

                matrixBuilder.Append("| ");

                if (i < inLines.Length)
                    matrixBuilder.Append(inLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                            ");

                matrixBuilder.AppendLine("|");


            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            for (int i = 0; i < maxLines; i++)
            {
                matrixBuilder.Append("NI  | ");

                if (i < nuLines.Length)
                    matrixBuilder.Append(nuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                              ");

                matrixBuilder.Append("| ");

                if (i < nnLines.Length)
                    matrixBuilder.Append(nnLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                             ");

                matrixBuilder.AppendLine("|");
            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            return matrixBuilder.ToString();
        }
    }
}