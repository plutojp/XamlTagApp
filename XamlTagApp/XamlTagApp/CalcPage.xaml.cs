using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTagApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalcPage : ContentPage
    {

        List<string> lStackInput = new List<string>();// stackNum
        List<string> lOperatorQueue = new List<string>();// stackNum

        string sStackSymbol = "";// stackNum
        int iNumCount = 0;

        //List<Double> rankAdd = new List<double>();
        //List<Double> rankAdd = new List<double>();


        public CalcPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnClickClear()
        {
            NumLabel.Text = "0";
            historyLabel.Text = "";
            sStackSymbol = "";
            lStackInput.Clear();
            lOperatorQueue.Clear();
            iNumCount = 0;

        }
        /// <summary>
        /// suu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnStack(object sender, EventArgs args)
        {
            //NumView.Text = "0";

            string history = historyLabel.Text;
            string onNum = NumLabel.Text;

            //キー判断
            string key = ((Button)sender).Text;
            string key2 = (string)((Button)sender).CommandParameter;
            string num = NumLabel.Text;
            int nCount = lStackInput.Count;


            string onKey = key2;
            if (iNumCount > 0)//連投チェック
            {
                onKey = num + key2;
                //最後の値を洗い替えする。
                lStackInput.RemoveAt(lStackInput.Count - 1);
                lStackInput.Add(onKey);

                NumLabel.Text = onKey;
            }
            else
            {
                NumLabel.Text = onKey;
                lStackInput.Add(key2);

                if (lOperatorQueue.Count > 0)
                {

                    foreach (string str in lOperatorQueue)
                    {
                        lStackInput.Add(str);
                    }
                }
            }
            iNumCount++;

        }
        /// <summary>
        /// 
        /// </summary>
        public void OnQueue(object sender, EventArgs args)
        {
            //NumView.Text = "0";

            string history = historyLabel.Text;
            string onNum = NumLabel.Text;

            //キー判断
            string key = ((Button)sender).Text;
            string key2 = (string)((Button)sender).CommandParameter;
            string num = NumLabel.Text;
            int nCount = lStackInput.Count;
            int nIndex = (nCount > 0) ? (nCount - 1) : 0;

            if (lOperatorQueue.Count == 0)
            {
                lOperatorQueue.Add(key2);
            }
            else
            {
                List<int> lRemoveAt = new List<int>();
                for (int i = 0; i < nCount; i++)
                {
                    string opt = lOperatorQueue[i];
                    //ひとつ前が演算子と判定する
                    if (CompareToOperator(opt, key2) == 0)
                    {
                        //入力が上位なので繰り上げ
                        lStackInput.Add(opt);
                        lOperatorQueue.RemoveAt(i);
                        //スタック
                        lOperatorQueue.Add(key2);
                        break;
                    }
                    else if (CompareToOperator(opt, key2) == -1)
                    {
                        lStackInput.Add(opt);
                        lRemoveAt.Add(i);
                        continue;
                    }
                    else
                    {

                    }



                    //if (CompareToOperator(lOperatorQueue.First(), key2) == 0)
                    //{
                    //    //下位のときは上位をスタック
                    //    lStackInput.Add(lOperatorQueue.First());
                    //    //上位の値を削除
                    //    string optNext = lOperatorQueue[i + 1];
                    //    if (CompareToOperator(optNext, key2) == 1)
                    //    {

                    //        lOperatorQueue[i] = key2;
                    //    }
                    //}
                    //else
                    //{
                    //    ////
                    //    //for (int i = 0; i < nCount; i++)
                    //    //{
                    //    //    string opt = lOperatorQueue[i];

                    //    //    if (CompareToOperator(opt, key2) == -1)//同位
                    //    //    {
                    //    //        //下位のときは上位をスタック
                    //    //        lStackInput.Add(opt);
                    //    //        //上位の値を削除
                    //    //        lOperatorQueue.RemoveAt(i);


                    //    //        if (i == (lOperatorQueue.Count - 1))
                    //    //        {
                    //    //            lOperatorQueue.Add(key2);
                    //    //        }
                    //    //        else
                    //    //        {
                    //    //            string optNext = lOperatorQueue[i + 1];
                    //    //            if (CompareToOperator(optNext, key2) == 1)
                    //    //            {

                    //    //                lOperatorQueue[i] = key2;
                    //    //            }
                    //    //        }
                    //    //        //lStackInput.F
                    //    //    }
                    //    //    else// 下位
                    //    //    {
                    //    //        lOperatorQueue.Add(key2);
                    //    //    }
                    //    //}
                }
                sStackSymbol = key2;
                iNumCount = 0;//数値入力の初期化
                historyLabel.Text = AddString(history, key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        private string AddString(string str, string str2)
        {
            return new StringBuilder(str).Append(" ").Append(str2).ToString().Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CalcProc(object sender, EventArgs args)
        {
            List<double> lNum = new List<double>();

            foreach (string em in lStackInput)
            {
                double dNum = 0;
                if (Double.TryParse(em, out dNum))
                {
                    lNum.Add(dNum);
                }
                else
                {
                    int lCount = lNum.Count;
                    int last = lCount - 1;
                    int oneBef = last - 2;
                    double num = lNum[oneBef];
                    double num2 = lNum[last];
                    //double ans = 0;

                    switch (em)
                    {
                        case "+":
                            double ans1 = (num + num2);

                            lNum.RemoveAt(last);//最後削除
                            lNum.Insert(oneBef, ans1);
                            break;
                        case "-":
                            double ans2 = (num - num2);

                            lNum.RemoveAt(last);//最後削除
                            lNum.Insert(oneBef, ans2);
                            break;
                        case "÷":
                            double ans3 = (num / num2);

                            lNum.RemoveAt(last);//最後削除
                            lNum.Insert(oneBef, ans3);
                            break;
                        case "X":
                            double ansX = (num * num2);

                            lNum.RemoveAt(last);//最後削除
                            lNum.Insert(oneBef, ansX);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 左側より右側が上位の時は、1を返す。同じの時は0、下位の時は-1を返す。
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>判定値[Boolean]</returns>
        private int CompareToOperator(string str1, string str2)
        {
            int ret = -1;
            switch (str1)
            {
                case "+":
                case "-":
                    //＋－より下位の演算子がない
                    if (Regex.IsMatch(str2, "[X÷]"))
                    {
                        ret = 1;
                    }
                    else
                    {
                        ret = 0;
                    }
                    break;
                default://X÷
                    //X÷より上位の演算子がない
                    if (Regex.IsMatch(str2, "[X÷]"))
                    {
                        ret = 0;
                    }
                    else
                    {
                        ret = -1;
                    }
                    break;
            }
            return ret;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private double StrCalc(string str)
        {
            double ret = 0;

            //Regex.Split()
            Regex re = new Regex(" +");
            string[] array = re.Split(str);
            //List<Double> rank = new List<double>();

            foreach (string em in array)
            {
                switch (em)
                {
                    case "+":
                        break;
                    case "-":
                        break;
                    case "X":
                        break;
                    case "÷":
                        break;
                    case ".":
                        lStackInput.Last();
                        break;
                    default:
                        break;
                }

            }

            return ret;

        }

    }
}
