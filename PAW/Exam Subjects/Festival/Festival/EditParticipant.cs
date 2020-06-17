using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Festival
{
    public partial class EditParticipant : Form
    {
        private Participant participant;
        private string[] concerts;
        public EditParticipant(Participant participant, string[] concertArray)
        {
            this.participant = participant;
            this.concerts = concertArray;
            InitializeComponent();
        }

        private void EditParticipant_Load(object sender, EventArgs e)
        {
            foreach(string concert in concerts)
            {
                cblConcerts.Items.Add(concert, false);
            }

            tbName.Text = participant.Name;
            tbEmail.Text = participant.Email;
            dtpBirthDate.Value = participant.BirthDate;
            if (participant.Concerts !=null)
            {
                foreach (var concert in participant.Concerts)
                {
                    if (!string.IsNullOrEmpty(concert))
                    {
                        int item = cblConcerts.FindStringExact(concert);
                        cblConcerts.SetItemChecked(item, true);
                    }
                }
            }
            
            
            

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            participant.Name = tbName.Text;
            participant.Email = tbEmail.Text;
            participant.BirthDate = dtpBirthDate.Value;


            string s = "";
            for (int x = 0; x < cblConcerts.CheckedItems.Count; x++)
            {
                s = s +  cblConcerts.CheckedItems[x].ToString()+",";
            }
            participant.Concerts = s.Split(',');


        }
    }
}
