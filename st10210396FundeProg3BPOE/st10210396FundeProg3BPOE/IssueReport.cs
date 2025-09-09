using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10210396FundeProg3BPOE
{
    public class IssueReport
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public LinkedList<string> Attachments { get; set; }
        public DateTime ReportDate { get; set; } 
        public int ReportNumber { get; set; }

        public IssueReport()
        {
            // Attachments is a LinkedList to hold file names or paths
            Attachments = new LinkedList<string>(); //(Microsoft Learn, n.d.). 
            ReportDate = DateTime.Now; // Set default date to current date/time
        }
    }
}
//References 
//Microsoft Learn. (n.d.).OpenFileDialog Class(System.Windows.Forms). [Online].Available at: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0 [Accessed 03 September2025].
//Microsoft Learn. 2025.How to open a message box, 05 July 2025. Online]. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box [Accessed 03 September2025].
//Open Form2 From Form1 And Hide Form1 And Show Form1 Again After Closing The Form2 | C# Tutorial. 2021. YouTube video. Added by #SmartCode. [Online]. Available at: https://www.youtube.com/watch?v=bb5TaLbq9aM [Accessed 03 September2025].
//Microsoft Learn. (n.d.). LinkedList<T> Class. [Online]. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0 [Accessed 03 September2025]. 
