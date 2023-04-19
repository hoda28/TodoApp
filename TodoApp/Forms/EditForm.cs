using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using TodoApp.Service;

namespace TodoApp
{
    public partial class EditForm : Form
    {    
        
        private IEditFormService service;

        public EditForm()
        {
            InitializeComponent();
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void btnAddTodo_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // Error Check
            this.errorCheck();
            service = new EditFormService();
            DataInputDataSet dataSet = new DataInputDataSet();
            DataInputDataSet.tasksRow row = dataSet.tasks.NewtasksRow();

            row.BeginEdit();
            row.discription = this.textBoxDescription.Text; ;
            row.category = this.textBoxCategory.Text;
            row.startdate = DateTime.Parse(this.dateTimePickerStartDate.Text);
            row.enddate = DateTime.Parse(this.dateTimePickerStartDate.Text);
            row.EndEdit();
            int cnt = service.InsertTasks(row);

            if (cnt == 1)
            {
                MessageBox.Show("Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void errorCheck()
        {
            string msg = string.Empty;

            if (String.IsNullOrEmpty(textBoxDescription.Text))
            {
                msg = "Please enter a description.";
                errorProvider.SetError(textBoxDescription, msg);
            }

            if (String.IsNullOrEmpty(textBoxCategory.Text))
            {
                msg = "Please enter a category.";
                errorProvider.SetError(textBoxCategory, msg);
            }

            DateTime d1 = DateTime.Parse(dateTimePickerStartDate.Text);
            DateTime d2 = DateTime.Parse(dateTimePickerEndDate.Text);

            // StartDate < EndDate
            if (d2 < d1)
            {
                msg = "Please ensure that the end date is greater than the start date.";
                errorProvider.SetError(dateTimePickerEndDate, msg);
            }
        }

    }
}
