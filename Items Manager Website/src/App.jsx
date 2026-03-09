import React, { useState, useEffect } from "react";
import {
  addItem,
  fetchItems,
  updateItem,
  deleteItem,
  fetchSortedItems,
  fetchFilteredItems,
} from "./firestore-functions";
import 'bulma/css/bulma.min.css';

const App = () => {
  const [items, setItems] = useState([]);
  const [newItem, setNewItem] = useState("");
  const [editItem, setEditItem] = useState(null);
  const [sortField, setSortField] = useState("name");
  const [filterField, setFilterField] = useState("name");
  const [filterValue, setFilterValue] = useState("");

  useEffect(() => {
    loadItems().then(() => console.log("items loaded successfully"));
  }, []);

  const loadItems = async () => {
    const fetchedItems = await fetchItems();
    setItems(fetchedItems);
  };

  const handleAdd = async () => {
    const trimmedItem = newItem.trim().toLowerCase();
    if (!trimmedItem) {
      alert("Please enter some item to add in list.");
      return;
    }

    const isDuplicate = items.some(
      (item) => item.name.toLowerCase() === trimmedItem
    );
    if (isDuplicate) {
      alert("The item already exists in the list.");
      return;
    }

    await addItem({ name: trimmedItem });
    setNewItem("");
    await loadItems();
  };

  const handleUpdate = async (id, name) => {
    setEditItem(null);
    await updateItem(id, { name });
    await loadItems();
  };

  const handleDelete = async (id) => {
    await deleteItem(id);
    await loadItems();
  };

  const handleSort = async () => {
    const sortedItems = await fetchSortedItems(sortField);
    setItems(sortedItems);
  };

  const handleFilter = async () => {
    const filteredItems = await fetchFilteredItems(filterField, filterValue);
    setItems(filteredItems);
  };

  return (
    <div className="container mt-5">
      <h1 className="title is-3 has-text-centered">Items Manager</h1>

      {/* Add Item */}
      <div className="columns is-centered mb-4">
        <div className="column is-half">
          <div className="field has-addons">
            <div className="control is-expanded">
              <input
                className="input is-fullwidth"
                type="text"
                value={newItem}
                onChange={(e) => setNewItem(e.target.value)}
                placeholder="Add new item"
              />
            </div>
            <div className="control">
              <button className="button is-primary" onClick={handleAdd}>
                Add
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* Sort Items */}
      <div className="columns is-centered mb-4">
        <div className="column is-half">
          <div className="field is-grouped is-fullwidth">
            <div className="control is-expanded">
              <div className="select is-fullwidth">
                <select
                  value={sortField}
                  onChange={(e) => setSortField(e.target.value)}
                >
                  <option value="name">Name</option>
                  <option value="date">Date</option>
                </select>
              </div>
            </div>
            <div className="control">
              <button className="button is-link" onClick={handleSort}>
                Sort
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* Filter Items */}
      <div className="columns is-centered mb-4">
        <div className="column is-half">
          <div className="field is-grouped is-fullwidth">
            <div className="control is-expanded">
              <input
                className="input is-fullwidth"
                type="text"
                value={filterValue}
                onChange={(e) => setFilterValue(e.target.value)}
                placeholder="Filter value"
              />
            </div>
            <div className="control">
              <div className="select is-fullwidth">
                <select
                  value={filterField}
                  onChange={(e) => setFilterField(e.target.value)}
                >
                  <option value="name">Name</option>
                  <option value="category">Category</option>
                </select>
              </div>
            </div>
            <div className="control">
              <button className="button is-warning" onClick={handleFilter}>
                Filter
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* Items List */}
      <div className="box">
        {items.length === 0 && <p>No items yet.</p>}
        <ul>
          {items.map((item) => (
            <li key={item.id} className="mb-2">
              <div className="is-flex is-justify-content-space-between">
                {editItem === item.id ? (
                  <input
                    className="input is-small"
                    type="text"
                    defaultValue={item.name}
                    onBlur={(e) => handleUpdate(item.id, e.target.value)}
                  />
                ) : (
                  <span>{item.name}</span>
                )}
                <div className="buttons are-small">
                  <button
                    className="button is-info"
                    onClick={() => setEditItem(item.id)}
                  >
                    Edit
                  </button>
                  <button
                    className="button is-danger"
                    onClick={() => handleDelete(item.id)}
                  >
                    Delete
                  </button>
                </div>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default App;
