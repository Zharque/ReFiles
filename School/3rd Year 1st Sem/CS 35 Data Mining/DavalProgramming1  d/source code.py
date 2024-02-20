# ceated by: Rynz Daval
# passed to: Ma'am Chuchi Montenegro
# CS35 Data Mining
# Sept. 10, 2023

import pandas as pd
import tkinter as tk
from tkinter import ttk
from tkinter import scrolledtex

def create_tab(tab_control, data_frame, tab_title):
    frame = ttk.Frame(tab_control)
    tab_control.add(frame, text=tab_title)

    text_widget = scrolledtext.ScrolledText(frame, wrap=tk.WORD, width=80, height=24)
    text_widget.insert(tk.INSERT, data_frame.to_string(index=False))
    text_widget.pack(fill="both", expand=True)


# original dataset
df = pd.read_csv('dataset.csv')

# remove rows
remove_rows_df = df.dropna()

# column averages
fill_averages_df = df.fillna(df.mean())

# linear interpolation
linear_interpolation_df = df.interpolate(method='linear')

# global constants with None
fill_constant_df = df.fillna('None')

# tkinter window
root = tk.Tk()
root.title("Dataset Viewer")

# tabbed interface
notebook = ttk.Notebook(root)
notebook.pack(fill="both", expand=True)

# tabs
create_tab(notebook, df, "  Original  ")
create_tab(notebook, remove_rows_df, "  Remove Rows  ")
create_tab(notebook, fill_averages_df, "  Column Averages  ")
create_tab(notebook, linear_interpolation_df, "  Linear Interpolation  ")
create_tab(notebook, fill_constant_df, "  Global Constants  ")

root.mainloop()
