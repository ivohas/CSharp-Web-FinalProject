import React, { useState, useEffect } from 'react';

export const Statistics = () => {
    const [statistics, setStatistics] = useState(null);

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
            .then(data => {
                setStatistics(data); // Set the fetched statistics data
            })
            .catch(error => console.error('Error fetching statistics', error));
    }, []);

    if (statistics === null) {
        return <div>Loading...</div>; // Display a loading message while fetching
    }

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
};
