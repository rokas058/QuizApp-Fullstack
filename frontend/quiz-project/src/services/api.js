import axios from 'axios';

const API_BASE_URL = 'https://localhost:7227/api/Quiz';

export const fetchQuestions = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/questions`);
        return response.data;
    } catch (error) {
        throw error;
    }
};


export const submitQuiz = async (quizSubmission) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/submit`, quizSubmission);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const fetchHighScores = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/scores`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

