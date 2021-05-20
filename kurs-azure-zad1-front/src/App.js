import { useEffect, useState } from 'react';

const App = () => {
    const [exercises, setExercises] = useState([]);
    const [name, setName] = useState('');
    const [distance, setDistance] = useState(0);
    const [minutes, setMinutes] = useState(0);
    const getExercisesData = () => {
        fetch(`http://localhost:3000/api/home`)
            .then((response) => response.json())
            .then((data) => setExercises(data));
    };

    const AddExercise = () => {
        fetch(`http://localhost:3000/api/home`, {
            headers: { 'Content-Type': 'application/json' },
            method: 'POST',
            body: JSON.stringify({
                name: name,
                distance: parseFloat(distance),
                minutes: parseInt(minutes),
            }),
        });
        getExercisesData();
    };

    useEffect(() => {
        getExercisesData();
    });
    return (
        <div>
            <table>
                <tr>
                    <th>nazwa</th>
                    <th>dystans</th>
                    <th>czas</th>
                </tr>
                {exercises.map((exercise) => (
                    <tr>
                        <td>{exercise.name}</td>
                        <td>{exercise.distance}</td>
                        <td>{exercise.minutes}</td>
                    </tr>
                ))}
            </table>
            <div>
                <input
                    type="text"
                    placeholder="nazwa"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <input
                    type="number"
                    placeholder="dystans"
                    value={distance}
                    onChange={(e) => setDistance(e.target.value)}
                />
                <input
                    type="number"
                    placeholder="minuty"
                    value={minutes}
                    onChange={(e) => setMinutes(e.target.value)}
                />
                <button onClick={AddExercise}>Dodaj</button>
            </div>
        </div>
    );
};

export default App;
