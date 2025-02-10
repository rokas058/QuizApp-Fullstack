import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import QuizPage from './pages/QuizPage';
import HighScoresPage from './pages/HighScoresPage';
import Navbar from './components/Navbar';

const App = () => {
  return (
    <Router>
      <Navbar />
      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<QuizPage />} />
          <Route path="/highscores" element={<HighScoresPage />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;


