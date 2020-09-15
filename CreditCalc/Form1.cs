using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCalc
{
    public partial class Form1 : Form
    {
        
        
        double creditsum, firstpay, percent, rez, monthsum;
        string datestring;
        int s = 0;
        double crsum, fpay, sumup;
        logging[] lg = new logging[100];
        private void CreditSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FirstPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PercentText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            creditSum.Text = "";
            firstPay.Text = "";
            percentText.Text = "";
            monthPay.Text = "";

            overpay.Text = "";
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            monthPay.Visible = false;
            overpay.Visible = false;
            dataGridView1.Visible = true;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(241, 45, 21);
            button1.ForeColor = Color.White;
        }

        private void Button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.FromArgb(241, 45, 21);
            button2.ForeColor = Color.White;
        }

        private void Button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.FromArgb(241, 45, 21);
            button3.ForeColor = Color.White;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.FromArgb(241, 45, 21);
            button2.BackColor = Color.White;
            button2.ForeColor = Color.FromArgb(241, 45, 21);
            button3.BackColor = Color.White;
            button3.ForeColor = Color.FromArgb(241, 45, 21);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            monthPay.Visible = true;
            overpay.Visible = true;
            dataGridView1.Visible = false;
        }
   
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.SelectedItem = 0;
            this.BackColor = Color.White;
            button1.BackColor = Color.White;
            button1.ForeColor = Color.FromArgb(241, 45, 21);
            button2.BackColor = Color.White;
            button2.ForeColor = Color.FromArgb(241, 45, 21);
            button3.BackColor = Color.White;
            button3.ForeColor = Color.FromArgb(241, 45, 21);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double diff;
            crsum += Convert.ToDouble(creditSum.Text);
            fpay += Convert.ToDouble(firstPay.Text);
            
            

            if ( creditSum.Text !="" || 
                firstPay.Text !="" || 
                percentText.Text != "" || 
                comboBox1.Text != "")
            {
                creditsum = Convert.ToDouble(creditSum.Text);
                firstpay = Convert.ToDouble(firstPay.Text);
                percent = Convert.ToDouble(percentText.Text);
                creditsum = creditsum - firstpay;
                var datenow = dateTimePicker1.Value;
                if (radioButton1.Checked == true)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            percent = percent / 100 / 12;
                            rez = creditsum * (percent + (percent / (Math.Pow((1 + percent), 12) - 1)));
                            monthPay.Text = Convert.ToString(Math.Round(rez, 2));
                            overpay.Text = Convert.ToString(Math.Round(12 * rez - creditsum, 1));
                            break;

                        case 1:
                            percent = percent / 100 / 12;
                            rez = creditsum * (percent + (percent / (Math.Pow((1 + percent), 24) - 1)));
                            monthPay.Text = Convert.ToString(Math.Round(rez, 2));
                            overpay.Text = Convert.ToString(Math.Round(24 * rez - creditsum, 1));
                            break;

                        case 2:
                            percent = percent / 100 / 12;
                            rez = creditsum * (percent + (percent / (Math.Pow((1 + percent), 36) - 1)));
                            monthPay.Text = Convert.ToString(Math.Round(rez, 2));
                            overpay.Text = Convert.ToString(Math.Round(36 * rez - creditsum, 1));
                            break;

                        case 3:
                            percent = percent / 100 / 12;
                            rez = creditsum * (percent + (percent / (Math.Pow((1 + percent), 48) - 1)));
                            monthPay.Text = Convert.ToString(Math.Round(rez, 2));
                            overpay.Text = Convert.ToString(Math.Round(48 * rez - creditsum, 1));
                            break;
                        case 4:
                            percent = percent / 100 / 12;
                            rez = creditsum * (percent + (percent / (Math.Pow((1 + percent), 60) - 1)));
                            monthPay.Text = Convert.ToString(Math.Round(rez, 2));
                            overpay.Text = Convert.ToString(Math.Round(60 * rez - creditsum, 1));
                            break;
                    }
                    datestring = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    lg[s].date = datestring;
                    lg[s].type = radioButton1.Text;
                    lg[s].sum = creditSum.Text;
                    lg[s].firstpay = firstPay.Text;
                    lg[s].percent = percentText.Text;
                    lg[s].duration = comboBox1.Text;
                    s++;
                }
                else
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            monthsum = creditsum / 12;
                            percent = percent / 100 / 12;
                            for (int i = 0; i <= 11; i++)
                            {
                                datenow = datenow.AddMonths(1);
                                datestring = datenow.ToString("d");
                                rez = monthsum + creditsum * percent;
                                int rowNumber = dataGridView1.Rows.Add();
                                creditsum = creditsum - rez;
                                dataGridView1.Rows[rowNumber].Cells["Column1"].Value = datestring;
                                dataGridView1.Rows[rowNumber].Cells["Column2"].Value = Math.Round(rez, 2);
                                dataGridView1.Rows[rowNumber].Cells["Column3"].Value = Math.Round(creditsum, 2);
                            }
                            break;
                        case 1:
                            monthsum = creditsum / 24;
                            percent = percent / 100 / 12;
                            for (int i = 0; i <= 23; i++)
                            {
                                datenow = datenow.AddMonths(1);
                                datestring = datenow.ToString("d");
                                rez = monthsum + creditsum * percent;
                                int rowNumber = dataGridView1.Rows.Add();
                                creditsum = creditsum - rez;
                                dataGridView1.Rows[rowNumber].Cells["Column1"].Value = datestring;
                                dataGridView1.Rows[rowNumber].Cells["Column2"].Value = Math.Round(rez, 2);
                                dataGridView1.Rows[rowNumber].Cells["Column3"].Value = Math.Round(creditsum, 2);
                            }
                            break;
                        case 2:
                            monthsum = creditsum / 36;
                            percent = percent / 100 / 12;
                            for (int i = 0; i <= 35; i++)
                            {
                                datenow = datenow.AddMonths(1);
                                datestring = datenow.ToString("d");
                                rez = monthsum + creditsum * percent;
                                int rowNumber = dataGridView1.Rows.Add();
                                creditsum = creditsum - rez;
                                dataGridView1.Rows[rowNumber].Cells["Column1"].Value = datestring;
                                dataGridView1.Rows[rowNumber].Cells["Column2"].Value = Math.Round(rez, 2);
                                dataGridView1.Rows[rowNumber].Cells["Column3"].Value = Math.Round(creditsum, 2);
                            }
                            break;
                        case 3:
                            monthsum = creditsum / 48;
                            percent = percent / 100 / 12;
                            for (int i = 0; i <= 47; i++)
                            {
                                datenow = datenow.AddMonths(1);
                                datestring = datenow.ToString("d");
                                rez = monthsum + creditsum * percent;
                                int rowNumber = dataGridView1.Rows.Add();
                                creditsum = creditsum - rez;
                                dataGridView1.Rows[rowNumber].Cells["Column1"].Value = datestring;
                                dataGridView1.Rows[rowNumber].Cells["Column2"].Value = Math.Round(rez, 2);
                                dataGridView1.Rows[rowNumber].Cells["Column3"].Value = Math.Round(creditsum, 2);
                            }
                            break;
                        case 4:
                            monthsum = creditsum / 60;
                            percent = percent / 100 / 12;
                            for (int i = 0; i <= 59; i++)
                            {
                                datenow = datenow.AddMonths(1);
                                datestring = datenow.ToString("d");
                                rez = monthsum + creditsum * percent;
                                int rowNumber = dataGridView1.Rows.Add();
                                creditsum = creditsum - rez;
                                dataGridView1.Rows[rowNumber].Cells["Column1"].Value = datestring;
                                dataGridView1.Rows[rowNumber].Cells["Column2"].Value = Math.Round(rez, 2);
                                dataGridView1.Rows[rowNumber].Cells["Column3"].Value = Math.Round(creditsum, 2);
                            }
                            break;
                    }
                    datestring = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    lg[s].date = datestring;
                    lg[s].type = radioButton2.Text;
                    lg[s].sum = creditSum.Text;
                    lg[s].firstpay = firstPay.Text;
                    lg[s].percent = percentText.Text;
                    lg[s].duration = comboBox1.Text;
                    s++;
                }

            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!","", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Operations op = new Operations();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sumup = crsum - fpay;
                op.sumup = sumup;
                op.fpay = fpay;
                op.crsum = crsum;
                op.sumOfDay();
                for(int i = 0; i<s; i++)
                {
                    op.writeLog(lg[i].date, lg[i].type, lg[i].sum, lg[i].firstpay, lg[i].percent, lg[i].duration);
                }

                this.Close();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
