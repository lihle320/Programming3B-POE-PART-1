using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace st10210396FundeProg3BPOE
{
    public partial class ReportIssues : Form
    {

        private List<string> currentAttachments; // List to store attachments for the current report

        private List<IssueReport> issueReports; // List to store reported issues (Rohman, 2023)
        public ReportIssues()
        {
            currentAttachments = new List<string>();
            issueReports = new List<IssueReport>();
         
            InitializeComponent();
        }
       
          

        private void attachFileBtn_Click(object sender, EventArgs e) 
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) //(Microsoft Learn, n.d.). 
            {
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"; //(Microsoft Learn, n.d.). 
                openFileDialog.Multiselect = true; // Allow multiple file selection

                if (openFileDialog.ShowDialog() == DialogResult.OK) //(Microsoft Learn, n.d.). 
                {
                    foreach (string filePath in openFileDialog.FileNames) //(Microsoft Learn, n.d.). 
                    {
                        AttachFile(filePath); //(Microsoft Learn, n.d.). 
                    }
                }
            }
        }
        private void AttachFile(string filePath) //(Microsoft Learn, n.d.). 
        {
            // Add the file to current attachments
            currentAttachments.Add(filePath);

            // Optional: Show the attached file name in the UI
            MessageBox.Show($"File attached: {System.IO.Path.GetFileName(filePath)}", //(Microsoft Learn, 2025).
                           "Attachment Added",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(LocationtextBox.Text))
            {
                MessageBox.Show("Please enter a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025). 
                return;
            }

            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025). 
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionrichTextBox.Text))
            {
                MessageBox.Show("Please enter a description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025). 
                return;
            }

            // Create a new issue report with attachments
            IssueReport report = new IssueReport
            {
                Location = LocationtextBox.Text,
                Category = CategoryComboBox.SelectedItem.ToString(),
                Description = DescriptionrichTextBox.Text,
                Attachments = new List<string>(currentAttachments) // Copy current attachments
            };

            issueReports.Add(report);

            // Build attachment information for the message
            string attachmentInfo;
            if (report.Attachments.Count > 0)
            {
                attachmentInfo = string.Join("\n", report.Attachments.Select(path =>
                    $"• {System.IO.Path.GetFileName(path)}"));
            }
            else
            {
                attachmentInfo = "None";
            }

            // Show the details in a message box
            string message = $"Issue Reported!\n\n" +
                             $"Location: {report.Location}\n" +
                             $"Category: {report.Category}\n" +
                             $"Description: {report.Description}\n\n" +
                             $"Attachments:\n{attachmentInfo}";

            MessageBox.Show(message, "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information); //(Microsoft Learn, 2025). 
            MessageBox.Show("Thank you for your submission! We appreciate you taking the time to report this issue. Our team will review it and get back to you as soon as possible.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information); //(Microsoft Learn, 2025). 
            // Clear the fields for the next report
            ClearFields();
        }

        private void ClearFields()
        {
            LocationtextBox.Clear();          // Clear the location text box
            CategoryComboBox.SelectedIndex = -1;   // Clear the selected category
            DescriptionrichTextBox.Clear();   // Clear the description rich text box
            currentAttachments.Clear();       // Clear current attachments
        }

        private void NofileText_Click(object sender, EventArgs e)
        {
            // Show detailed attachment information when label is clicked
            if (currentAttachments.Count > 0)
            {
                string detailedInfo = "Attached Files:\n\n";
                foreach (string filePath in currentAttachments)
                {
                    detailedInfo += $"• {System.IO.Path.GetFileName(filePath)}\n";
                }

                MessageBox.Show(detailedInfo, "Current Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information); //(Microsoft Learn, 2025). 
            }
            else
            {
                MessageBox.Show("No files are currently attached.", "Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information); //(Microsoft Learn, 2025). 
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backpictureBox_Click(object sender, EventArgs e)
        {
            // Find and show the hidden Form1 instance
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1 && form.Visible == false)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void HomeMainMenuLabe_Click(object sender, EventArgs e)
        {
            // Find and show the hidden Form1 instance
            foreach (Form form in Application.OpenForms) //(Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial, 2021). 
            {
                if (form is Form1 && form.Visible == false)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void backMainButton_Click(object sender, EventArgs e)
        {
            // Find and show the hidden Form1 instance
            foreach (Form form in Application.OpenForms) //(Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial, 2021). 
            {
                if (form is Form1 && form.Visible == false)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
  }


//Referrnces 
//Microsoft Learn. (n.d.).OpenFileDialog Class(System.Windows.Forms). [Online].Available at: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0 [Accessed 03 September2025].
//Microsoft Learn. 2025.How to open a message box, 05 July 2025. Online]. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box [Accessed 03 September2025].
//Rohman, J.A. 2023.Using Data Structures in C#: Array, List, and Dictionary, 22 October 2023. [Online]. Available at: https://medium.com/@jamaludinarifr/using-data-structures-in-c-array-list-and-dictionary-1b551926d5ef [Accessed 03 September2025].
//Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial. 2021. YouTube video. Added by #SmartCode. [Online]. Available at: https://www.youtube.com/watch?v=bb5TaLbq9aM [Accessed 03 September2025].
