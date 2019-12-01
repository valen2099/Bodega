﻿using BL.Bodega;
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

namespace Win.Bodega
{
    public partial class FormProductos : Form
    {
        ProductosBL _productos;
        CategoriasBL _Categorias;

        public FormProductos()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();//OBT PROD, nos retorna lista de productos

            _Categorias = new CategoriasBL();
            listadeCategoriasBindingSource.DataSource = _Categorias.ObtenerCategorias();
            
        }
        private static FormProductos m_FormDefInstance;
        /// 
        /// Crea una instancia unica del Formulario
        /// 
        /// Instancia por defecto
        public static FormProductos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormProductos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;

            if(fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageTobyteArray(fotoPictureBox.Image);
            }
            else
            {
                producto.Foto = null;
            }

            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                DeshabilitarHabilitarTextbox(false);
                listaProductosBindingNavigatorSaveItem.Enabled = false;
                
                MessageBox.Show("Datos Guardados");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();



            DeshabilitarHabilitarBotones(false);
            DeshabilitarHabilitarTextbox(true);
            listaProductosBindingNavigatorSaveItem.Enabled = true;
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Elinimar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _productos.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
            DeshabilitarHabilitarTextbox(false);

            listaProductosBindingNavigatorSaveItem.Enabled = false;
            
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            listaProductosBindingNavigatorSaveItem.Enabled = false;
            DeshabilitarHabilitarTextbox(false);
            //Boton editar deshabilitado si no hay productos, revisar si es posible un mejor codigo
            if (listaProductosBindingSource.Current==null)
            {
                toolStripButtonEditar.Enabled = false;
            }
            //Que es esto?
            string ub;
            ub = bindingNavigatorPositionItem.Text;
            ubicacionTextBox.Text = ub;
 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductosBindingSource.Current;

            if (producto != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();
                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }

            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void Eliminar(int id)
        {
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        //Funciones para habilitar o deshabilitar botones y textbox
        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonEditar.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;//Antepuesto(negacion, si es V es F, y si es F es V)
        }
        private void DeshabilitarHabilitarTextbox(bool valor)
        {
            categoriaIdComboBox.Enabled = valor;
            descripcionTextBox.Enabled = valor;
            precioTextBox.Enabled = valor;
            existenciaTextBox.Enabled = valor;
            ubicacionTextBox.Enabled = valor;
            activoCheckBox.Enabled = valor;
            button2.Enabled = valor;
            button3.Enabled = valor;
        }
        
        //El evento de "cerrar" la forma pasara por este metodo antes de ejecutarse       
        private void cerrar(object sender, FormClosingEventArgs e)
        {
            var resultado = MessageBox.Show("Los cambios no guardados se perderán ¿Desea salir?", "Salir", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(false);
            DeshabilitarHabilitarTextbox(true);
            listaProductosBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
