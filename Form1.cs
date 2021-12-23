using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id= Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
                                   
           Yukleme();
            MessageBox.Show("Deleted!");
        }

        private void gbxadd_Enter(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            Yukleme(); // ProductDal class ını çağırdık ve ordaki GetAll methoduyla
                       // dgwProducts tablosunun datalarını doldurduk.
                       // Sık kullanılacağı için method haline getirildi. Kodu aşağıdadır.
        }

        private void Yukleme()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ProductDal classından çağırılan Add methodu ile,
            // property leri tbx lerin içine yazılan değerler olan yeni bir Product eklenmesini sağladık.
            
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice= Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxStockAmount.Text)
            }); ;
            
            Yukleme(); // Ekledikten sonra ürünlerin gelmesi için tekrar dataları yüklüyoruz.
            MessageBox.Show("Added!");
            
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value), // ID ulaşma kodu.
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)

            }); ;
            Yukleme();
            MessageBox.Show("Updated!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CellClick eventi herhangi bir hücreye tıklanması olayıdır.
            // Form Design da Event e tıklayarak Mouse üstünden geldik buraya.
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
