# OCRApp

OCRApp is a simple and intuitive application built using C# and WPF (Windows Presentation Foundation) for performing Optical Character Recognition (OCR) on images. It leverages the Tesseract OCR engine to extract text from images and allows users to review, modify, and save the extracted text in various formats (TXT or CSV). The application is designed to offer a user-friendly interface with additional features such as text editing, result selection, and file export options.

## Features

- **Image Selection**: Users can select an image file (PNG, JPG, JPEG) from their file system.
- **OCR Processing**: The application uses Tesseract OCR to extract text from the selected image.
- **Text Review & Editing**: OCR results are displayed in a list with checkboxes. Users can select which OCR results to save and even edit the text before saving.
- **File Export**: The user can save the selected OCR results into a text file (`.txt`) or CSV file (`.csv`). Users can choose the delimiter (newline, space, semicolon, or comma) used to separate the text.
- **Multilingual Support**: The Tesseract engine supports both Polish and English languages.
- **Read-only Text Editing**: The editable text box only activates when a checkbox is checked, allowing for modifications before saving the result.

## How to Use

1. **Select an Image**: Click on the "📂 Wybierz obraz" button to select an image for OCR processing.
2. **Start OCR**: Click on the "🔍 Rozpocznij analizę" button to start extracting text from the image.
3. **Review and Edit Results**: OCR results will be displayed in a list of checkboxes. You can select which results to save by checking the respective boxes. If a result is selected, you can edit the text before saving.
4. **Save Changes**: After editing any results, click "💾 Zapisz zmiany" to save the changes to the corresponding text entry.
5. **Save Results**: Once you've selected the desired results, click on the "💾 Zapisz do pliku" button to save the text to a file. You can choose the file type (TXT or CSV) and the delimiter (Newline, Space, Semicolon, or Comma).

## Technologies Used

- **C#**: Main programming language used for building the application.
- **WPF (Windows Presentation Foundation)**: Framework used for designing the user interface.
- **Tesseract**: The OCR engine used to extract text from images.
- **.NET**: The application runs on the .NET platform, utilizing the powerful capabilities of the C# language.

## Prerequisites

- **Tesseract OCR Engine**: The app requires the Tesseract OCR engine to be installed, along with the language data files (`pol.traineddata` and `eng.traineddata`), which are included in the `tessdata` folder.
- **.NET Framework**: This app is built on the .NET Framework, so make sure you have the required version of the .NET runtime installed on your machine.

## Installation

1. Clone or download the repository.
2. Open the solution in Visual Studio.
3. Make sure to restore any NuGet packages if needed.
4. Build and run the project in Visual Studio.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
