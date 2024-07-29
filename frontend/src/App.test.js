import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import App from './App';

test('renders Number to Words Converter heading', () => {
  render(<App />);
  const headingElement = screen.getByText(/Number to Words Converter/i);
  expect(headingElement).toBeInTheDocument();
});