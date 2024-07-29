import React, { useState } from 'react';
import axios from 'axios';

const NumberToWordsConverter = () => {
  const [inputNumber, setInputNumber] = useState('');
  const [outputWords, setOutputWords] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const requestBody = {
        
            "inputNumber": inputNumber,
            "outputWords": inputNumber
        
      }
      const response = await axios.post('/api/numbertowords',requestBody);
      setOutputWords(response.data.outputWords);
    } catch (error) {
      console.error('There was an error converting the number!', error);
    }
  };

  return (
    <div>
      <h1>Number to Words Converter</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Enter a number:
          <input
            type="text"
            value={inputNumber}
            onChange={(e) => setInputNumber(String(e.target.value))}
          />
        </label>
        <button type="submit">Convert</button>
      </form>
      {outputWords && (
        <div>
          <h2>Output:</h2>
          <p>{outputWords}</p>
        </div>
      )}
    </div>
  );
};

export default NumberToWordsConverter;
