using LinqToDB;
using Models;
using Models.Conexion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels.Library;

namespace ViewModels
{
    public class ClientesVM : Conexion
    {
        private List<TextBox> _textBoxCliente;
        private List<Label> _labelCliente;
        private TextBoxEvent evento;
        private string _accion = "insert";
        private PictureBox _imagePictureBox;
        private CheckBox _checkBoxCredito;
        private Bitmap _imagBitmap;
        private static DataGridView _dataGridView1;
        private NumericUpDown _numericUpDown;
        private Paginador<TClientes> _paginadorClientes;
        private int _reg_por_pagina = 10, _num_pagina = 1;


        public ClientesVM(object[] objectos, List<TextBox> textBoxCliente, List<Label> labelCliente)
        {
            // aca se inisializan los objetos declarados arriba en public class ClientesVM : Conexion
            _textBoxCliente = textBoxCliente;
            _labelCliente = labelCliente;
            _imagePictureBox = (PictureBox)objectos[0];
            _checkBoxCredito = (CheckBox)objectos[1];
            _imagBitmap = (Bitmap)objectos[2]; // procedimiento para restablecer nuestros controles
            _dataGridView1 = (DataGridView)objectos[3];
            _numericUpDown = (NumericUpDown)objectos[4];
            evento = new TextBoxEvent();

            restablecer(); // cada vez que ejecutemos viewmodels restableceremos los controles
        }
        public void guardarCliente()
        {
            if (_textBoxCliente[0].Text.Equals(""))
            {
                _labelCliente[0].Text = "Este campo es requerido";
                _labelCliente[0].ForeColor = Color.Red;
                _textBoxCliente[0].Focus();
            }
            else
            {
                if (_textBoxCliente[1].Text.Equals(""))
                {
                    _labelCliente[1].Text = "Este campo es requerido";
                    _labelCliente[1].ForeColor = Color.Red;
                    _textBoxCliente[1].Focus();
                }
                else
                {
                    if (_textBoxCliente[2].Text.Equals(""))
                    {
                        _labelCliente[2].Text = "Este campo es requerido";
                        _labelCliente[2].ForeColor = Color.Red;
                        _textBoxCliente[2].Focus();
                    }
                    else
                    {
                        if (_textBoxCliente[3].Text.Equals(""))
                        {
                            _labelCliente[3].Text = "Este campo es requerido";
                            _labelCliente[3].ForeColor = Color.Red;
                            _textBoxCliente[3].Focus();
                        }
                        else
                        {
                            if (evento.comprobarFormatoEmail(_textBoxCliente[3].Text))
                            {
                                if (_textBoxCliente[4].Text.Equals(""))
                                {
                                    _labelCliente[4].Text = "Este campo es requerido";
                                    _labelCliente[4].ForeColor = Color.Red;
                                    _textBoxCliente[4].Focus();
                                }
                                else
                                {
                                    if (_textBoxCliente[5].Text.Equals(""))
                                    {
                                        _labelCliente[5].Text = "Este campo es requerido";
                                        _labelCliente[5].ForeColor = Color.Red;
                                        _textBoxCliente[5].Focus();
                                    }
                                    else
                                    {   
                                        var cliente1 = TClientes.Where(p => p.Nid.Equals(_textBoxCliente[0].Text)).ToList();
                                        var cliente2 = TClientes.Where(p => p.Email.Equals(_textBoxCliente[3].Text)).ToList();
                                        var list = cliente1.Union(cliente2).ToList();
                                        switch (_accion)
                                        {
                                            case "insert":
                                                if (list.Count.Equals(0))
                                                {
                                                    SaveData();
                                                }
                                                else
                                                { // aqui se valida que no se repita el dni o el correo 
                                                    if (0 < cliente1.Count)
                                                    {
                                                        _labelCliente[0].Text = "El nid ya esta registrado";
                                                        _labelCliente[0].ForeColor = Color.Red;
                                                        _textBoxCliente[0].Focus();
                                                    }
                                                    if (0 < cliente2.Count)
                                                    {
                                                        _labelCliente[3].Text = "El email ya esta registrado";
                                                        _labelCliente[3].ForeColor = Color.Red;
                                                        _textBoxCliente[3].Focus();
                                                    }
                                                }
                                                break;

                                            case "update": //yt#24
                                                if (list.Count.Equals(2))
                                                {
                                                    if (cliente1[0].ID.Equals(_idCliente) &&
                                                   cliente2[0].ID.Equals(_idCliente))
                                                    {
                                                        SaveData();
                                                    }
                                                    else
                                                    {
                                                        if (cliente1[0].ID != _idCliente)
                                                        {
                                                            _labelCliente[0].Text = "El nid ya esta registrado";
                                                            _labelCliente[0].ForeColor = Color.Red;
                                                            _textBoxCliente[0].Focus();
                                                        }
                                                        if (cliente2[0].ID != _idCliente)
                                                        {
                                                            _labelCliente[3].Text = "El email ya esta registrado";
                                                            _labelCliente[3].ForeColor = Color.Red;
                                                            _textBoxCliente[3].Focus();
                                                        }
                                                    }
                                                }

                                                {
                                                    if (list.Count.Equals(0))
                                                    {
                                                        SaveData();
                                                    }
                                                    else
                                                    {
                                                        if (0 != cliente1.Count)
                                                        {
                                                            if (cliente1[0].ID.Equals(_idCliente))
                                                            {
                                                                SaveData();
                                                            }
                                                            else
                                                            {
                                                                if (cliente1[0].ID != _idCliente)
                                                                {
                                                                    _labelCliente[0].Text = "El nid ya esta registrado";
                                                                    _labelCliente[0].ForeColor = Color.Red;
                                                                    _textBoxCliente[0].Focus();
                                                                }
                                                            }
                                                        }
                                                        if (0 != cliente2.Count)
                                                        {

                                                            if (cliente2[0].ID.Equals(_idCliente))
                                                            {
                                                                SaveData();
                                                            }
                                                            else
                                                            {
                                                                if (cliente2[0].ID != _idCliente)
                                                                {
                                                                    _labelCliente[3].Text = "El email ya esta registrado";
                                                                    _labelCliente[3].ForeColor = Color.Red;
                                                                    _textBoxCliente[3].Focus();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                break;

                                        }
                                    }
                                }
                            }
                            else
                            {
                                _labelCliente[3].Text = "Email invalido";
                                _labelCliente[3].ForeColor = Color.Red;
                                _textBoxCliente[3].Focus();
                            }
                            
                        }
                    }
                }
            }
        }
        private void SaveData()
        {
            BeginTransactionAsync();
            try
            {
                var srcImage = Objects.uploadimage.ResizeImage(_imagePictureBox.Image, 165, 100);
                var image = Objects.uploadimage.ImageToByte(srcImage);
                switch (_accion)
                {
                    case "insert":
                        TClientes.Value(c => c.Nid, _textBoxCliente[0].Text)
                          .Value(u => u.Nombre, _textBoxCliente[1].Text)
                          .Value(u => u.Apellido, _textBoxCliente[2].Text)
                          .Value(u => u.Email, _textBoxCliente[3].Text)
                          .Value(u => u.Telefono, _textBoxCliente[4].Text)
                          .Value(u => u.Direccion, _textBoxCliente[5].Text)
                          .Value(u => u.Credito, _checkBoxCredito.Checked)
                          .Value(u => u.Fecha, DateTime.Now.ToString("dd/MMM/yyy"))
                          .Value(u => u.Imagen, image)
                          .Insert();

                        // last es para obtener el ultimo item de esa coleccion
                        var cliente = TClientes.ToList().Last();

                        TReportes_clientes.Value(u => u.UltimoPago, 0)
                                  .Value(u => u.FechaPago, "--/--/--")
                                  .Value(u => u.DeudaActual, 0)
                                  .Value(u => u.FechaDeuda, "--/--/--")
                                  .Value(u => u.Ticket, "0000000000")
                                  .Value(u => u.FechaLimite, "--/--/--")
                                  .Value(u => u.IdCliente, cliente.ID)// aqui se inserta el id cliente en la tabla treportclientes
                                  .Insert();
                        break;
                        //yt24# 18:23
                    case "update"://#yt25
                        TClientes.Where(u => u.ID.Equals(_idCliente))
                         .Set(u => u.Nid, _textBoxCliente[0].Text)
                         .Set(u => u.Nombre, _textBoxCliente[1].Text)
                         .Set(u => u.Apellido, _textBoxCliente[2].Text)
                         .Set(u => u.Email, _textBoxCliente[3].Text)
                         .Set(u => u.Telefono, _textBoxCliente[4].Text)
                         .Set(u => u.Direccion, _textBoxCliente[5].Text)
                         .Set(u => u.Credito, _checkBoxCredito.Checked)
                         .Set(u => u.Imagen, image)
                         .Update();

                        break;


                }
                CommitTransaction();
                restablecer();
            }
            catch (Exception ex)
            {

                RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }
        public void SearchClientes(string campo)
        {
            List<TClientes> query = new List<TClientes>();
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = TClientes.ToList();
            }
            else
            {
                query = TClientes.Where(c => c.Nid.StartsWith(campo) || c.Nombre.StartsWith(campo)
               || c.Apellido.StartsWith(campo)).ToList();
            }
            if (0 < query.Count)
            {
                _dataGridView1.DataSource = query.Skip(inicio).Take(_reg_por_pagina).ToList();
                _dataGridView1.Columns[0].Visible = false; //oculta columna

                _dataGridView1.Columns[7].Visible = false;//oculta columna
                _dataGridView1.Columns[9].Visible = false;//oculta columna
                _dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
            else
            {
                _dataGridView1.DataSource = query;
            }


        }
        private int _idCliente = 0;// creada para el metodo getcliente
        public void GetCliente() // procedimiento para llenar los campos , cuando los seleccionamos en datagriewiew #20yt
        {
            _accion = "update";
            _idCliente = Convert.ToInt16(_dataGridView1.CurrentRow.Cells[0].Value);
            _textBoxCliente[0].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[1].Value);
            _textBoxCliente[1].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[2].Value);
            _textBoxCliente[2].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[3].Value);
            _textBoxCliente[3].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[4].Value);
            _textBoxCliente[4].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[6].Value);
            _textBoxCliente[5].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[5].Value);

            //para obtener la imagen
            try
            {
                byte[] arrayImage = (byte[])_dataGridView1.CurrentRow.Cells[9].Value;
                _imagePictureBox.Image = Objects.uploadimage.byteArrayToImage(arrayImage); // devuelve la imagen
            }
            catch (Exception)
            {
                _imagePictureBox.Image = _imagBitmap; // sino podemos obtener la imagen , se muestra la imagen por defecto
            }


            _checkBoxCredito.Checked = Convert.ToBoolean(_dataGridView1.CurrentRow.Cells[8].Value); // obtenemos el dato de la columna 8 (checkbox)
            _checkBoxCredito.ForeColor = _checkBoxCredito.Checked ? Color.Green : Color.Red;
        }
        public void restablecer()
        {
            _accion = "insert";
            _num_pagina = 1;
            _imagePictureBox.Image = _imagBitmap;
            _textBoxCliente[0].Text = "";
            _textBoxCliente[1].Text = "";
            _textBoxCliente[2].Text = "";
            _textBoxCliente[3].Text = "";
            _textBoxCliente[4].Text = "";
            _textBoxCliente[5].Text = "";
            _checkBoxCredito.Checked = false;
            _checkBoxCredito.ForeColor = Color.LightSlateGray;
            _labelCliente[0].Text = "Nid";
            _labelCliente[0].ForeColor = Color.LightSlateGray;
            _labelCliente[1].Text = "Nombre";
            _labelCliente[1].ForeColor = Color.LightSlateGray;
            _labelCliente[2].Text = "Apellido";
            _labelCliente[2].ForeColor = Color.LightSlateGray;
            _labelCliente[3].Text = "Email";
            _labelCliente[3].ForeColor = Color.LightSlateGray;
            _labelCliente[4].Text = "Telefono";
            _labelCliente[4].ForeColor = Color.LightSlateGray;
            _labelCliente[5].Text = "Direccion";
            _labelCliente[5].ForeColor = Color.LightSlateGray;
             SearchClientes("");
            listCliente = TClientes.ToList();
            if (0 < listCliente.Count)
            {
                _paginadorClientes = new Paginador<TClientes>(listCliente, _labelCliente[6], _reg_por_pagina);
            }

        }
        private List<TClientes> listCliente;
        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "Primero":
                    if (0 < listCliente.Count)
                        _num_pagina = _paginadorClientes.primero();
                    break;
                case "Anterior":
                    if (0 < listCliente.Count)
                        _num_pagina = _paginadorClientes.anterior();
                    break;
                case "Siguiente":
                    if (0 < listCliente.Count)
                        _num_pagina = _paginadorClientes.siguiente();
                    break;
                case "Ultimo":
                    if (0 < listCliente.Count)
                        _num_pagina = _paginadorClientes.ultimo();
                    break;

            }
            SearchClientes("");





        }
        public void Registro_Paginas() // aqui se define cantidad de item por dgv el numericc(11)
        {
            _num_pagina = 1;
            _reg_por_pagina = (int)_numericUpDown.Value;
            listCliente = TClientes.ToList();
            if (0 < listCliente.Count)
            {
                _paginadorClientes = new Paginador<TClientes>(listCliente, _labelCliente[6], _reg_por_pagina);
                SearchClientes("");
            }
        }
    }
}
