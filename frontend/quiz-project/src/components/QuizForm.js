import React, { useState, useEffect } from 'react';
import { fetchQuestions, submitQuiz } from '../services/api';

const QuizForm = () => {
    const [questions, setQuestions] = useState([]);
    const [email, setEmail] = useState('');
    const [answers, setAnswers] = useState({});

    useEffect(() => {
        const loadQuestions = async () => {
            const data = await fetchQuestions();
            setQuestions(data);
        };
        loadQuestions();
    }, []);

    const handleAnswerChange = (questionId, answer) => {
        setAnswers((prev) => ({ ...prev, [questionId]: answer }));
    };

    const handleCheckboxChange = (questionId, option) => {
        const selectedOptions = answers[questionId] || [];
        const newSelection = selectedOptions.includes(option)
            ? selectedOptions.filter((item) => item !== option)
            : [...selectedOptions, option];
        handleAnswerChange(questionId, newSelection);
    };

    const handleRadioChange = (questionId, option) => {
        handleAnswerChange(questionId, [option]);
    };

    const handleTextBoxChange = (questionId, value) => {
        handleAnswerChange(questionId, { textAnswer: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const submission = {
            email,
            answers: Object.entries(answers).map(([questionId, answer]) => ({
                questionId: parseInt(questionId),
                selectedOptions: Array.isArray(answer) ? answer : (answer ? [answer] : []),
                textAnswer: answer?.textAnswer || '',
            })),
        };

        const result = await submitQuiz(submission);
        alert(`Your score: ${result.score}`);
    };

    return (
        <form onSubmit={handleSubmit} className="p-4 bg-light rounded shadow">
            <h1 className="mb-4 text-center">Quiz</h1>

            <div className="mb-3">
                <label className="form-label">Email:</label>
                <input
                    type="email"
                    className="form-control"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
            </div>

            {questions.map((question) => (
                <div key={question.id} className="mb-3">
                    <h5>{question.questionText}</h5>

                    {question.questionType === 'Radio' &&
                        question.options.map((option) => (
                            <div className="form-check" key={option.id}>
                                <input
                                    type="radio"
                                    className="form-check-input"
                                    name={`question-${question.id}`}
                                    value={option.option}
                                    checked={answers[question.id]?.includes(option.option) || false}
                                    onChange={() => handleRadioChange(question.id, option.option)}
                                />
                                <label className="form-check-label">{option.option}</label>
                            </div>
                        ))}

                    {question.questionType === 'Checkbox' &&
                        question.options.map((option) => (
                            <div className="form-check" key={option.id}>
                                <input
                                    type="checkbox"
                                    className="form-check-input"
                                    value={option.option}
                                    checked={answers[question.id]?.includes(option.option) || false}
                                    onChange={() => handleCheckboxChange(question.id, option.option)}
                                />
                                <label className="form-check-label">{option.option}</label>
                            </div>
                        ))}

                    {question.questionType === 'TextBox' && (
                        <input
                            type="text"
                            className="form-control"
                            value={answers[question.id]?.textAnswer || ''}
                            onChange={(e) => handleTextBoxChange(question.id, e.target.value)}
                        />
                    )}
                </div>
            ))}

            <button type="submit" className="btn btn-primary w-100">
                Submit
            </button>
        </form>
    );
};

export default QuizForm;



