using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Lab17_19
{
    public partial class Form1 : Form
    {
        static int size = 15;
        private readonly int[] A = new int[size];
        bool CheckQueue = false;
        private int Count = 0;
        private int varible = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 15;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 70;
            }
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowCount = 4;
            dataGridView2.ColumnCount = 15;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = 70;
            }
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = 15;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].Width = 70;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckQueue)
            {
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    A[i] = random.Next(10, 99);
                    fixup(A, i);
                    Count++;
                }
                PrintArray1(A);
                PrintArray2(A);
                CheckQueue = true;
            }
            else
            {
                MessageBox.Show("¬ы уже создали очередь!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Count != 0)
            {
                CheckQueue = Clear_Tab();
            }
            if (CheckQueue)
            {
                CheckQueue = Clear_Tab();
                CheckQueue = false;
            }
            else
            {
                MessageBox.Show("ќчередь уже очищена!");
            }
        }
        private bool PrintArray1(int[] array)
        {
            for (int l = 0; l < size; l++)
            {
                if (array[l] == 0)
                    dataGridView1.Rows[0].Cells[l].Value = "";
                else
                    dataGridView1.Rows[0].Cells[l].Value = array[l];

            }
            return true;
        }
        private void PrintArray2(int[] array)
        {
            int position = size / 2;//начальна€ позици€ в строке
            int i = 0, Rows = 0;//текуща€ строка в таблице
            int maxElemInRows = 1;//максимальное кол-во элементов в строке
            while (Rows < dataGridView2.RowCount)
            {
                int j = 0;//число элементов в текущей строке
                int firstElemInRows = position;//первый элемент в строке равен позиции элемента в строке
                while (maxElemInRows > j && i < size)
                {
                    if (array[i] == 0)
                        dataGridView2.Rows[Rows].Cells[firstElemInRows].Value = "";
                    else
                        dataGridView2.Rows[Rows].Cells[firstElemInRows].Value = array[i++];//вывод во вторую таблицу в виде дерева
                    firstElemInRows += position * 2 + 2;//переход на след позицию
                    j++;
                }
                position /= 2;//уменьшение рассто€ни€ в 2 раза
                maxElemInRows *= 2;//увеличение кол-ва элементов в строке
                Rows++;//переход на след строку
            }
        }
        private void PrintArray3(int value)
        {
            if (dataGridView3 != null && dataGridView3.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView3.Columns.Count; i++)
                {
                    if (dataGridView3.Rows[0].Cells[i].Value == null || dataGridView3.Rows[0].Cells[i].Value.ToString() == "")
                    {
                        dataGridView3.Rows[0].Cells[i].Value = value;
                        break;
                    }
                }
            }
            varible++;

        }
        private bool Clear_Tab()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    dataGridView2.Rows[i].Cells[j].Value = "";
            }
            dataGridView3.Rows.Clear();
            for (int i = 0; i < size; i++)
                A[i] = 0;
            Count = 0;
            varible = 0;
            return true;
        }
        public static void fixup(int[] array, int k)
        {
            while (k >= 1 && array[k / 2] < array[k])
            {
                int temp = array[k / 2];
                array[k / 2] = array[k];
                array[k] = temp;
                k /= 2;
            }
        }
        private void fixDown(int[] array, int k, int N)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j == 14)
                {
                    j--;
                }
                if (j < N && array[j] < array[j + 1]) j++;
                if (!(array[k] < array[j])) break;
                int temp = array[k];
                array[k] = array[j];
                array[j] = temp;
                k = j;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            if (!CheckQueue)
            {
                int value = (int)numericUpDown1.Value;
                for (i = 0; i < A.Length; i++)
                {
                    if (A[i] == 0)
                    {
                        A[i] = value;
                        fixup(A, i);
                        PrintArray1(A);
                        PrintArray2(A);
                        Count++;
                        return;
                    }
                }
                CheckQueue = true;
                if (i == 15)
                {
                    MessageBox.Show("¬ы заполнинил всю очередь!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("ћассив заполнен, добавить элемент невозможно");
                return;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int val = (int)numericUpDown2.Value;
            int valueTo = (int)numericUpDown3.Value;
            int index = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == val)
                {
                    index = i;
                    A[i] = valueTo;
                }
            }
            if (index < 0)
            {
                MessageBox.Show("«начение не найдено");
                return;
            }
            if (val > valueTo)
            {
                fixDown(A, index, size);
            }
            else
            {
                fixup(A, index);
            }
            PrintArray1(A);
            PrintArray2(A);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (varible == 15)
            {
                MessageBox.Show("ќчередь выборки заполнена. ќпераци€ отклонена");
                return;
            }
            if (Count == 0)
            {
                MessageBox.Show("ћассив пустой. ќпераци€ отклонена");
                return;
            }
            int value = A[0];
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] != 0)
                {
                    A[0] = A[i];
                    A[i] = 0;
                    Count--;
                    break;
                }
            }
            fixDown(A, 0, size);
            PrintArray1(A);
            PrintArray2(A);
            PrintArray3(value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}