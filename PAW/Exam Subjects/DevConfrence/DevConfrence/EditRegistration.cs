using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConfrence
{
    public partial class EditRegistration : Form
    {
        private List<AccessPackage> packages;
        private Registration registration;

        public EditRegistration( List<AccessPackage> packages, Registration registration)
        {
            this.packages = packages;
            this.registration = registration;
            InitializeComponent();
        }

        private void EditRegistration_Load(object sender, EventArgs e)
        {
            cbType.DataSource = packages;
            tbCompanyName.Text = registration.CompanyName;
            noPackages.Value = registration.NoOfPasses;
            var type = packages.FirstOrDefault(x => registration.AccessPackageId == x.Id);
            cbType.SelectedItem = type;

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            registration.CompanyName = tbCompanyName.Text;
            registration.NoOfPasses = (int)noPackages.Value;
            var selectedType = (AccessPackage)cbType.SelectedItem;
            registration.AccessPackageId = selectedType.Id;
        }

        private void tbCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbCompanyName.Text.Trim()) || tbCompanyName.Text.Length<5){
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "The name needs to be larger than 5");
            }
        }

        private void tbCompanyName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, null);
        }
    }
}
