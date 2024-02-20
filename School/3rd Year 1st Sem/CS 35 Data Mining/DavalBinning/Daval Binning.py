import pandas as pd
import tkinter as tk
from tkinter import ttk, messagebox
import statistics


listbox = None
entry = None


def update_listbox():
    global listbox
    if listbox:
        data = pd.read_csv('dataset.csv')
        sorted_data = sorted(data['Number'])
        listbox.delete(0, tk.END)
        for num in sorted_data:
            listbox.insert(tk.END, num)


def remove_item():
    global listbox
    selected_index = listbox.curselection()
    if not selected_index:
        messagebox.showerror('Error', 'Please select an item to remove.')
        return
    selected_item = listbox.get(selected_index)

    data = pd.read_csv('dataset.csv')
    indices_to_remove = data.index[data['Number'] == selected_item].tolist()

    if indices_to_remove:
        data = data.drop(indices_to_remove[0])
        data.to_csv('dataset.csv', index=False)
        update_listbox()


def add_entry():
    global entry
    new_entry = entry.get()
    try:
        new_entry = int(new_entry)
        data = pd.read_csv('dataset.csv')
        new_row = pd.DataFrame({'Number': [new_entry]})
        data = pd.concat([data, new_row], ignore_index=True)

        data = data.sort_values(by='Number')

        data.to_csv('dataset.csv', index=False)
        entry.delete(0, tk.END)
        update_listbox()
    except ValueError:
        messagebox.showerror('Error', 'Please enter a valid integer.')


def equal_width_binning():
    data = pd.read_csv('dataset.csv')
    num_bins = 5
    int_column = 'Number'

    min_value = data[int_column].min()
    max_value = data[int_column].max()
    bin_width = (max_value - min_value) / num_bins

    bin_labels = [f"{min_value + i * bin_width:.2f}-{min_value + (i + 1) * bin_width:.2f}" for i in range(num_bins)]

    data['bin'] = pd.cut(data[int_column], bins=num_bins, labels=bin_labels)

    display_in_treeview(data)


def equal_depth_binning():
    data = pd.read_csv('dataset.csv')
    num_bins = 5
    int_column = 'Number'

    data['bin'] = pd.qcut(data[int_column], q=num_bins, duplicates='drop')

    display_in_treeview(data)


def display_in_treeview(data):
    window = tk.Tk()
    window.title("Binned Data Table")

    notebook = ttk.Notebook(window)
    notebook.pack(fill=tk.BOTH, expand=True)

    # tab for binning
    tree_tab = ttk.Frame(notebook)
    notebook.add(tree_tab, text="Binning")

    tree = ttk.Treeview(tree_tab)
    tree["columns"] = ("Bin", "Data")
    tree.column("#1", anchor=tk.W)
    tree.column("#2", anchor=tk.W)
    tree.heading("#1", text="Bin")
    tree.heading("#2", text="Data")

    for bin_name, group in data.groupby('bin', observed=False):
        bin_data = ", ".join(map(str, group['Number'].tolist()))
        tree.insert("", "end", values=(str(bin_name), bin_data))

    tree.pack(fill=tk.BOTH, expand=True)

    # tab for bin means
    smoothing_tab = ttk.Frame(notebook)
    notebook.add(smoothing_tab, text="Smoothing by Bin Means")

    mean_data_dict = {}
    for bin_name, group in data.groupby('bin', observed=False):
        mean_data = group['Number'].mean()
        mean_data_dict[bin_name] = mean_data

    smoothed_data = data.copy()
    smoothed_data['Number'] = smoothed_data['Number'].astype(float)
    for bin_name, group in data.groupby('bin', observed=False):
        mean_data = mean_data_dict[bin_name]
        smoothed_data.loc[group.index, 'Number'] = mean_data

    smoothed_tree = ttk.Treeview(smoothing_tab)
    smoothed_tree["columns"] = ("Bin", "Data")
    smoothed_tree.column("#1", anchor=tk.W)
    smoothed_tree.column("#2", anchor=tk.W)
    smoothed_tree.heading("#1", text="Bin")
    smoothed_tree.heading("#2", text="Data")

    for bin_name, group in smoothed_data.groupby('bin', observed=False):
        bin_data = ", ".join(map(str, group['Number'].tolist()))
        smoothed_tree.insert("", "end", values=(str(bin_name), bin_data))

    smoothed_tree.pack(fill=tk.BOTH, expand=True)

    # tab for bin medians
    smoothing_tab = ttk.Frame(notebook)
    notebook.add(smoothing_tab, text="Smoothing by Bin Medians")

    median_data_dict = {}
    for bin_name, group in data.groupby('bin', observed=False):
        median_data = statistics.median(group['Number'])  # Calculate median
        median_data_dict[bin_name] = median_data

    smoothed_data = data.copy()
    smoothed_data['Number'] = smoothed_data['Number'].astype(float)
    for bin_name, group in data.groupby('bin', observed=False):
        median_data = median_data_dict[bin_name]
        smoothed_data.loc[group.index, 'Number'] = median_data

    smoothed_tree = ttk.Treeview(smoothing_tab)
    smoothed_tree["columns"] = ("Bin", "Data")
    smoothed_tree.column("#1", anchor=tk.W)
    smoothed_tree.column("#2", anchor=tk.W)
    smoothed_tree.heading("#1", text="Bin")
    smoothed_tree.heading("#2", text="Data")

    for bin_name, group in smoothed_data.groupby('bin', observed=False):
        bin_data = ", ".join(map(str, group['Number'].tolist()))
        smoothed_tree.insert("", "end", values=(str(bin_name), bin_data))

    smoothed_tree.pack(fill=tk.BOTH, expand=True)


    window.mainloop()


def main_menu():
    menu = tk.Tk()
    menu.title("Binning Menu")

    label = tk.Label(menu, text="Choose Binning Method:")
    label.pack(pady=10)

    equal_width_button = tk.Button(menu, text="Equal-width", command=equal_width_binning)
    equal_width_button.pack()

    equal_depth_button = tk.Button(menu, text="Equal-depth", command=equal_depth_binning)
    equal_depth_button.pack()

    menu.mainloop()


def number_manager():
    global listbox, entry

    window = tk.Tk()
    window.title('Number Manager')

    entry_label = tk.Label(window, text='Enter an integer:')
    entry_label.pack(pady=5)

    entry = tk.Entry(window)
    entry.pack(pady=5)

    add_button = tk.Button(window, text='Add', command=add_entry)
    add_button.pack(pady=5)

    listbox = tk.Listbox(window)
    listbox.pack(padx=10, pady=5)

    remove_button = tk.Button(window, text='Remove', command=remove_item)
    remove_button.pack(pady=5)

    update_listbox()

    window.resizable(True, True)

    menu_button = tk.Button(window, text="Open Binning Menu", command=main_menu)
    menu_button.pack(pady=10)

    window.mainloop()


number_manager()
