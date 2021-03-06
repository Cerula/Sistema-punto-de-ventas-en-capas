using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;
using ViewModels.Library;

namespace Sistema_punto_de_ventas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /**************************************
        *                                    *
        *       CODIGO DEL CLIENTE           * 
        *                                    *
        **************************************/
        #region
        private ClientesVM clientes;
        private void ButtonCliente_Click(object sender, EventArgs e)
        {
            var textBoxCliente = new List<TextBox>();
            textBoxCliente.Add(textBoxCliente_Nid);
            textBoxCliente.Add(textBoxCliente_Nombre);
            textBoxCliente.Add(textBoxCliente_Apellido);
            textBoxCliente.Add(textBoxCliente_Email);
            textBoxCliente.Add(textBoxCliente_Telefono);
            textBoxCliente.Add(textBoxCliente_Direccion);
            

            var labelCliente = new List<Label>();
            labelCliente.Add(labelCliente_Nid);
            labelCliente.Add(labelCliente_Nombre);
            labelCliente.Add(labelCliente_Apellido);
            labelCliente.Add(labelCliente_Email);
            labelCliente.Add(labelCliente_Telefono);
            labelCliente.Add(labelCliente_Direccion);
            labelCliente.Add(label_PaginasCliente);

            object[] objectos = {
                PictureBoxCliente,
                  checkBoxCliente_Credito,
                  Properties.Resources.logo_google, //colocar otra foto
                  dataGridView_Clientes,
                   numeric_PaginasCliente

            };
            clientes = new ClientesVM(objectos, textBoxCliente, labelCliente);
            // el numero 1 llama al tabclientes desde el boton
            tabControlPrincipal.SelectedIndex = 1;

        }

        private void PictureBoxCliente_Click(object sender, EventArgs e)
        {
            Objects.uploadimage.CargarImagen(PictureBoxCliente);
        }
        private void TextBoxCliente_Nid_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Nid.Text.Equals(""))
            {
                labelCliente_Nid.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Nid.Text = "Nid";
                labelCliente_Nid.ForeColor = Color.Green;
            }
        }

        private void TextBoxCliente_Nid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.numberKeyPress(e);
        }
        private void TextBoxCliente_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Nombre.Text.Equals(""))
            {
                labelCliente_Nombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Nombre.Text = "Nombre";
                labelCliente_Nombre.ForeColor = Color.Green;
            }
        }

        private void TextBoxCliente_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void TextBoxCliente_Apellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Apellido.Text.Equals(""))
            {
                labelCliente_Apellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Apellido.Text = "Apellido";
                labelCliente_Apellido.ForeColor = Color.Green;
            }
        }

        private void TextBoxCliente_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void TextBoxCliente_Email_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Email.Text.Equals(""))
            {
                labelCliente_Email.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Email.Text = "Email";
                labelCliente_Email.ForeColor = Color.Green;
            }
        }

        private void TextBoxCliente_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Telefono.Text.Equals(""))
            {
                labelCliente_Telefono.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Telefono.Text = "Telefono";
                labelCliente_Telefono.ForeColor = Color.Green;
            }
        }

        private void TextBoxCliente_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.numberKeyPress(e);
        }

        private void TextBoxCliente_Direccion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Direccion.Text.Equals(""))
            {
                labelCliente_Direccion.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Direccion.Text = "Direccion";
                labelCliente_Direccion.ForeColor = Color.Green;
            }
        }

        private void ButtonCliente_Agregar_Click(object sender, EventArgs e)
        {
            clientes.guardarCliente();
        }

        private void ButtonCliente_Cancelar_Click(object sender, EventArgs e)
        {
            clientes.restablecer(); //limpia los campos
        }

        private void dataGridView_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Clientes.Rows.Count != 0) // vincula los campos con el data grie wiew cuando hacemos click en el datagriewiev
                clientes.GetCliente();   // cuando es distintos a 0 , tiene columna con datos y llena los campos
        }

        private void dataGridView_Clientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView_Clientes.Rows.Count != 0)
                clientes.GetCliente();
        }


       

        private void buttonCliente_Pagina1_Click(object sender, EventArgs e)
        {
            clientes.Paginador("Primero");
        }

        private void buttonCliente_Pagina2_Click(object sender, EventArgs e)
        {
            clientes.Paginador("Anterior");
        }

        private void buttonCliente_Pagina3_Click(object sender, EventArgs e)
        {
            clientes.Paginador("Siguiente");
        }

        private void buttonCliente_Pagina4_Click(object sender, EventArgs e)
        {
            clientes.Paginador("Ultimo");
        }
        

        private void numeric_PaginasCliente_ValueChanged(object sender, EventArgs e)
        {

            clientes.Registro_Paginas();
        }


        private void textBoxCliente_Buscar_TextChanged(object sender, EventArgs e)
        {
            clientes.SearchClientes(textBoxCliente_Buscar.Text);
        }

        

        private void tabControlCliente1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlCliente1.SelectedIndex) // se sellecciona pagos y reportes y pagos y reportes del tab 1 y 2
            {
                case 0:
                    tabControlCliente2.SelectedIndex = 0;
                    break;
                case 1:
                    tabControlCliente2.SelectedIndex = 1;
                    break;
            }


        }

        private void tabControlCliente2_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabControlCliente2.SelectedIndex) // se selecciona lista cliente// registro cliente
            {
                case 0:
                    tabControlCliente1.SelectedIndex = 0;
                    break;
                case 1:
                    tabControlCliente1.SelectedIndex = 1;
                    break;
            }


        }
        #endregion
    }
}
