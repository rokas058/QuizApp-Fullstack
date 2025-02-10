import React, { useState, useEffect } from 'react';
import { fetchHighScores } from '../services/api';
import { format } from 'date-fns';

const HighScores = () => {
    const [highScores, setHighScores] = useState([]);

    useEffect(() => {
        const loadHighScores = async () => {
            const data = await fetchHighScores();
            setHighScores(data);
        };

        loadHighScores();
    }, []);

    return (
        <div className="p-4 bg-light rounded shadow">
            <h1 className="mb-4 text-center">High Scores</h1>
            <ul className="list-group">
                {highScores.map((score, index) => (
                    <li
                        key={score.id}
                        className={`list-group-item d-flex justify-content-between align-items-center ${index === 0
                            ? 'list-group-item-success'
                            : index === 1
                                ? 'list-group-item-info'
                                : index === 2
                                    ? 'list-group-item-warning'
                                    : ''
                            }`}
                    >
                        <span>
                            {index + 1}. {score.email}
                        </span>
                        <span>
                            {score.score} points - {format(new Date(score.dateTime), 'yyyy/MM/dd HH:mm')}
                        </span>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default HighScores;

