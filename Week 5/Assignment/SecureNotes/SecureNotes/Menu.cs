using Models;
using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNotes
{
    /// <summary>
    /// A class to display and handle the menu operations for the secure notes application.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// List of note headers to display in the menu.
        /// </summary>
        private List<NoteHeader> headers;

        /// <summary>
        /// Instance of OperationHelper to perform note operations.
        /// </summary>
        private readonly OperationHelper _operationHelper;

        /// <summary>
        /// A constructor to initialize the Menu class and load existing note headers.
        /// </summary>
        public Menu()
        {
            _operationHelper = new OperationHelper(); // Initialize OperationHelper

            headers = _operationHelper.ListNotes(); // Load existing note headers
        }

        /// <summary>
        /// A method to display the menu and handle user input for various operations.
        /// </summary>
        public void Display()
        {
            while (true)
            {
                Console.WriteLine("\n\n\n---------------");
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. List Notes");
                Console.WriteLine("3. Read Note");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Please select an option: ");

                string? choice = Console.ReadLine();

                bool isInteger = int.TryParse(choice, out int value);

                if(!isInteger)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue; // Show options again and take input
                }

                switch(value)
                {
                    case 1:
                        CreateNote();
                        break;
                    case 2:
                        ListNotes();
                        break;
                    case 3:
                        ReadNote();
                        break;
                    case 4:
                        UpdateNote();
                        break;
                    case 5:
                        DeleteNote();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// A method to create a new note by taking title and body input from the user.
        /// </summary>
        private void CreateNote()
        {
            string? title;
            string? body;

            Console.WriteLine("Enter note title: ");
            title = Console.ReadLine();

            if(String.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Please retry");
                return;
            }

            Console.WriteLine("Enter note body: ");
            body = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("Body cannot be empty. Please retry");
                return;
            }

            _operationHelper.CreateNote(title, body); // Create the note

            headers = _operationHelper.ListNotes(); // Refresh the headers list

            Console.WriteLine("Note created successfully.");
        }

        /// <summary>
        /// A method to list all existing notes with their titles and timestamps.
        /// </summary>
        private void ListNotes()
        {
            for(int i = 0; i < headers.Count; i++)
            {
                NoteHeader header = headers[i];
                Console.WriteLine($"{i + 1}. {header.Title} (Created: {header.CreatedAt}, Updated: {header.UpdatedAt})");
            }
        }

        /// <summary>
        /// A method to read and display a specific note based on user selection.
        /// </summary>
        private void ReadNote()
        {
            Guid id; // Id of the note to read

            ListNotes(); // Display the list of notes

            Console.WriteLine("Enter the number of the note to read: ");
            string? choice = Console.ReadLine();

            bool isInteger = int.TryParse(choice, out int value);

            if (!isInteger || value < 1 || value > headers.Count)
            {
                Console.WriteLine("Please enter a valid number.");
                return; // Show options again and take input
            }

            id = headers[value - 1].Id; // Get the Id of the selected note

            Note note = _operationHelper.ReadNote(id); // Read the selected note

            Console.WriteLine($"\nTitle: {note.Title}\nBody: {note.Body}\nCreated At: {note.CreatedAt}\nUpdated At: {note.UpdatedAt}");

        }

        /// <summary>
        /// A method to update an existing note by taking new title and body input from the user.
        /// </summary>
        private void UpdateNote()
        {
            Guid id; // Id of the note to update

            ListNotes(); // Display the list of notes

            Console.WriteLine("Enter the number of the note to update: ");
            string? choice = Console.ReadLine();

            bool isInteger = int.TryParse(choice, out int value);

            if (!isInteger || value < 1 || value > headers.Count)
            {
                Console.WriteLine("Please enter a valid number.");
                return; // Show options again and take input
            }

            id = headers[value - 1].Id; // Get the Id of the selected note

            Console.WriteLine("Enter new title: ");
            string? title = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Please retry");
                return;
            }

            Console.WriteLine("Enter new body: ");
            string? body = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("Body cannot be empty. Please retry");
                return;
            }

            _operationHelper.UpdateNote(id, title, body); // Update the note

            headers = _operationHelper.ListNotes(); // Refresh the headers list

            Console.WriteLine("Note updated successfully.");
        }

        /// <summary>
        /// A method to delete a specific note based on user selection.
        /// </summary>
        private void DeleteNote()
        {
            Guid id; // Id of the note to delete

            ListNotes(); // Display the list of notes

            Console.WriteLine("Enter the number of the note to delete: ");
            string? choice = Console.ReadLine();

            bool isInteger = int.TryParse(choice, out int value);

            if (!isInteger || value < 1 || value > headers.Count)
            {
                Console.WriteLine("Please enter a valid number.");
                return; // Show options again and take input
            }

            id = headers[value - 1].Id; // Get the Id of the selected note

            _operationHelper.DeleteNote(id); // Delete the note

            headers = _operationHelper.ListNotes(); // Refresh the headers list

            Console.WriteLine("Note deleted successfully.");
        }
    }
}
