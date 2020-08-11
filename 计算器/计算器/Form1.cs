using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        delegate void calculator(double a, double b);
        public string StrNumber1="";
        public string StrNumber2= "";

        public enum operationmethod
        {
            None=0,
            Add=1,
            Sub=2,
            Mul=3,
            Dvi=4
        }

        private operationmethod currentmethod;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.BTShow.Text = "";
            StrNumber1 = "";
        }
        private void Number_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            BTShow.Text += b.Text;
        }
        private void Operation_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            var str = b.Text;
            switch(str)
            {
                case "+":
                    currentmethod = operationmethod.Add;
                    break;
                case "-":
                    currentmethod = operationmethod.Sub;
                    break;
                case "*":
                    currentmethod = operationmethod.Mul;
                    break;
                case "/":
                    currentmethod = operationmethod.Dvi;
                    break;
            }
            StrNumber1 = BTShow.Text;
            BTShow.Text = "";
        }

        private void btnoutcome_Click(object sender, EventArgs e)
        {
            Evaluate();
        }
        private void Evaluate()
        {
            CalOper Oper=null;
            double dbl = 0;
            switch (currentmethod)
            {
               
                case operationmethod.Add:
                    Oper = new OperationAdd();
                    Oper.NumberA = System.Convert.ToDouble(StrNumber1);
                    Oper.NumberB= System.Convert.ToDouble(BTShow.Text);
                    dbl = Oper.GetResult();
                    BTShow.Text = System.Convert.ToString(dbl);
                    break;
                case operationmethod.Sub:
                    Oper = new OperationSub();
                    Oper.NumberA = System.Convert.ToDouble(StrNumber1);
                    Oper.NumberB = System.Convert.ToDouble(BTShow.Text);
                    dbl = Oper.GetResult();
                    BTShow.Text = System.Convert.ToString(dbl);
                    break;
                case operationmethod.Mul:
                    Oper = new OperationMul();
                    Oper.NumberA = System.Convert.ToDouble(StrNumber1);
                    Oper.NumberB = System.Convert.ToDouble(BTShow.Text);
                    dbl = Oper.GetResult();
                    BTShow.Text = System.Convert.ToString(dbl);
                    break;
                case operationmethod.Dvi:
                    Oper = new OperationDvi();
                    Oper.NumberA = System.Convert.ToDouble(StrNumber1);
                    Oper.NumberB = System.Convert.ToDouble(BTShow.Text);
                    dbl = Oper.GetResult();
                    BTShow.Text = System.Convert.ToString(dbl);
                    break;
            }
        }
    }

    public class CalOper
    {
        private double _numberA = 0;
        private double _numberB = 0;
        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }
        public double NumberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }
       
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }

    //加法运算
    public class OperationAdd:CalOper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }
    //减法运算
    public class OperationSub : CalOper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }
    //乘法运算
    public class OperationMul : CalOper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
    //除法运算
    public class OperationDvi : CalOper
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA / NumberB;
            return result;
        }
    }
}
