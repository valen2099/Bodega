using BL.Bodega;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Bodega
{
    public partial class FormReporteTransacciones : Form
    {
        public FormReporteTransacciones()
        {
            InitializeComponent();
            var _transaccionesBL = new TransaccionesBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _transaccionesBL.ObtenerTransacciones();

            var reporte = new ReporteFacturas();
            reporte.SetDataSource(bindingSource);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
