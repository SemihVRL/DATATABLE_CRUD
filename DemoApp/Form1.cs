using Northwind.Businnes.Abstract;
using Northwind.Businnes.Concrete;
using Northwind.Businnes.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            productService = new ProductService(new EfProductDal());
            categoryService = new CategoryManager(new EfCategoryDal());


        }
        private IProductService productService;
        private ICategoryService categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryAdd.DataSource = categoryService.GetAll();
            cbxCategoryAdd.DisplayMember = "CategoryName";
            cbxCategoryAdd.ValueMember = "CategoryId";

            cbxCategoryUpdate.DataSource = categoryService.GetAll();

            cbxCategoryUpdate.DisplayMember = "CategoryName";
            cbxCategoryUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = productService.GetAll();

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }

        }

        private void tbxProduct_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProduct.Text))
            {
                dgwProduct.DataSource = productService.GetProductsByProductName(tbxProduct.Text);
            }
            else
            {
                LoadProducts();
            }



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
                productService.Add(new Product
                {
                    CategoryID = Convert.ToInt32(cbxCategoryAdd.SelectedValue),
                    ProductName = tbxProductAdd.Text,
                    QuantityPerUnit = tbxQuantityAdd.Text,
                    UnitPrice = Convert.ToDecimal(tbxPriceAdd.Text),
                    UnitsInStock = Convert.ToInt16(tbxStockAdd.Text),


                });
                MessageBox.Show("ürün kaydedildi");
                LoadProducts();
            
            
        }

        private void btnUpdated_Click(object sender, EventArgs e)
        {
            productService.Updated(new Product
            {
                ProductID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                CategoryID = Convert.ToInt32(cbxCategoryAdd.SelectedValue),
                ProductName = tbxProductAdd.Text,
                QuantityPerUnit = tbxQuantityAdd.Text,
                UnitPrice = Convert.ToDecimal(tbxPriceAdd.Text),
                UnitsInStock = Convert.ToInt16(tbxStockAdd.Text),

            });
            MessageBox.Show("ürün güncellendi");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductUpdate.Text = row.Cells[1].Value.ToString();
            cbxCategoryUpdate.SelectedValue = row.Cells[2].Value;
            tbxPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityUpdate.Text = row.Cells[4].Value.ToString();
            tbxStockUpdate.Text = row.Cells[5].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    productService.Delete(new Product
                    {

                        ProductID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("ürün silindi");
                    LoadProducts();

                }
                catch (Exception exception)
                {  
                    MessageBox.Show(exception.Message);
                }


            }




        }

      
    }
}
