using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calpilares
{
    public enum operacion
    {
        noDefin = 0,
        suma = 1,
        resta = 2,
        multiplicacion = 3,
        divicion = 4,
        porciento = 5,
    }
    public partial class Calculadora : Form
    {
        double valor = 0;
        double valor1 = 0;
        operacion operador = operacion.noDefin;
        bool numNolei = false;
        public Calculadora()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numNolei = true;
            if (Resultado.Text == "0")
            {
                return;
            }
            else
            {
                Resultado.Text += "0";
            }
        }

        private void btnp_Click(object sender, EventArgs e)
        {
            if (Resultado.Text.Contains("."))
            {
                return;
            }
            Resultado.Text += ".";
        }

        private void btnporci_Click(object sender, EventArgs e)
        {
            operador = operacion.resta;
            obtenerValor("%");
        }
        private void ReadNum(string Numero)
        {
            numNolei = true;
            if (Resultado.Text == "0" && Resultado.Text != null)
            {
                Resultado.Text = Numero;
            }
            else
            {
                Resultado.Text += Numero;
            }
        }
        private double EjecutarOpe()
        {
            double resultado = 0;
            switch (operador)
            {
                case operacion.suma:
                    resultado = valor + valor1;
                    break;
                case operacion.resta:
                    resultado = valor - valor1;
                    break;
                case operacion.multiplicacion:
                    resultado = valor * valor1;
                    break;
                case operacion.divicion:
                    if (valor1 == 0)
                    {
                        MessageBox.Show("No se puede dividir entre cero");
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor / valor1;
                    }
                    break;
                case operacion.porciento:
                    resultado = valor % valor1;
                    break;
            }
            return resultado;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ReadNum("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ReadNum("2");

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ReadNum("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ReadNum("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ReadNum("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ReadNum("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ReadNum("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ReadNum("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ReadNum("9");
        }
        private void obtenerValor(string operador)
        {
            valor = Convert.ToDouble(Resultado.Text);
            lbl1.Text = Resultado.Text + operador;
            Resultado.Text = "0";
        }

        private void btnsu_Click(object sender, EventArgs e)
        {
            operador = operacion.suma;
            obtenerValor("+");
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            if (valor1 == 0 && numNolei)
            {
                valor1 = Convert.ToDouble(Resultado.Text);
                lbl1.Text += valor1 + "=";
                double btnigual = EjecutarOpe();
                valor = 0;
                valor1 = 0;
                numNolei = false;
                Resultado.Text = Convert.ToString(btnigual);
            }
        }

        private void btnme_Click(object sender, EventArgs e)
        {
            operador = operacion.resta;
            obtenerValor("-");
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            operador = operacion.multiplicacion;
            obtenerValor("*");
        }

        private void btndivi_Click(object sender, EventArgs e)
        {
            operador = operacion.divicion;
            obtenerValor("/");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            Resultado.Text = "0";
            lbl1.Text = "";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Resultado.Text.Length > 1)
            {
                String txtResultado = Resultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if(txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    Resultado.Text = txtResultado;
                }

                Resultado.Text = txtResultado;
            }
            else
            {
                Resultado.Text = "0";
            }

        }
    }

}

