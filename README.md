# OCRApp

OCRApp to prosta i intuicyjna aplikacja stworzona w języku C# z wykorzystaniem WPF (Windows Presentation Foundation), służąca do rozpoznawania tekstu (OCR) na obrazach. Wykorzystuje silnik Tesseract OCR do wyodrębniania tekstu z obrazów i umożliwia użytkownikom przeglądanie, edytowanie oraz zapisywanie wyników w różnych formatach (TXT lub CSV). Aplikacja oferuje przyjazny interfejs użytkownika z dodatkowymi funkcjami, takimi jak edycja tekstu, wybór wyników oraz opcje eksportu.

## 🎯 Funkcje

- **Wybór obrazu** – użytkownik może wybrać plik graficzny (PNG, JPG, JPEG) z dysku.
- **Przetwarzanie OCR** – aplikacja używa Tesseract OCR do wyodrębnienia tekstu z wybranego obrazu.
- **Przegląd i edycja tekstu** – wyniki OCR są wyświetlane na liście z checkboxami. Użytkownik może zaznaczyć i edytować tekst przed zapisaniem.
- **Eksport plików** – możliwość zapisania wybranych wyników do pliku `.txt` lub `.csv` z wyborem separatora (nowa linia, spacja, średnik, przecinek).
- **Wsparcie dla wielu języków** – obsługa języka polskiego i angielskiego przez silnik Tesseract.
- **Edycja tylko zaznaczonych wyników** – edytowanie tekstu możliwe tylko po zaznaczeniu checkboxa.

## 🛠️ Jak używać

1. **Wybierz obraz**: kliknij „📂 Wybierz obraz” i załaduj plik graficzny.
2. **Rozpocznij analizę**: kliknij „🔍 Rozpocznij analizę”, aby uruchomić OCR.
3. **Przeglądaj i edytuj wyniki**: zaznacz checkboxy przy interesujących Cię wynikach i edytuj tekst.
4. **Zapisz zmiany**: kliknij „💾 Zapisz zmiany”, aby zatwierdzić edycję.
5. **Zapisz do pliku**: kliknij „💾 Zapisz do pliku” i wybierz format oraz separator danych.

## 🧰 Technologie

- **C#** – główny język programowania.
- **WPF** – framework do tworzenia graficznego interfejsu.
- **Tesseract OCR** – silnik do rozpoznawania tekstu.
- **.NET Framework** – platforma uruchomieniowa aplikacji.

## 📦 Wymagania

- **Tesseract OCR** – należy mieć zainstalowany silnik OCR oraz pliki językowe `pol.traineddata` i `eng.traineddata` w folderze `tessdata`.
- **.NET Framework** – aplikacja wymaga odpowiedniej wersji .NET Framework.

## 🚀 Instalacja

1. Pobierz najnowszą wersję aplikacji z sekcji [Releases](https://github.com/Neteno/OCR_App/releases).
2. Uruchom instalator (`.msi`) lub plik wykonywalny (`.exe`), w zależności od wersji.
3. Postępuj zgodnie z instrukcjami instalatora.
4. Po zakończeniu instalacji uruchom aplikację z menu Start lub bezpośrednio z folderu docelowego.

📦 **Uwaga:** Upewnij się, że folder `tessdata` (zawierający pliki `pol.traineddata` i `eng.traineddata`) znajduje się w tym samym katalogu co plik `.exe`, lub że jego ścieżka jest poprawnie skonfigurowana w aplikacji.

## Autor  
📌 **Szymon A. (aka Neteno)**  
