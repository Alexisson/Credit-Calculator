using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalc
{
    
    public struct logging
    {
        public string date, type, sum, firstpay, percent, duration;

    }
    
    class Operations : Form1
    {
        public double crsum, fpay, sumup;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(862, 454);
            this.Name = "Operations";
            this.Load += new System.EventHandler(this.Operations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Operations_Load(object sender, EventArgs e)
        {

        }

        public void writeLog(string date, string type, string sum, string firstpay, string percent, string duration)
        {
            StreamWriter print = new StreamWriter("log.log", true);
            print.Write(date + ": " + type + ". Сумма: " + sum + ". Первоначальный взнос: " + firstpay + ". Процентная ставка: " + percent + ". Срок: " + duration + "\n");
            print.Close();
        }
        public void sumOfDay()
        {
            string datestring = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            Form1 f = new Form1();
            StreamWriter print = new StreamWriter("report.log", true);
            print.Write(datestring + ": Выданная сумма кредитов за сеанс: " + Convert.ToString(crsum) + ". Получено первоначальных взносов за сеанс: " + Convert.ToString(fpay) + ". Итого сумма кредитов за сеанс: " + Convert.ToString(sumup) + "\n");
            print.Close();
        }
    }
}
