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
        private LinkedList<string> currentAttachments; // LinkedList to store attachments for the current report (Microsoft Learn, n.d.). 
        private LinkedList<IssueReport> issueReports; // LinkedList to store reported issues (Microsoft Learn, n.d.). 
        private int reportCounter = 0; // Counter to track report numbers

        public ReportIssues()
        {
            currentAttachments = new LinkedList<string>(); //(Microsoft Learn, n.d.). 
            issueReports = new LinkedList<IssueReport>(); //(Microsoft Learn, n.d.). 
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
                        AttachFile(filePath);
                    }
                }
            }
        }

        private void AttachFile(string filePath) //(Microsoft Learn, n.d.). 
        {
            // Add the file to current attachments using LinkedList
            currentAttachments.AddLast(filePath);

            // Optional: Show the attached file name in the UI
            MessageBox.Show($"File attached: {System.IO.Path.GetFileName(filePath)}", //(Microsoft Learn, n.d.). 
                           "Attachment Added",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(LocationtextBox.Text))
            {
                MessageBox.Show("Please enter a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025)
                return;
            }

            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025)
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionrichTextBox.Text))
            {
                MessageBox.Show("Please enter a description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //(Microsoft Learn, 2025)
                return;
            }

            // Get current date and time
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dddd, dd MMMM yyyy");
            string formattedTime = currentDate.ToString("hh:mm tt");

            // Increment report counter
            reportCounter++;

            // Create a new issue report with attachments
            IssueReport report = new IssueReport
            {
                Location = LocationtextBox.Text,
                Category = CategoryComboBox.SelectedItem.ToString(),
                Description = DescriptionrichTextBox.Text,
                Attachments = new LinkedList<string>(currentAttachments), // Copy current attachments (Microsoft Learn, n.d.). 
                ReportDate = currentDate, // Store the report date
                ReportNumber = reportCounter // Store the report number
            };

            // Add report to LinkedList
            issueReports.AddLast(report);

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

            // Show the details in a message box with date, time, and report number
            string message = $"Issue Reported!\n\n" +
                             $"Report:{report.ReportNumber}\n" +
                             $"Date: {formattedDate}\n" +
                             $"Time: {formattedTime}\n\n" +
                             $"Location: {report.Location}\n" +
                             $"Category: {report.Category}\n" +
                             $"Description: {report.Description}\n\n" +
                             $"Attachments:\n{attachmentInfo}";

            MessageBox.Show(message, "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information); //(Microsoft Learn, 2025)
            MessageBox.Show("Thank you for your submission! We appreciate you taking the time to report this issue. Our team will review it and get back to you as soon as possible.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void DisplayAllReports()
        {
            if (issueReports.Count == 0)
            {
                MessageBox.Show("No issue reports have been submitted yet.", "No Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("All Issue Reports:");
            sb.AppendLine("==================");
            sb.AppendLine();

            // Iterate through the LinkedList
            LinkedListNode<IssueReport> currentNode = issueReports.First;
            int count = 1;

            while (currentNode != null)
            {
                IssueReport report = currentNode.Value;

                sb.AppendLine($"Report {report.ReportNumber}");
                sb.AppendLine($"------------");
                sb.AppendLine($"Date: {report.ReportDate:dddd, dd,MMMM, yyyy}");
                sb.AppendLine($"Time: {report.ReportDate:hh:mm tt}");
                sb.AppendLine($"Location: {report.Location}");
                sb.AppendLine($"Category: {report.Category}");
                sb.AppendLine($"Description: {report.Description}");

                // Add attachments information
                sb.Append("Attachments: ");
                if (report.Attachments.Count > 0)
                {
                    sb.AppendLine();
                    foreach (string attachment in report.Attachments)
                    {
                        sb.AppendLine($"  • {System.IO.Path.GetFileName(attachment)}");
                    }
                }
                else
                {
                    sb.AppendLine("None");
                }

                sb.AppendLine();
                sb.AppendLine();

                // Move to next node
                currentNode = currentNode.Next;
                count++;
            }

            // Display the reports in a message box
            MessageBox.Show(sb.ToString(), "All Issue Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void viewReportsBtn_Click(object sender, EventArgs e)
        {
            DisplayAllReports();
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

                MessageBox.Show(detailedInfo, "Current Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No files are currently attached.", "Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void backpictureBox_Click(object sender, EventArgs e) //(Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial, 2021). 
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

        private void HomeMainMenuLabe_Click(object sender, EventArgs e) //(Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial, 2021). 
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

        private void backMainButton_Click(object sender, EventArgs e)
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

        private void ReportIssues_Load(object sender, EventArgs e)
        {

        }

        private void LocationtextBox_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void DescriptionrichTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }

}
