using System.Collections.Generic;
using System.Windows.Forms;
using WcfForms.PersonService;

namespace WcfForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadGridPersons();
        }

        public void LoadGridPersons()
        {
            var persons = new List<Person>();

            using (PersonClient pc = new PersonClient())
            {
                dgvPersons.DataSource = pc.GetPersons();

            }

        }
    }
}
