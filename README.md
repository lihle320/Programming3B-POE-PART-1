# Programming3B-POE-PART-1
# Issue Reporting System

Welcome to the Issue Reporting System, a user-friendly Windows Forms application designed to streamline the process of reporting and managing community issues. With a focus on ease of use and comprehensive functionality, this application allows users to submit detailed reports, including file attachments, ensuring that all relevant information is captured effectively.

## Features

- **Issue Reporting**: Easily submit detailed issue reports that include location, category, and a thorough description of the problem.
- **File Attachments**: Support for multiple file types, such as images and PDFs, allows users to provide additional context and evidence for their reports.
- **Category Selection**: Organized issue categorization helps ensure that reports are directed to the appropriate departments, facilitating quicker resolutions.
- **Attachment Management**: Users can view and manage attached files before submission, ensuring that only the relevant documents are included.
- **Form Navigation**: Intuitive navigation between forms enhances user experience and makes reporting issues straightforward.

## Supported File Types

The application supports a variety of file types, ensuring flexibility for users:

- **Images**: .jpg, .jpeg, .png, .bmp, .gif
- **Documents**: .pdf
- **All Other File Types**: *.* (allows all file types to be attached)

## How to Use

### Reporting an Issue

1. **Enter Location**: Type in the specific location where the issue occurred to provide context.
2. **Select Category**: From the dropdown menu, choose an appropriate category that best describes the issue.
3. **Add Description**: Provide a detailed description of the issue, including any relevant information that can aid in its resolution.
4. **Attach Files (Optional)**:
   - Click the "Attach File" button to open the file selection dialog.
   - Select one or multiple files to upload.
   - Supported formats include images, PDFs, and various other file types.
5. **View Attachments**: Click on the attachment label to see a list of currently attached files, ensuring that all necessary documents are included.
6. **Submit Report**: Once all information is filled out, click the "Submit" button to send your report to the admin team.

### After Submission

- Upon submission, you will receive a confirmation message detailing all the submitted information.
- A thank you message will confirm that your report has been received and is being processed.
- The system will automatically clear all fields, allowing you to submit another report if needed.
- Your report is securely stored for review by the admin team, ensuring that it is addressed promptly.

## Technical Details

### Built With

This application is developed using several key technologies:

- **.NET Framework Windows Forms**: Provides a robust structure for developing desktop applications.
- **C# Programming Language**: The primary language used for application logic.
- **System.IO**: Utilized for efficient file handling operations.
- **OpenFileDialog**: Simplifies the process of file selection for users.

### Classes

Key classes in the application include:

- **ReportIssues**: The main form responsible for issue reporting functionality.
- **IssueReport**: A data class used for storing essential report information.

### Data Structure

Each issue report comprises the following components:

- **Location (string)**: The specific location of the issue.
- **Category (string)**: The category under which the issue falls.
- **Description (string)**: A detailed account of the issue being reported.
- **List of Attachment File Paths (List<string>)**: Contains paths to the files attached with the report.

## Installation

To install and run the application, follow these steps:

1. Clone or download the project files from the repository.
2. Open the solution in Visual Studio.
3. Build the solution by pressing Ctrl + Shift + B.
4. Run the application using F5 or by selecting "Start Debugging" from the menu.

### Requirements

Before using the application, ensure that your system meets the following requirements:

- **.NET Framework**: Version 4.7.2 or higher is required.
- **Operating System**: Windows OS.
- **Development Environment**: Visual Studio 2019 or higher is recommended for development purposes.

## File Handling

The application manages file paths rather than the actual files, ensuring that users retain control over their documents. Maximum file size limitations are subject to system constraints. Attached files remain in their original locations, with no modifications or relocations made by the application.

## Error Handling

The application includes robust validation mechanisms to ensure data integrity, including checks for:

- **Required Fields**: Ensures that location, category, and description fields are filled out before submission.
- **File Attachment Errors**: Provides feedback if there are issues with file attachments.
- **Form Navigation Issues**: Guides users to navigate the application without confusion.

## Support

For any issues or questions regarding the application, please feel free to contact the development team or refer to the comprehensive help documentation provided within the application.

## License

This project is developed solely for educational purposes as part of the PROG7312 POE. Thank you for your interest, and we hope this application serves your needs effectively!
