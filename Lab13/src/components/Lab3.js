import React, { useState } from 'react';

const PathReversalLab = () => {
  const [inputData, setInputData] = useState('');
  const [reversedPath, setReversedPath] = useState('');

  const handleInputChange = (event) => {
    setInputData(event.target.value);
  };

  const calculateReversedPath = () => {
    setReversedPath(getReversedPath(inputData));
  };

  const getReversedPath = (input) => {
    let x = 0, y = 0;

    for (const direction of input) {
      switch (direction) {
        case 'N': y++; break;
        case 'E': x++; break;
        case 'S': y--; break;
        case 'W': x--; break;
        default: break; // ігнорувати невідомі символи
      }
    }

    return generateReversedPath(x, y);
  };

  const generateReversedPath = (x, y) => {
    let path = '';
    path += y > 0 ? 'S'.repeat(y) : y < 0 ? 'N'.repeat(-y) : '';
    path += x > 0 ? 'W'.repeat(x) : x < 0 ? 'E'.repeat(-x) : '';
    return path;
  };

  return (
    <div className="container">
      <h1>Лабораторна робота 2</h1>
      <h2>Умова задачі:</h2>
      <p>Прямокутний коридор довжиною N метрів та шириною M метрів вирішили
        застелити N прямокутними плитками шириною 1 метр та довжиною M метрів,
        таким чином, щоб не було не застеленої поверхні.
        Потрібно написати програму, яка знайде кількість способів зробити це.
        Наприклад, для коридору з розмірами 6 на 4 є чотири способи застелити плитками
        1 на 4.</p>
      <h2>Вхідні дані</h2>
      <p>Вхідний файл INPUT.TXT містить два цілих числа – M (довжина плитки та
        ширина коридору) та N (довжина коридору). Для цих чисел правильні нерівності
        2 ≤ M ≤ N ≤ 50</p>
      <h2>Вихідні дані:</h2>
      <p>Вихідний файл OUTPUT.TXT повинен містити одне число – кількість
        способів</p>
        <h2>Приклад:</h2>
      <p>INPUT: 4 6</p>
      <p>OUTPUT: 4</p>
      <form>
        <div className="form-group">
          <label htmlFor="Input">Введіть напрямки (N, E, S, W):</label>
          <input type="text" value={inputData} onChange={handleInputChange} className="form-control" id="Input" />
        </div>
        <button type="button" onClick={calculateReversedPath} className="btn">Обчислити</button>
      </form>

      {reversedPath && (
        <div className="form-group">
          <label htmlFor="Output">Обернений Шлях:</label>
          <input type="text" value={reversedPath} className="form-control" id="Output" readOnly />
        </div>
      )}
    </div>
  );
};

export default PathReversalLab;
