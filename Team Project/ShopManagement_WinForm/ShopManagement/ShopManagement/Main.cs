using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmOrder))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmOrder frm = new frmOrder();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Categories_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmCategories))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmCategories frm = new frmCategories();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmProduct))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmProduct frm = new frmProduct();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Shippers_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmShipper))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmShipper frm = new frmShipper();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Employees_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(employeeDetailForm))
                {
                    curForm.Activate();
                    return;
                }
            }
            employeeDetailForm frm = new employeeDetailForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmCustomer))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmCustomer frm = new frmCustomer();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Suppliers_Click(object sender, EventArgs e)
        {
            foreach (Form curForm in Application.OpenForms)
            {
                if (curForm.GetType() == typeof(frmSupplier))
                {
                    curForm.Activate();
                    return;
                }
            }
            frmSupplier frm = new frmSupplier();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
