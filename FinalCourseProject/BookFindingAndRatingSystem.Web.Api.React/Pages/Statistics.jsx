import React, { useState, useEffect } from 'react';
import './Statistics.css';
function Statistics() {
    const [statistics, setStatistics] = useState({
        numberOfBooks: 0,
        numberOfAuthors: 0,
        numberOfUsers: 0
    });

    useEffect(() => {
        fetch('/api/statistics', {
            headers: {
                Authorization: `Bearer ${yourAuthToken}`
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Failed to fetch statistics');
                }
                return response.json();
            })
            .then(data => setStatistics(data))
            .catch(error => console.error('Error fetching statistics', error));
    }, []);

    return (
        <div className="statistics-container">
            <h2>Statistics</h2>
            <div className="statistics-block">
                <p>Number of Books: {statistics.numberOfBooks}</p>
                <button onClick={() => window.location.href = '/books'} className="button">View Books</button>
            </div>
            <div className="statistics-block">
                <p>Number of Authors: {statistics.numberOfAuthors}</p>
                <button onClick={() => window.location.href = '/authors'}>View Authors</button>
            </div>
            <div className="statistics-block">
                <p>Number of Users: {statistics.numberOfUsers}</p>
                <button onClick={() => window.location.href = '/users'}>View Users</button>
            </div>
        </div>
    );
}

export default Statistics;
