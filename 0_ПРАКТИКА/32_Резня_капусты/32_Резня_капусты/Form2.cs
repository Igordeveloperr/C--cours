﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _32_Резня_капусты
{
    public partial class Form2 : Form
    {
        // все цвета
        private Dictionary<string, Color> _colors = new Dictionary<string, Color>()
        {
            { "Красный", Color.Red },
            { "Синий", Color.Blue },
            { "Желтый", Color.Yellow },
            { "Зеленый", Color.Green },
            { "Фиолетовый", Color.Purple },
            { "Голубой", Color.LightBlue },
            { "Розовый", Color.Pink },
            { "Коричневый", Color.Brown },
            { "Черный", Color.Black },
            { "Серебряный", Color.Silver },
            { "Золотой", Color.Gold },
            { "Ораньжевый", Color.Orange },
            { "Серый", Color.Gray },
            { "Малиновый", Color.Crimson },
            { "Белый", Color.White },
        };

        // цвета, которые уже выбраны
        public List<Color> _cacheColors = new List<Color>();
        // выбраная палитра
        public List<Color> colorRange { get; private set; }
        // ранее выбраные цвета
        public List<Color> prevColorRange { get; private set; }
        // список Combobox-ов
        private List<ComboBox> defList;

        public Form2()
         {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Setup();
            FillComboboxs(colorRange);
        }

        // отписываем комбобохи от события
        public void DescribeBoxs()
        {
            colorBox1.SelectedIndexChanged -= colorBox1_SelectedIndexChanged;
            colorBox2.SelectedIndexChanged -= colorBox2_SelectedIndexChanged;
            colorBox3.SelectedIndexChanged -= colorBox3_SelectedIndexChanged;
            colorBox4.SelectedIndexChanged -= colorBox4_SelectedIndexChanged;
            colorBox5.SelectedIndexChanged -= colorBox5_SelectedIndexChanged;
            colorBox6.SelectedIndexChanged -= colorBox6_SelectedIndexChanged;
            colorBox7.SelectedIndexChanged -= colorBox7_SelectedIndexChanged;
            colorBox8.SelectedIndexChanged -= colorBox8_SelectedIndexChanged;
            colorBox9.SelectedIndexChanged -= colorBox9_SelectedIndexChanged;
            colorBox10.SelectedIndexChanged -= colorBox10_SelectedIndexChanged;
        }

        // подписываем комбобохи на события
        public void SubscribeBoxs()
        {
            colorBox1.SelectedIndexChanged += colorBox1_SelectedIndexChanged;
            colorBox2.SelectedIndexChanged += colorBox2_SelectedIndexChanged;
            colorBox3.SelectedIndexChanged += colorBox3_SelectedIndexChanged;
            colorBox4.SelectedIndexChanged += colorBox4_SelectedIndexChanged;
            colorBox5.SelectedIndexChanged += colorBox5_SelectedIndexChanged;
            colorBox6.SelectedIndexChanged += colorBox6_SelectedIndexChanged;
            colorBox7.SelectedIndexChanged += colorBox7_SelectedIndexChanged;
            colorBox8.SelectedIndexChanged += colorBox8_SelectedIndexChanged;
            colorBox9.SelectedIndexChanged += colorBox9_SelectedIndexChanged;
            colorBox10.SelectedIndexChanged += colorBox10_SelectedIndexChanged;
        }

        // начальные настройки
        private void Setup()
        {
            colorRange = new List<Color>
            {
                Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Purple,
                Color.LightBlue, Color.Pink, Color.Brown, Color.Black, Color.Silver
            };

            prevColorRange = new List<Color>
            {
                Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Purple,
                Color.LightBlue, Color.Pink, Color.Brown, Color.Black, Color.Silver
            };

            defList = new List<ComboBox>()
            {
                colorBox1, colorBox2, colorBox3, colorBox4, colorBox5,
                colorBox6, colorBox7, colorBox8, colorBox9, colorBox10
            };
        }

        // сохранение ранее заданных цветов
        private void SavePrevColors()
        {
            for (int i = 0; i < prevColorRange.Count; i++)
            {
                prevColorRange[i] = colorRange[i];
            }
        }

        // вывод цветов в комбобохи
        public void FillComboboxs(List<Color> arr)
        {
            for(int i = 0; i < arr.Count; i++)
            {
                defList[i].Text = ConvertColorInName(arr[i]);
            }
        }

        // по цвету находим его название
        private string ConvertColorInName(Color color)
        {
            string res = string.Empty;
            foreach(var item in _colors)
            {
                if (item.Value == color)
                {
                    res = item.Key;
                }
            }
            return res;
        }

        // обработка полей для выбора цвета
        private void SelectColor(ComboBox sender)
        {
            var prevColorText = ConvertColorInName(colorRange[Convert.ToInt32(sender.Tag)]);
            
            if(sender.Text != string.Empty)
            {
                Color color = _colors[sender.Text];
                if (!colorRange.Contains(color) && _cacheColors.Contains(color))
                {
                    _cacheColors.Remove(color);
                }

                if (_cacheColors.Contains(color))
                {
                    MessageBox.Show("Такой цвет уже выбран!");
                    DescribeBoxs();
                    sender.Text = prevColorText;
                    SubscribeBoxs();
                }
                else
                {
                    _cacheColors.Add(color);
                    int index = Convert.ToInt32(sender.Tag);
                    colorRange[index] = color;
                }
            }
        }

        // клик по кнопе ОК
        private void okBtn_Click(object sender, EventArgs e)
        {
            bool allBoxSetts = true;
            foreach(var box in defList)
            {
                if(box.Text == string.Empty)
                {
                    allBoxSetts = false;
                    break;
                }
            }

            if(allBoxSetts)
            {
                SavePrevColors();
                Hide();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        // клик по кнопке Отмена
        private void noBtn_Click(object sender, EventArgs e)
        {
            FillComboboxs(prevColorRange);
            Hide();
        }

        private void colorBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox)sender);
        }

        private void colorBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectColor((ComboBox) sender);
        }
    }
}
