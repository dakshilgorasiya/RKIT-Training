

# Pluggable Import Pipeline

This document outlines the architecture of the Pluggable Import Pipeline, a .NET class library and console application designed to ingest, process, and report on data from various file formats in a flexible and extensible manner.

## 🏛️ Architecture & Design

The project is architected around the principles of abstraction and dependency inversion, allowing for a "pluggable" system where new file formats and report types can be added with minimal changes to the core application logic. The use of generics ensures the pipeline is type-safe and reusable for different data models.



### Core Components

The solution is divided into two main projects:

* `Ingestion.Pipeline`: A .NET class library containing all the core abstractions, implementations, and business logic.
* `Ingestion.Cli`: A console application that acts as the host and entry point for the pipeline. It is responsible for parsing command-line arguments, discovering files and reporting process.
* `Domain` : A .NET class library containing all model classes and enums for project

---

### Key Abstractions

The pluggable nature of the pipeline is achieved through a set of key abstractions.

#### **`abstract class FileImporter<T>`**

This generic abstract class serves as the **foundation for all file importers**. Any class that reads data from a file and transforms it into a collection of objects must inherit from `FileImporter<T>`.

* **Generic Parameter `T`**: Represents the data model to be imported (e.g., `Book`, `User`). This makes importers strongly-typed and reusable.
* **`IEnumerable<T> Import(string path)`**: The core abstract method that concrete implementations must provide. It takes a file path and returns a collection of objects.

#### **`interface IReportWriter<T>`**

This generic interface defines the **contract for all report writers**. It decouples the data analysis from the final output format.

* **Generic Parameter `T`**: Represents the data being reported on. (e.g. `Report`, `BookSummary`)
* **Method `void Write(T data)`**: The single method contract for writing the processed data to a specific output (e.g., a file, console).

---

### Concrete Implementations

These are the "plugs" that fit into the pipeline's abstract slots. They are marked as **`sealed`** because they represent specific, final implementations of an abstraction and are not designed for further inheritance.

* **`CsvBookImporter : FileImporter<Book>`**: A `sealed` class responsible for parsing `.csv` files containing book data.
* **`JsonBookImporter : FileImporter<Book>`**: A `sealed` class that handles the ingestion of book data from `.json` files.
* **`TextReportWriter : IReportWriter<T>`**: A `sealed` implementation that writes a summary report as a plain text file.
* **`XmlReportWriter : IReportWriter<T>`**: A `sealed` implementation that serializes the final report into XML format.
* **`JsonReportWriter : IReportWriter<T>`**: A `sealed` implementation that serializes the final report into JSON format.

---

### Data Flow

1.  **Initialization**: The `Ingestion.Cli` application starts, parses command-line arguments (like `--dry-run`), and identifies the target input directory (`./in`).
2.  **File Discovery**: The application recursively scans the `./in` directory for all files with supported extensions (e.g., `.csv`, `.json`).
3.  **Importer Selection**: For each file found, program selects the appropriate `FileImporter` (e.g., `CsvBookImporter` for a `.csv` file).
4.  **Data Ingestion**: The chosen importer's `Import()` method is called, which reads and deserializes the file into an `IEnumerable<Book>`.
5.  **Aggregation & Processing**: All imported data is aggregated into a single collection. **LINQ** queries and custom extension methods are then used to filter, group, sort, and project the data to generate insights (e.g., find the books with the highest penalty fees).
6.  **Reporting**: The processed summary data is passed to all registered `IReportWriter` implementations (`TextReportWriter`, `XmlReportWriter`).
7.  **Serialization**: Each writer serializes the summary data into its designated format (e.g., `report.txt`, `report.xml`, `report.json`) in the `./out` directory.

---

## ✨ Features

### File System Operations

* **Recursive Scanning**: The pipeline automatically discovers all supported files within the `./in` directory and its subdirectories.
* **Dry Run Mode**: By using the `--dry-run` command-line flag, the application will list all the files it *would* process without actually reading or importing them. This is useful for verification and debugging.

### Serialization

The final report summary is serialized to multiple formats (**JSON** and **XML**) to support different downstream consumers.