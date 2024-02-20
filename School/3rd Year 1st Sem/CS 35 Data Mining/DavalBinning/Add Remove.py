import tkinter as tk
from tkinter import messagebox
import pandas as pd


# Function to update the listbox
def update_listbox():
    data = pd.read_csv('dataset.csv')
    sorted_data = sorted(data['Number'])
    listbox.delete(0, tk.END)
    for num in sorted_data:
        listbox.insert(tk.END, num)


# Function to remove selected item
def remove_item():
    selected_index = listbox.curselection()
    if not selected_index:
        messagebox.showerror('Error', 'Please select an item to remove.')
        return
    selected_item = listbox.get(selected_index)

    # Read the data and find all rows with the selected item
    data = pd.read_csv('dataset.csv')
    indices_to_remove = data.index[data['Number'] == selected_item].tolist()

    # Only remove the first occurrence of the selected item
    if indices_to_remove:
        data = data.drop(indices_to_remove[0])
        data.to_csv('dataset.csv', index=False)
        update_listbox()


# Function to add a new entry
def add_entry():
    new_entry = entry.get()
    try:
        new_entry = int(new_entry)
        data = pd.read_csv('dataset.csv')
        new_row = pd.DataFrame({'Number': [new_entry]})
        data = pd.concat([data, new_row], ignore_index=True)
        data.to_csv('dataset.csv', index=False)
        entry.delete(0, tk.END)
        update_listbox()
    except ValueError:
        messagebox.showerror('Error', 'Please enter a valid integer.')


# Create the main window
window = tk.Tk()
window.title('Number Manager')

# Create a label for the entry field
entry_label = tk.Label(window, text='Enter an integer:')
entry_label.pack(pady=5)

# Create an entry field for adding new entries
entry = tk.Entry(window)
entry.pack(pady=5)

# Create a button to add new entries
add_button = tk.Button(window, text='Add', command=add_entry)
add_button.pack(pady=5)

# Create a listbox to display the numbers
listbox = tk.Listbox(window)
listbox.pack(padx=10, pady=5)

# Create a button to remove selected items
remove_button = tk.Button(window, text='Remove', command=remove_item)
remove_button.pack(pady=5)

# Load and display the initial sorted data
update_listbox()

# Allow the window to be resizable
window.resizable(True, True)

# Start the GUI main loop
window.mainloop()
