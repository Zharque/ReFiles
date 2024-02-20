import pandas as pd
import tkinter as tk
from tkinter import ttk

# Read the CSV file into a pandas DataFrame
data = pd.read_csv('dataset.csv')

# Specify the number of bins and the column containing the integers
num_bins = 5  # You can adjust this to the desired number of bins
int_column = 'Number'  # Replace 'integer_column_name' with the actual column name

# Use the qcut function to perform equal-depth binning
data['bin'] = pd.qcut(data[int_column], q=num_bins, duplicates='drop')

# Create a Tkinter window
window = tk.Tk()
window.title("Binned Data Table")

# Create a Treeview widget to display the table
tree = ttk.Treeview(window)
tree["columns"] = ("Bin", "Data")

# Define column headings
tree.column("#1", anchor=tk.W)
tree.column("#2", anchor=tk.W)
tree.heading("#1", text="Bin")
tree.heading("#2", text="Data")

# Insert data into the Treeview widget
for bin_name, group in data.groupby('bin', observed=False):
    bin_data = ", ".join(map(str, group[int_column].tolist()))
    tree.insert("", "end", values=(str(bin_name), bin_data))

# Pack the Treeview widget
tree.pack()

# Start the Tkinter main loop
window.mainloop()
