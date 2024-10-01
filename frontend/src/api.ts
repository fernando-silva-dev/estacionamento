import axios from 'axios';

export interface ErrorMessage {
  message: string;
}

const api = axios.create({
  baseURL: 'http://localhost:5022',
  timeout: 5000,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;
