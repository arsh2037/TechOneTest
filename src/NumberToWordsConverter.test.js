import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import axios from 'axios';
import NumberToWordsConverter from './NumberToWordsConverter';

// Mock axios
jest.mock('axios');

test('converts number to words', async () => {
  // Mock the axios response
  axios.post.mockResolvedValue({ data: { outputWords: 'ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS' } });

  // Render the component
  render(<NumberToWordsConverter />);

  // Find the input and change its value
  const input = screen.getByLabelText(/Enter a number:/i);
  fireEvent.change(input, { target: { value: '123.45' } });

  // Find the button and click it
  const button = screen.getByRole('button', { name: /Convert/i });
  fireEvent.click(button);

  // Wait for the output to appear
  const output = await screen.findByText(/ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS/i);
  expect(output).toBeInTheDocument();
});

test('converts zero to words', async () => {
  axios.post.mockResolvedValue({ data: { outputWords: 'ZERO DOLLARS' } });

  render(<NumberToWordsConverter />);

  const input = screen.getByLabelText(/Enter a number:/i);
  fireEvent.change(input, { target: { value: '0' } });

  const button = screen.getByRole('button', { name: /Convert/i });
  fireEvent.click(button);

  const output = await screen.findByText(/ZERO DOLLARS/i);
  expect(output).toBeInTheDocument();
});

test('converts negative number to words', async () => {
  axios.post.mockResolvedValue({ data: { outputWords: 'NEGATIVE TWENTY DOLLARS' } });

  render(<NumberToWordsConverter />);

  const input = screen.getByLabelText(/Enter a number:/i);
  fireEvent.change(input, { target: { value: '-20' } });

  const button = screen.getByRole('button', { name: /Convert/i });
  fireEvent.click(button);

  const output = await screen.findByText(/NEGATIVE TWENTY DOLLARS/i);
  expect(output).toBeInTheDocument();
});

test('handles invalid input gracefully', async () => {
  axios.post.mockResolvedValue({ data: { outputWords: 'INVALID INPUT' } });

  render(<NumberToWordsConverter />);

  const input = screen.getByLabelText(/Enter a number:/i);
  fireEvent.change(input, { target: { value: 'abc' } });

  const button = screen.getByRole('button', { name: /Convert/i });
  fireEvent.click(button);

  const output = await screen.findByText(/INVALID INPUT/i);
  expect(output).toBeInTheDocument();
});