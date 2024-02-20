import pandas as pd
import tkinter as tk
from tkinter import ttk

# Read the CSV file into a pandas DataFrame
data = pd.read_csv('dataset.csv')

# Specify the number of bins and the column containing the integers
num_bins = 5  # You can adjust this to the desired number of bins
int_column = 'Number'  # Replace 'integer_column_name' with the actual column name

# Calculate bin width based on the range of values
min_value = data[int_column].min()
max_value = data[int_column].max()
bin_width = (max_value - min_value) / num_bins

# Create a list of bin labels based on equal-width binning
bin_labels = [f"{min_value + i * bin_width:.2f}-{min_value + (i + 1) * bin_width:.2f}" for i in range(num_bins)]

# Use the cut function to perform equal-width binning
data['bin'] = pd.cut(data[int_column], bins=num_bins, labels=bin_labels)

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
