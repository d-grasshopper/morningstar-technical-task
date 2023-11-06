import React, { useState } from "react";
import axios from "axios";
import "./App.css";

function App() {
  const [searchTerm, setSearchTerm] = useState("");
  const [results, setResults] = useState([]);
  const [showError, setError] = useState(false);

  const handleSearch = async () => {
    if (searchTerm === null || searchTerm === "") {
      setError(true);
      return;
    }

    setError(false);
    try {
      const response = await axios.get(
        `http://localhost:5005/search/${searchTerm}`
      );
      setResults(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <div>
          <input
            type="text"
            placeholder="Search..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button onClick={handleSearch}>Search</button>
          {results.length === 0 ? <div>No results to show.</div> : <></>}
          {showError ? (
            <div>You need to provide input.</div>
          ) : (
            <div>
              {results.map((person: any) => (
                <div key={person.id}>
                  {person.first_name} {person.last_name}
                </div>
              ))}
            </div>
          )}
        </div>
      </header>
    </div>
  );
}

export default App;
